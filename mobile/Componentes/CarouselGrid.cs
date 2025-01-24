using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.MAUI.Componentes
{
    public class CarouselGrid : Grid
    {
        // Propriedade para controlar a visibilidade do IndicatorView
        public static readonly BindableProperty ShowIndicatorProperty =
            BindableProperty.Create(
                nameof(ShowIndicator),
                typeof(bool),
                typeof(CarouselGrid),
                true,
                propertyChanged: OnShowIndicatorChanged);

        // Propriedade ItemsSource para o CarouselView
        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(
                nameof(ItemsSource),
                typeof(IEnumerable),
                typeof(CarouselGrid),
                null,
                propertyChanged: OnItemsSourceChanged);

        // Propriedade ItemTemplate para o CarouselView
        public static readonly BindableProperty ItemTemplateProperty =
            BindableProperty.Create(
                nameof(ItemTemplate),
                typeof(DataTemplate),
                typeof(CarouselGrid),
                null,
                propertyChanged: OnItemTemplateChanged);

        // CarouselView e IndicatorView internos
        private readonly CarouselView _carouselView;
        private readonly IndicatorView _indicatorView;

        public CarouselGrid()
        {
            RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
            RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            RowSpacing = 26;

            _carouselView = new CarouselView();
            _indicatorView = new IndicatorView { IsVisible = ShowIndicator };
            _indicatorView.IndicatorColor = Color.FromArgb("#EEEEEE");
            _indicatorView.SelectedIndicatorColor = Color.FromArgb("#5BAF00");

            _carouselView.IndicatorView = _indicatorView;

            // Adiciona os componentes à Grid
            Children.Add(_carouselView);
            Grid.SetRow(_carouselView, 0);

            Children.Add(_indicatorView);
            Grid.SetRow(_indicatorView, 1);
        }

        public bool ShowIndicator
        {
            get => (bool)GetValue(ShowIndicatorProperty);
            set => SetValue(ShowIndicatorProperty, value);
        }

        public IEnumerable ItemsSource
        {
            get => (IEnumerable)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public DataTemplate ItemTemplate
        {
            get => (DataTemplate)GetValue(ItemTemplateProperty);
            set => SetValue(ItemTemplateProperty, value);
        }

        private static void OnShowIndicatorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is null)
                return;

            if (bindable is CarouselGrid carouselGrid && newValue is bool isVisible)
            {
                carouselGrid._indicatorView.IsVisible = isVisible;
            }
        }

        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is null)
                return;

            if (bindable is CarouselGrid carouselGrid)
            {
                carouselGrid._carouselView.ItemsSource = newValue as IEnumerable;
            }
        }

        private static void OnItemTemplateChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is null)
                return;

            if (bindable is CarouselGrid carouselGrid && newValue is DataTemplate template)
            {
                carouselGrid._carouselView.ItemTemplate = template;
            }
        }
    }
}
