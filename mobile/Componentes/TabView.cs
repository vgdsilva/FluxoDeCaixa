using FluxoDeCaixa.MAUI.Core.Utils.ResoucesExtencions;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace FluxoDeCaixa.MAUI.Componentes { 

    public class TabView : DevExpress.Maui.Controls.TabView
    {
        public static readonly BindableProperty ItemHeaderTappedCommandProperty =
                BindableProperty.Create(
                    nameof(ItemHeaderTappedCommand),
                    typeof(ICommand),
                    typeof(TabView));

        public ICommand ItemHeaderTappedCommand
        {
            get => (ICommand)GetValue(ItemHeaderTappedCommandProperty);
            set => SetValue(ItemHeaderTappedCommandProperty, value);
        }

        public TabView()
        {
            ItemHeaderTapped += TabView_ItemHeaderTapped;
            ItemHeaderTextColor = (Color)ResourceUtils.GetResourceValue("ColorGray700");
            HeaderPanelShadowColor = (Color)ResourceUtils.GetResourceValue("ColorGray200");
            HeaderPanelShadowHeight = 1;

            SelectedItemHeaderTextColor = (Color)ResourceUtils.GetResourceValue("Primary600");
            SelectedItemIndicatorHeight = 2;
            SelectedItemIndicatorColor = (Color)ResourceUtils.GetResourceValue("Primary500");

            ItemHeaderFontFamily = "Quicksand600Font";
        }

        private void TabView_ItemHeaderTapped(object sender, DevExpress.Maui.Controls.ItemHeaderTappedEventArgs e)
        {
            if (ItemHeaderTappedCommand?.CanExecute(e.Index) ?? false)
                ItemHeaderTappedCommand.Execute(e.Index);
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName.Equals(nameof(SelectedItemIndex)))
            {
                if (ItemHeaderTappedCommand?.CanExecute(SelectedItemIndex) ?? false)
                    ItemHeaderTappedCommand.Execute(SelectedItemIndex);
            }
        }
    }

    public class TabViewItem : DevExpress.Maui.Controls.TabViewItem { }
}

