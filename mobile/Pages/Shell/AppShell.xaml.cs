

using System.Reflection;
using FluxoDeCaixa.MAUI.Pages.Base;
using FluxoDeCaixa.MAUI.Pages.Transaction.Detail;

namespace FluxoDeCaixa.MAUI.Pages.Shell;

    public partial class AppShell : Microsoft.Maui.Controls.Shell
    {
        public Dictionary<string, Type> Routes { get; private set; } = new Dictionary<string, Type>();
        public AppShell()
        {
            RegisterRoutes();
            InitializeComponent();
        }

        void RegisterRoutes()
        {
            Routes.Add(nameof(TransactionDetailPage), typeof(TransactionDetailPage));

            foreach (KeyValuePair<string, Type> item in Routes)
                Routing.RegisterRoute(item.Key, item.Value);
        }

        #region Register Routes Methods

        protected override async void OnNavigating(ShellNavigatingEventArgs args)
        {
            if (args.Source == ShellNavigationSource.Pop && !Application.Current!.MainPage!.Navigation.ModalStack.Any())
            {
                var app = Application.Current;
                var navigationStack = app.MainPage.Navigation.NavigationStack;
                var page = navigationStack.Last();
                if (page != null)
                {
                    var bc = page.BindingContext as BaseViewModels;
                    if (bc != null)
                    {
                        ShellNavigatingDeferral token = args.GetDeferral();
                        // if (!await bc.CanClosePage())
                        // {
                        //     args.Cancel();
                        // }
                        // else if (!string.IsNullOrEmpty(bc.PopShellCustomPath) && args?.Target?.Location?.OriginalString != bc.PopShellCustomPath)
                        // {
                        //     args.Cancel();
                        //
                        //     await Current.GoToAsync(bc.PopShellCustomPath);
                        // }
                        token.Complete();
                    }
                }
            }
            base.OnNavigating(args);
        }

        #endregion
    }
