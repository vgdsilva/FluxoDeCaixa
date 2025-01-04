using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.MAUI.Resources.Styles
{
    public class AppStyles
    {
        public static Style GridForm() =>
            new StyleBuilder<Grid>()
                .SetProperty(Grid.RowDefinitionsProperty, new RowDefinitionCollection(new RowDefinition(GridLength.Star), new RowDefinition(GridLength.Auto)))
                .SetProperty(Grid.BackgroundColorProperty, Colors.White)
                .ToStyle();
    }

    public class StyleBuilder<T> where T : BindableObject
    {
        private readonly Style _style;
        public StyleBuilder()
        {
            _style = new Style(typeof(T));
        }

        public StyleBuilder<T> SetProperty(BindableProperty property, object value)
        {
            _style.Setters.Add(new Setter
            {
                Property = property,
                Value = value
            });

            return this;
        }

        public StyleBuilder<T> BasedOn(Style baseStyle)
        {
            _style.BasedOn = baseStyle;
            return this;
        }

        public Style ToStyle()
        {
            return _style;
        }
    }
}
