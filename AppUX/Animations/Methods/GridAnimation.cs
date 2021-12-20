using AppUX.Animations.Interfaces;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace AppUX.Animations.Methods
{
    public class GridAnimation : IGridAnimation
    {
        public void DoubleAnimationHide<T>(double from, double to, double duration, T obj) where T : Grid
        {
            DoubleAnimation Fading = new DoubleAnimation();
            Fading.Completed += new EventHandler((s, e) => HideGrid(s, e, obj));
            Fading.From = from;
            Fading.To = to;
            Fading.Duration = TimeSpan.FromSeconds(duration);
            obj.BeginAnimation(Grid.OpacityProperty, Fading);
        }

        public void DoubleAnimationShow<T>(double from, double to, double duration, T obj) where T : Grid
        {
            ShowGrid(obj);

            DoubleAnimation Fading = new DoubleAnimation();
            Fading.From = from;
            Fading.To = to;
            Fading.Duration = TimeSpan.FromSeconds(duration);
            obj.BeginAnimation(Grid.OpacityProperty, Fading);
        }

        private void ShowGrid<T>(T obj) where T : Grid
        {
            obj.Visibility = Visibility.Visible;
            obj.Opacity = 1;
        }

        private void HideGrid<T>(object sender, EventArgs e, T obj) where T : Grid
        {
            obj.Visibility = Visibility.Hidden;
            obj.Opacity = 0;
        }
    }
}
