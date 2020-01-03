using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DynamicSystem.Services
{

    public class DbUtilities
    {
        private AppconfigUtilities _appconfigUtilities;

        public DbUtilities()
        {
            _appconfigUtilities = new AppconfigUtilities();
        }

        public List<string> GetAllTable()
        {
            List<string> tables = new List<string>();
            List<string> result = new List<string>();
            using (SqlConnection connection = new SqlConnection(_appconfigUtilities.GetConnectionString()))
            {
                connection.Open();
                DataTable dataTable = connection.GetSchema("Tables");
                foreach (DataRow row in dataTable.Rows)
                {
                    string tablename = (string)row[2];
                    tables.Add(tablename);
                }
            }

            tables.Sort();

            for (int i = 0; i < tables.Count(); i++)
            {
                if (Constant.INGORE_FILE.Contains(tables[i]))
                {
                    continue;
                }

                result.Add(tables[i]);
            }

            return result;
        }

        public List<string> GetAllTableDependOn(string table)
        {
            List<string> tableDependOns = new List<string>();
            using (SqlConnection connection = new SqlConnection(_appconfigUtilities.GetConnectionString()))
            {
                string query = "SELECT DISTINCT OBJECT_NAME(referenced_object_id) TableName " +
                    "FROM sys.foreign_keys " +
                    "WHERE name IN" +
                    "(SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE TABLE_NAME = '" + table + "'); ";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int k = 0; k < reader.FieldCount; k++)
                            {
                                var columnData = Convert.ToString(reader[k]);
                                tableDependOns.Add(columnData);
                            }
                        }
                    }
                }
            }
            return tableDependOns;
        }
    }
}
