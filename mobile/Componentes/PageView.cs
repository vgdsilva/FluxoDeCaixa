using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.MAUI.Componentes
{
    public abstract partial class PageView : ContentPage
    {

        protected PageView()
        {
            Content = Body();
        }

        protected abstract View Body();

    }
}
