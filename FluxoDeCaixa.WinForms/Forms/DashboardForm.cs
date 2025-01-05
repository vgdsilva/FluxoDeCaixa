using FluxoDeCaixa.WinForms.Forms.Base;

namespace FluxoDeCaixa.WinForms.Forms
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            new RegistrerForm().ShowDialog();
        }
    }
}
