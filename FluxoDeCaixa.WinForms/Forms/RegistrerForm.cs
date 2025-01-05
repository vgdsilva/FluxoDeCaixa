namespace FluxoDeCaixa.WinForms.Forms
{
    public partial class RegistrerForm : Form
    {
        public RegistrerForm()
        {
            InitializeComponent();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Exit();
        }

        private void btn_CreateUser_Click(object sender, EventArgs e)
        {
            

            Directory.CreateDirectory(Context.AppContext.databasePath);

            Application.Exit();
        }
    }
}
