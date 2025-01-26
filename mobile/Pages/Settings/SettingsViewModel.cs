using FluxoDeCaixa.MAUI.Pages.Base;
using FluxoDeCaixa.MAUI.Pages.Category;
using FluxoDeCaixa.MAUI.Utils.Classes;

namespace FluxoDeCaixa.MAUI.Pages.Settings
{
    public partial class SettingsViewModel : BaseViewModels
    {


        [RelayCommand]
        async Task AddCategory()
        {
            await NavigationUtils.GoToAsync(nameof(CategoryPage));
        }
    }
}
