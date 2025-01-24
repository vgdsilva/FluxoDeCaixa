using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.MAUI.Componentes
{
    public class FontAwesomeLabel : Label
    {
        public FontAwesomeLabel()
        {
            FontFamily = "FontAwesomeSolid";
        }


        // Propriedade para definir o ícone.
        public string Icon
        {
            get => Text;
            set => Text = value;
        }
    }
}
