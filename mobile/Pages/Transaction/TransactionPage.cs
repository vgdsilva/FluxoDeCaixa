using FluxoDeCaixa.MAUI.Layouts;
using FluxoDeCaixa.MAUI.Pages.Base;

namespace FluxoDeCaixa.MAUI.Pages.Transaction
{
    public partial class TransactionPage : BasePages<BaseViewModels>
    {
        protected override View Body() =>
            new FormLayout();
    }
    
    
}
