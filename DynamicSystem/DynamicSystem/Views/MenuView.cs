using System.Windows.Forms;

namespace DynamicSystem.Views
{
    public partial class MenuView : Form
    {
        public MenuView()
        {
            InitializeComponent();
        }

        private void MenuView_Load(object sender, System.EventArgs e)
        {

        }

        private void generateToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            GenerateScriptView view = new GenerateScriptView();
            view.StartPosition = FormStartPosition.CenterParent;
            view.ShowDialog();
        }

        private void configGenerateScriptToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ConfigurationView view = new ConfigurationView();
            view.StartPosition = FormStartPosition.CenterParent;
            view.ShowDialog();
        }

        private void connectionStringToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ConnectionStringView view = new ConnectionStringView();
            view.StartPosition = FormStartPosition.CenterParent;
            view.ShowDialog();
        }
    }
}
