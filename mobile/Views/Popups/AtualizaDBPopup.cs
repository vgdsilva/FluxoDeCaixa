using RGPopup.Maui.Pages;

namespace FluxoDeCaixa.MAUI.Views.Popups;

public class AtualizaDBPopup : PopupPage
{
	public AtualizaDBPopup()
	{
		Content = Body();
	}

	View Body() =>
		new StackLayout
		{
			new ActivityIndicator()
				.color(Color.FromArgb("#00875F"))
				.horizontalOptions(LayoutOptions.CenterAndExpand)
				.verticalOptions(LayoutOptions.CenterAndExpand),
			new Label()
				.text("Atualizando o banco de dados do aplicativo")
				.fontSize(18)
				.fontFamily("Quicksand600Font")
		}
		.horizontalOptions(LayoutOptions.CenterAndExpand)
		.verticalOptions(LayoutOptions.CenterAndExpand);
}