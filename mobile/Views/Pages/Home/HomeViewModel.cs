using FluxoDeCaixa.Data.Repositories;
using FluxoDeCaixa.MAUI.Core.Utils.Classes;
using FluxoDeCaixa.MAUI.Views.Pages.Base;

namespace FluxoDeCaixa.MAUI.Views.Pages.Home;

public partial class HomeViewModel : BaseViewModels
{
    [ObservableProperty]
    HomeModel model;


    public HomeViewModel()
    {
        Model = new ();
    }

    public override async Task Init()
    {
        await VerificaDatabase();

        await CarregarTransacoes();
    }

    private async Task CarregarTransacoes()
    {
        await Execute.TaskWithLoading(async () =>
        {
            await Task.Delay(1500);

            MockDataGenerator.GerarTransacoes(5, DateTime.Now);

            Model.LoadData(TransasaoRepository.Transacoes);

            await Task.Delay(500);
        });
    }

    private async Task VerificaDatabase()
    {

    }
}
