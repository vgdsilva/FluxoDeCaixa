
namespace FluxoDeCaixa.WinForms.Forms.Base
{
    public abstract partial class BaseForm : Form
    {
        public bool OnCloseExitApp { get; set; }

        protected BaseForm(bool OnCloseExitApp)
        {
            this.OnCloseExitApp = OnCloseExitApp;    
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            if (OnCloseExitApp)
            {
                Application.Exit();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            OnFormLoad(e);
        }

        public abstract void OnFormLoad(EventArgs e);
    }
}
