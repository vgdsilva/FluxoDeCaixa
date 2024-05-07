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



    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNameStage))]
    [NotifyPropertyChangedFor(nameof(IsCurrencyStage))]
    [NotifyPropertyChangedFor(nameof(IsAmmountStage))]
    [NotifyPropertyChangedFor(nameof(IsConfirmInfoStage))]
    StartLoginStage loginStage;

    public bool IsNameStage => LoginStage == StartLoginStage.Name;
    public bool IsCurrencyStage => LoginStage == StartLoginStage.Currency;
    public bool IsAmmountStage => LoginStage == StartLoginStage.Ammount;
    public bool IsConfirmInfoStage => LoginStage == StartLoginStage.ConfirmInfo;


    public SetupModel()
    {
        ScreenType = SetupView.Apresentation;
        LoginStage = StartLoginStage.Name;
    }
}

public enum SetupView
{
    Apresentation = 0,
    StartLogin = 1,
}

public enum StartLoginStage
{
    Name = 0,
    Currency = 1,
    Ammount = 2,
    ConfirmInfo = 3,
}
