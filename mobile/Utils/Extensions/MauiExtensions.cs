using System.Linq;
using System.Reflection;

namespace FluxoDeCaixa.MAUI
{
    public static class MauiExtensions
    {
        public static bool IsNullOrEmpty(this string String)
        {
            return String == null || string.IsNullOrEmpty(String.Trim());
        }

        /// <summary>
        /// Obtém o valor de determinada propriedade do objeto recebido.
        /// </summary>
        /// <param name="entity">Entidade da qual será obtido o valor</param>
        /// <param name="propertyInfoObject">Campo da entidade</param>
        /// <returns>Valor de retorno</returns>
        public static object GetPropertyValue(this object entity,
                                              string propertyName, bool withFullPath = false)
        {
            if (propertyName.IsNullOrEmpty()) return null;


            if (propertyName.Contains("."))
            {
                if (withFullPath)
                    return GetValueByPath(entity, propertyName);

                var propriedades = propertyName.Split('.').Where(x => x != propertyName.Split('.').First()).ToList();
                object valor = entity;
                foreach (var item in propriedades)
                {
                    PropertyInfo p = valor.GetType().GetProperty(item);
                    valor = p.GetValue(valor);
                }
                return valor;
            }

            PropertyInfo propertyinfo = entity.GetType().GetProperty(propertyName);

            return propertyinfo?.GetValue(entity);
        }

        private static object GetValueByPath(object obj, string path)
        {
            var parts = path.Split('.');
            foreach (var part in parts)
            {
                if (obj == null)
                    return null;

                //if (parts.IndexOf(part) == 0)
                //    continue;

                if (part.Contains("["))
                {
                    // Se a parte contém [ e ], trata-se de uma lista
                    var propName = part.Substring(0, part.IndexOf("["));
                    var index = int.Parse(part
                        .Substring(part.IndexOf("[") + 1, part.IndexOf("]") - part.IndexOf("[") - 1));

                    var prop = obj.GetType().GetProperty(propName);
                    if (prop == null)
                        return null;

                    obj = prop.GetValue(obj);

                    if (obj is IEnumerable<object> enumerable)
                    {
                        obj = enumerable.ElementAtOrDefault(index);
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    // Caso contrário, trata-se de uma propriedade simples
                    var prop = obj.GetType().GetProperty(part);
                    if (prop == null)
                        return null;

                    obj = prop.GetValue(obj);
                }
            }

            return obj;
        }


        public static bool HasProperty(this object objectToCheck, string methodName)
        {
            var type = objectToCheck.GetType();
            return type.GetProperty(methodName) != null;
        }
    }

    public static class ViewsExtencions
    {
        public static View verticalOptions(this View view, LayoutOptions layout)
        {
            view.VerticalOptions = layout;
            return view;
        }

        public static View horizontalOptions(this View view, LayoutOptions layout)
        {
            view.HorizontalOptions = layout;
            return view;
        }

        public static View GridRow(this View view, int row)
        {
            Grid.SetRow(view, row);
            return view;
        }

        public static View column(this View view, int column)
        {
            Grid.SetColumn(view, column);
            return view;
        }

        public static View margin(this View View, int left = 0, int top = 0, int right = 0, int bottom = 0)
        {
            View.Margin = new Thickness(left, top, right, bottom);
            return View;
        }

        public static View margin(this View View, int horizontalSize = 0, int verticalSize = 0)
        {
            View.Margin = new Thickness(horizontalSize, verticalSize);
            return View;
        }

        public static View margin(this View View, int uniformSize = 0)
        {
            View.Margin = new Thickness(uniformSize);
            return View;
        }
    }

    public static class LayoutExtensions
    {
        public static Layout padding(this Layout layout, int left = 0, int top = 0, int right = 0, int bottom = 0)
        {
            layout.Padding = new Thickness(left, top, right, bottom);
            return layout;
        }

