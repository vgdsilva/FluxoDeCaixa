using FluxoDeCaixa.Mobile.Core.Utils.Classes;

namespace FluxoDeCaixa.Mobile.Domain.Entities
{
    public class Categoria
    {
        public string IDCategoria { get; set; } = DataUtils.Empty();
        public string Descricao { get; set; } = string.Empty;

    }
}
