namespace FluxoDeCaixa.WinForms.Forms
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (Directory.Exists(Context.AppContext.databasePath))
            {
                new DashboardForm().Show();
                
            }
            else
            {
                new RegistrerForm().Show();
            }

            await Task.Delay(100);
            this.Hide();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
        }
    }
}
