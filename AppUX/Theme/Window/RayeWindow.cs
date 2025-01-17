﻿using AppUX.Control.Window;
using System.Windows;

namespace AppUX.Theme.Window
{
    public class RayeWindow : System.Windows.Window
    {

        public static readonly DependencyProperty HeaderIconProperty = DependencyProperty.Register("HeaderIcon", typeof(UIElement), typeof(RayeWindow));
        public UIElement HeaderIcon
        {
            get
            {
                return (UIElement)GetValue(HeaderIconProperty);
            }
            set
            {
                SetValue(HeaderIconProperty, value);
            }
        }

        public static readonly DependencyProperty HeaderContentProperty = DependencyProperty.Register("HeaderContent", typeof(object), typeof(RayeWindow));
        public object HeaderContent
        {
            get
            {
                return GetValue(HeaderContentProperty);
            }
            set
            {
                SetValue(HeaderContentProperty, value);
            }
        }

        public static readonly DependencyProperty IsHeaderTextVisibleProperty = DependencyProperty.Register("IsHeaderTextVisible", typeof(bool), typeof(RayeWindow), new PropertyMetadata(true));
        public bool IsHeaderTextVisible
        {
            get
            {
                return (bool)GetValue(IsHeaderTextVisibleProperty);
            }
            set
            {
                SetValue(IsHeaderTextVisibleProperty, value);
            }
        }

        public static readonly DependencyProperty MinimizeBoxProperty = DependencyProperty.Register("MinimizeBox", typeof(bool), typeof(RayeWindow), new PropertyMetadata(true));
        public bool MinimizeBox
        {
            get { return (bool)GetValue(MinimizeBoxProperty); }
            set { SetValue(MinimizeBoxProperty, value); }
        }

        public static readonly DependencyProperty MaximizeBoxProperty = DependencyProperty.Register("MaximizeBox", typeof(bool), typeof(RayeWindow), new PropertyMetadata(true));
        public bool MaximizeBox
        {
            get { return (bool)GetValue(MaximizeBoxProperty); }
            set { SetValue(MaximizeBoxProperty, value); }
        }

        public RayeWindow() : base()
        {
            base.Style = (Style)FindResource("RayeWindowStyle");
        }

        public override void OnApplyTemplate()
        {
            var windowControlBox = GetTemplateChild("WindowControlBox") as WindowControlBox;
            windowControlBox.OnMinimize = OnMinimize;
            windowControlBox.OnMaximize = OnMaximize;
            windowControlBox.OnClose = OnClose;

            base.OnApplyTemplate();
        }

        private void OnMinimize(object sender, RoutedEventArgs e)
        {
            base.WindowState = WindowState.Minimized;
        }

        private void OnMaximize(object sender, RoutedEventArgs e)
        {
            base.WindowState = base.WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
        }

        private void OnClose(object sender, RoutedEventArgs e)
        {
            base.Close();
        }

    }
}
