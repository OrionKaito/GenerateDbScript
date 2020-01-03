using DynamicSystem.Services;
using System;
using System.Windows.Forms;

namespace DynamicSystem.Views
{
    public partial class ConnectionStringView : Form
    {
        private DbUtilities _dbUtilities;
        private AppconfigUtilities _appconfigUtilities;

        public ConnectionStringView()
        {
            _dbUtilities = new DbUtilities();
            _appconfigUtilities = new AppconfigUtilities();
            InitializeComponent();
        }

        private void ConnectionStringView_Load(object sender, EventArgs e)
        {
            txtConnectionString.Text = _appconfigUtilities.GetConnectionString();
        }

        private void txtConnectionString_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var connectionString = txtConnectionString.Text;

            try
            {
                _appconfigUtilities.SaveToAppConfig(Constant.APP_CONNECTION_STRING,
                        connectionString,
                        Constant.METHOD_UPDATE);

                MessageBox.Show("Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
