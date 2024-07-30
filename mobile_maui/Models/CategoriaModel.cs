using CommunityToolkit.Mvvm.ComponentModel;
using FluxoDeCaixa.Mobile.Core.Utils.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Mobile.Domain.Models;
public partial class CategoriaModel : ObservableValidator
{
    [ObservableProperty]
    string iDCategoria;

    [ObservableProperty]
    string descricao;

    public CategoriaModel()
    {
        IDCategoria = DataUtils.Empty();
        Descricao = "";
    }
}
