using DynamicSystem.Models;
using DynamicSystem.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DynamicSystem.Presenter
{
    public class GenerateScriptPresenter
    {
        private DbUtilities _dbUtilities;
        private AppconfigUtilities _appconfigUtilities;

        public GenerateScriptPresenter()
        {
            _dbUtilities = new DbUtilities();
            _appconfigUtilities = new AppconfigUtilities();
        }

        public List<string> GetTableOrderByDependencies()
        {
            //Chứa cặp các table và các dependency của chúng
            Dictionary<string, Item> existedAdj = new Dictionary<string, Item>();
            List<Item> graphTableDependency = new List<Item>();

            List<string> tables = _dbUtilities.GetAllTable();

            foreach (var table in tables)
            {
                List<Item> adjTableDenpendencies = new List<Item>();
                //List các table dependency của table
                var dependencies = _dbUtilities.GetAllTableDependOn(table).ToArray();

                foreach (var dependency in dependencies)
                {
                    if (!table.Equals(dependency)) //Kiểm tra có phải là chính nó
                    {
                        if (!existedAdj.ContainsKey(dependency)) //Kiểm tra là đã tạo Item này chưa
                        {
                            var item = new Item(dependency);
                            existedAdj.Add(item.Name, item);
                        }
                        adjTableDenpendencies.Add(existedAdj[dependency]); //Tạo mới cạnh
                    }
                }
                //Tạo mới đỉnh là table các cạch là adjTableDenpendencies
                graphTableDependency.Add(new Item(table, adjTableDenpendencies.ToArray()));
            }

            return TopologicalSort.Sort(graphTableDependency.ToArray(), x => x.Dependencies);
        }

        public string GenerateInsertScriptFromData()
        {
            List<string> tables = new List<string>();
            var DbQuery = "USE [" + Constant.BACKUP_DATABASE_NAME + "]\n";
            var tableOrdered = GetTableOrderByDependencies();

            var lastCheckedTable = _appconfigUtilities.GetLastCheckedTable(); //Lọc những bản đã được chọn

            if (lastCheckedTable.Count == 1)
            {
                return "No table checked! please config in Configuration Generate Script View.";
            }

            for (int i = 0; i < lastCheckedTable.Count; i++)
            {
                if (tableOrdered.Contains(lastCheckedTable[i]))
                {
                    tables.Add(lastCheckedTable[i]);
                }
            }

            for (int i = 0; i < tables.Count; i++) //Qua từng table
            {
                string insertScript = DbQuery;
                string query = "SELECT * FROM " + tables[i];
                using (SqlConnection connection = new SqlConnection(_appconfigUtilities.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            bool hasRecord = false;
                            bool hasId = false;
                            bool isOnlyOneRecord = true;
                            bool isDeleted = false;
                            var tableQuery = "";
                            var dataQuery = "";

                            if (reader.HasRows)
                            {
                                var columns = new List<string>(); //Lấy các cột của bảng

                                if (reader.GetName(0).Contains("Id")) //kiểm tra có Id không
                                {
                                    tableQuery += "\nSET IDENTITY_INSERT " + tables[i] + " ON\n";
                                    hasId = true;
                                }

                                for (int z = 0; z < reader.FieldCount; z++)
                                {
                                    columns.Add(reader.GetName(z));
                                }

                                var columnStr = ""; //Tạo chuỗi tên các cột
                                for (int j = 0; j < columns.Count; j++)
                                {
                                    if (j == (columns.Count - 1))
                                        columnStr += "[" + columns[j] + "]";
                                    else
                                        columnStr += "[" + columns[j] + "],";
                                }

                                tableQuery += "\nINSERT [dbo].[" + tables[i] + "](" + columnStr + ")\n";
                            }

                            while (reader.Read()) //Qua từng record
                            {
                                isDeleted = false;

                                if (!isOnlyOneRecord)
                                {
                                    dataQuery += "UNION ALL\nSELECT ";
                                }
                                else
                                {
                                    dataQuery += "SELECT ";
                                }

                                bool isFirstColumn = true;

                                for (int k = 0; k < reader.FieldCount; k++) //Qua từng column
                                {
                                    var columnData = Convert.ToString(reader[k]);
                                    var columnName = reader.GetName(k);
                                    DateTime dDate;

                                    if (!isFirstColumn)
                                    {
                                        dataQuery += ", ";
                                    }

                                    isFirstColumn = false;

                                    if (columnName.Equals(Constant.DB_FIELD_ISDELETED))
                                    {
                                        if (Boolean.Parse(columnData) == true)
                                        {
                                            isDeleted = true;
                                            break;
                                        }
                                    }
                                    if (columnName.Equals(Constant.DB_FIELD_CREATETIONTIME))
                                    {
                                        dataQuery += "GETDATE() AS [" + columnName + "]";
                                    }
                                    else if (columnName.Equals(Constant.DB_FIELD_LASTMODIFICATIONTIME)
                                        || columnName.Equals(Constant.DB_FIELD_LASTMODIFIERUSERID)
                                        || reader[k] == DBNull.Value)
                                    {
                                        dataQuery += "NULL AS [" + columnName + "]";
                                    }
                                    else if (columnName.Equals(Constant.DB_FIELD_CREATORUSERID))
                                    {
                                        dataQuery += "CAST(N'" + _appconfigUtilities.GetCreatorUserId()
                                            + "' AS [" + columnName + "]";
                                    }
                                    else if (DateTime.TryParse(columnData, out dDate))
                                    {
                                        dataQuery += "CAST(N'" + columnData + "' AS DATETIME2) AS " + columnName;
                                    }
                                    else
                                    {
                                        dataQuery += "N'" + columnData + "' AS [" + columnName + "]";
                                    }
                                }

                                if (!isDeleted) //Nếu có thì mới ghi vào file và đặt cờ không phải record duy nhất
                                {
                                    if (isOnlyOneRecord)
                                    {
                                        insertScript += tableQuery + dataQuery + "\n";
                                        isOnlyOneRecord = false;
                                        hasRecord = true;
                                    }
                                    else
                                    {
                                        insertScript += dataQuery + "\n";
                                    }
                                }
                            }

                            if (hasId)
                            {
                                insertScript += "\nSET IDENTITY_INSERT " + tables[i] + " OFF\n";
                            }
                            if (hasRecord)
                            {
                                System.IO.File.WriteAllText(Constant.BACKUP_FILE_LOCATION + i.ToString("D4")
                                + "_" + tables[i] + ".sql", insertScript);
                            }
                        }
                    }
                }
            }
            return "Success";
        }
    }
}
