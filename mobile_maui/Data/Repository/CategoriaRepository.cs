using FluxoDeCaixa.Mobile.Core.Utils.Classes;
using FluxoDeCaixa.Mobile.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Mobile.Data.Repository;

public class CategoriaRepository
{
    static CategoriaRepository _instanse;

    public static CategoriaRepository Singleton
    {
        get
        {
            return _instanse ?? new CategoriaRepository();
        }
    }

    public async Task SaveChangesAsync(Categoria entity)
    {
        if (entity.IDCategoria == DataUtils.Empty())
            entity.IDCategoria = DataUtils.NewID();

        List<Categoria> list = JsonConvert.DeserializeObject<List<Categoria>>(Preferences.Get(nameof(Categoria), "")) ?? new List<Categoria>();
        list.Add(entity);
        Preferences.Set(nameof(Categoria), JsonConvert.SerializeObject(list));
    }
}
