using DynamicSystem.Services;
using System;
using System.Windows.Forms;

namespace DynamicSystem.Views
{
    public partial class ConfigurationView : Form
    {
        private DbUtilities _dbUtilities;
        private AppconfigUtilities _appconfigUtilities;
        private bool needItemCheck = true;
        private bool updatingCheckList = false;
        public ConfigurationView()
        {
            _dbUtilities = new DbUtilities();
            _appconfigUtilities = new AppconfigUtilities();
            InitializeComponent();
        }

        private void ConfigurationView_Load(object sender, EventArgs e)
        {
            needItemCheck = false;

            var tables = _dbUtilities.GetAllTable().ToArray();
            chklistboxTable.Items.AddRange(tables);

            var lastCheckedTable = _appconfigUtilities.GetLastCheckedTable();
            for (int i = 0; i < chklistboxTable.Items.Count; i++)
            {
                if (lastCheckedTable.Contains(chklistboxTable.Items[i].ToString()))
                    chklistboxTable.SetItemChecked(i, true);
            }

            needItemCheck = true;
        }

        private void CheckAll_CheckedChanged(object sender, EventArgs e)
        {
            needItemCheck = false;

            if (chckAll.Checked)
            {
                for (int i = 0; i < chklistboxTable.Items.Count; i++)
                {
                    chklistboxTable.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < chklistboxTable.Items.Count; i++)
                {
                    chklistboxTable.SetItemChecked(i, false);
                }
            }

            needItemCheck = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _appconfigUtilities.ClearDataAppConfig(Constant.APP_KEY_TABLE);
                foreach (int indexChecked in chklistboxTable.CheckedIndices)
                {
                    _appconfigUtilities.SaveToAppConfig(Constant.APP_KEY_TABLE,
                        chklistboxTable.Items[indexChecked].ToString(),
                        Constant.METHOD_ADD);
                }
                MessageBox.Show("Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void chklistboxTable_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (needItemCheck)
            {
                if (updatingCheckList) return;

                try
                {
                    updatingCheckList = true;
                    var result = "";
                    string item = chklistboxTable.SelectedItem.ToString();
                    int indexOfItemCheck = chklistboxTable.Items.IndexOf(item);

                    if (chklistboxTable.GetItemCheckState(indexOfItemCheck) == CheckState.Unchecked)
                    {
                        var dependtables = _dbUtilities.GetAllTableDependOn(item);

                        foreach (var dependtable in dependtables)
                        {
                            result += dependtable + "\n";
                        }

                        for (int i = 0; i < dependtables.Count; i++)
                        {
                            var index = chklistboxTable.Items.IndexOf(dependtables[i]);
                            chklistboxTable.SetItemChecked(index, true);
                        }

                        if (result != null && result.Length != 0)
                            MessageBox.Show(result);
                    }
                }
                finally
                {
                    updatingCheckList = false;
                }
            }
        }
    }
}
