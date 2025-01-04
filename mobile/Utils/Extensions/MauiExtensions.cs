namespace FluxoDeCaixa.MAUI
{
    public static class MauiExtensions
    {

        

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

        public static View row(this View view, int row)
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

        public static Layout padding(this Layout layout, int uniformSize = 0)
        {
            layout.Padding = new Thickness(uniformSize);
            return layout;
        }
    }

    public static class GridExtensions
    {
        public static Grid rowDefinition(this Grid grid, GridLength height)
        {
            if (grid.RowDefinitions == null)
                grid.RowDefinitions = new RowDefinitionCollection();

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

        public static Layout backgroundColor(this Layout grid, Color backgroundColor)
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
        public static Label text(this Label label, string text)
        {
            label.Text = text;
            return label;
        }

        public static Label textColor(this Label label, Color color)
        {
            label.TextColor = color;
            return label;
        }

        public static Label textAlignment(this Label label, TextAlignment alignment, StackOrientation orientation)
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

        public static Label fontSize(this Label label, int fontSize)
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
