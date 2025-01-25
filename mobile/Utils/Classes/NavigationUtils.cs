using RGPopup.Maui.Extensions;
using RGPopup.Maui.Pages;

namespace FluxoDeCaixa.MAUI.Utils.Classes
{
    public class NavigationUtils
    {
        /* PAGE FUNCTION */

        public static async Task PushAsync(Page page, bool animated = true)
        {
            await Application.Current!.MainPage.Navigation.PushAsync(page, animated);
        }


        // Exemplo:
        // Ao invés de: await Application.Current!.MainPage!.Navigation.PushPopupAsync(new ConsultaPedidoDeVendaFiltroPopUpPage(ConsultaPedidoDeVendaModel))
        // Faça: await NavigationUtils.PushPopupAsync<ConsultaPedidoDeVendaFiltroPopUpPage>(ConsultaPedidoDeVendaModel)
        public static async Task PushAsync<T>(params object?[]? parameter)
        {
            try
            {
                var pageType = typeof(T);
                var page = (ContentPage)Activator.CreateInstance(pageType, parameter);
                await Application.Current!.MainPage.Navigation.PushAsync(page, true);
            }
            finally
            {
                
            }
        }
        
        public static async Task PushModalAsync<T>(params object?[]? parameter)
        {
            try
            {
                var pageType = typeof(T);
                var page = (ContentPage)Activator.CreateInstance(pageType, parameter);
                await Application.Current!.MainPage.Navigation.PushModalAsync(page, true);
            }
            finally
            {
                
            }
        }

        public static async Task PopAsync(bool animated = true)
        {
            await Application.Current!.MainPage.Navigation.PopAsync(animated);
        }
        
        /* POPUPS FUNCTION */

        public static async Task PushPopupAsync(PopupPage popup, bool animated = true)
        {
            await Application.Current!.MainPage.Navigation.PushPopupAsync(popup, animated);
        }

        public static async Task PopPopupAsync(bool animated = true)
        {
            await Application.Current!.MainPage.Navigation.PopPopupAsync(animated);
        }

        
        /* SHELL FUNCTION */
        
        public static async Task GoToAsync(ShellNavigationState state, bool animate = true)
        {
            await Shell.Current.GoToAsync(state, animate);
        }
        
        public static async Task GoBackAsync(bool animate = true)
        {
            await Shell.Current.GoToAsync("..", animate);
        }


        public static void SetMainPage(Page page)
        {
            Application.Current!.MainPage = page;
        }
    }
}
