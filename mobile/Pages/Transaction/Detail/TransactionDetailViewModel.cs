using FluxoDeCaixa.Domain.Entities;
using FluxoDeCaixa.Domain.Mappings;
using FluxoDeCaixa.MAUI.Core.Utils.Classes;
using FluxoDeCaixa.MAUI.Pages.Base;

namespace FluxoDeCaixa.MAUI.Pages.Transaction.Detail;

public partial class TransactionDetailViewModel : BaseViewModels
{
    [ObservableProperty]
    TransactionDetailModel model;

    public TransactionDetailViewModel()
    {
        Model = new();
    }

    public override async void Init()
    {
        base.Init();

        if (!string.IsNullOrEmpty(Id))
        {
            Transacao currentEntity = await Controller.TransactionRepository.GetByIdAsync(Guid.Parse(Id));
            Model = new Mapper().Map<Transacao, TransactionDetailModel>(currentEntity);
        }
    }


    [RelayCommand]
    async Task Salvar() =>
        await Execute.Task(async () =>
        {
            if (!ValidateForm("FormGrid", true))
                return;
            
            var entity = new Mapper().Map<TransactionDetailModel, Transacao>(model);

            await Controller.TransactionRepository.SaveAsync(entity);
        });
}
