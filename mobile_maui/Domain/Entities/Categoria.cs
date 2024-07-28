using FluxoDeCaixa.Mobile.Core.Utils.Classes;

namespace FluxoDeCaixa.Mobile.Domain.Entities
{
    public class Categoria
    {
        public string IDCategoria { get; set; } = DataUtils.Empty();
        public string Descricao { get; set; } = string.Empty;
        public int TipoCategoria { get; set; } = 0;
        public string Icon { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;

    }
}
