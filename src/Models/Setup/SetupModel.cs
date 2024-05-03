using CommunityToolkit.Mvvm.ComponentModel;
using FluxoDeCaixa.Mobile.Core.Domain.Constants;
using FluxoDeCaixa.Mobile.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Mobile.Models.Setup;
public partial class SetupModel : BaseModels
{
    [ObservableProperty]
    string alias = string.Empty;

    [ObservableProperty]
    Coin currentCurrancy = Currency.REAL();

    [ObservableProperty]
    decimal currentAmount = 0;


    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsApresentation))]
    [NotifyPropertyChangedFor(nameof(IsStartLogin))]
    SetupView screenType;


    public bool IsApresentation => ScreenType == SetupView.Apresentation;
    public bool IsStartLogin => ScreenType == SetupView.StartLogin;

    public SetupModel()
    {
        ScreenType = SetupView.Apresentation;
    }
}

public enum SetupView
{
    Apresentation = 0,
    StartLogin = 1,
}
