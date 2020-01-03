using DynamicSystem.Presenter;
using DynamicSystem.Services;
using System;
using System.Windows.Forms;

namespace DynamicSystem
{
    public partial class GenerateScriptView : Form
    {
        private GenerateScriptPresenter _generateScriptPresenter;
        private AppconfigUtilities _appconfigUtilities;

        public GenerateScriptView()
        {
            _generateScriptPresenter = new GenerateScriptPresenter();
            _appconfigUtilities = new AppconfigUtilities();
            InitializeComponent();
        }

        private void Generate_Click(object sender, EventArgs e)
        {
            try
            {
                var result = _generateScriptPresenter.GenerateInsertScriptFromData();
                MessageBox.Show(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExportDataView_Load(object sender, EventArgs e)
        {
            txtConnectionString.Text = "Connection String: " + _appconfigUtilities.GetConnectionString();
        }
    }
}
