using FluxoDeCaixa.MAUI.Componentes;
using System.ComponentModel;

namespace FluxoDeCaixa.MAUI.Pages.Onboarding
{
    public partial class OnboardingPage : PageView
    {

        public OnboardingPage() : base()
        {
            
        }

        protected override View Body() =>
            new Grid
            {
                new Label()
                    .text("")
                    .textAlignment(TextAlignment.Center, StackOrientation.Horizontal)
                    .fontSize(24)
                    .textColor(Colors.Black)
                    .row(0)
            }
            .rowDefinition(208)
            .rowDefinition(GridLength.Star)
            .padding(24)
            .backgroundColor(Colors.White);
    }
}
