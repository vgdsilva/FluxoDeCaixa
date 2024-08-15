using CommunityToolkit.Mvvm.ComponentModel;

namespace FluxoDeCaixa.Mobile.ViewModels
{

    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        string title;

        public Page Page { get; private set; }

        public T FindByName<T>(string name) => Page.FindByName<T>(name);
        public string Id { get; set; }

        [ObservableProperty]
        bool isBusy;

        public void SetInstancePage(Page page) => this.Page = page;

        public virtual void Page_Load() { }

        protected async Task GoToAsync(ShellNavigationState state, bool animate = true)
        {
            await Shell.Current.GoToAsync(state, animate);
        }
    }
}