        public static Layout padding(this Layout layout, int horizontalSize = 0, int verticalSize = 0)
        {
            layout.Padding = new Thickness(horizontalSize, verticalSize);
            return layout;
        }

        public static Layout Padding(this Layout layout, int uniformSize = 0)
        {
            layout.Padding = new Thickness(uniformSize);
            return layout;
        }
    }

    public static class GridExtensions
    {
        public static Grid RowDefinition(this Grid grid, GridLength height)
        {
            if (grid.RowDefinitions == null)
                grid.RowDefinitions = new RowDefinitionCollection();

            grid.RowDefinitions.Add(new RowDefinition(height));

            return grid;
        }
        
        public static Grid RowDefinition(this Grid grid, params GridLength[] heights)
        {
            if (grid.RowDefinitions == null)
                grid.RowDefinitions = new RowDefinitionCollection();

            foreach (var height in heights)
                grid.RowDefinitions.Add(new RowDefinition(height));

            return grid;
        }
        
        public static Grid columnDefinition(this Grid grid, GridLength width)
        {
            if (grid.ColumnDefinitions == null)
                grid.ColumnDefinitions = new ColumnDefinitionCollection();

            grid.ColumnDefinitions.Add(new ColumnDefinition(width));

            return grid;
        }

        public static Layout BackgroundColor(this Layout grid, Color backgroundColor)
        {
            grid.BackgroundColor = backgroundColor;
            return grid;
        }

        //public static Grid padding(this Grid grid, int left = 0, int top = 0, int right = 0, int bottom = 0)
        //{
        //    grid.Padding = new Thickness(left, top, right, bottom);
        //    return grid;
        //}

        //public static Grid padding(this Grid grid, int horizontalSize = 0, int verticalSize = 0)
        //{
        //    grid.Padding = new Thickness(horizontalSize, verticalSize);
        //    return grid;
        //}

        //public static Grid padding(this Grid grid, int uniformSize = 0)
        //{
        //    grid.Padding = new Thickness(uniformSize);
        //    return grid;
        //}
        
        



        public static Grid margin(this Grid grid, int left = 0, int top = 0, int right = 0, int bottom = 0)
        {
            grid.Margin = new Thickness(left, top, right, bottom);
            return grid;
        }

        public static Grid margin(this Grid grid, int horizontalSize = 0, int verticalSize = 0)
        {
            grid.Margin = new Thickness(horizontalSize, verticalSize);
            return grid;
        }

        public static Grid margin(this Grid grid, int uniformSize = 0)
        {
            grid.Margin = new Thickness(uniformSize);
            return grid;
        }
    }

    public static class LabelExtencions
    {
        public static Label Text(this Label label, string text)
        {
            label.Text = text;
            return label;
        }

        public static Label TextColor(this Label label, Color color)
        {
            label.TextColor = color;
            return label;
        }

        public static Label TextAlignment(this Label label, TextAlignment alignment, StackOrientation orientation)
        {
            switch (orientation)
            {
                case StackOrientation.Vertical: label.VerticalTextAlignment = alignment;
                    break;
                case StackOrientation.Horizontal: label.HorizontalTextAlignment = alignment;
                    break;
                default:
                    break;
            }
            return label;
        }

        public static Label lineBreakMode(this Label label, LineBreakMode mode)
        {
            label.LineBreakMode = mode;
            return label;
        }

        public static Label margin(this Label label, int left = 0, int top = 0, int right = 0, int bottom = 0)
        {
            label.Margin = new Thickness(left, top, right, bottom);
            return label;
        }

        public static Label padding(this Label label, int left = 0, int top = 0, int right = 0, int bottom = 0)
        {
            label.Padding = new Thickness(left, top, right, bottom);
            return label;
        }

        public static Label FontSize(this Label label, int fontSize)
        {
            label.FontSize = fontSize;
            return label;
        }

        public static Label fontFamily(this Label label, string font)
        {
            label.FontFamily = font;
            return label;
        }

        
    }
}
