using AppUX.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace AppUX.Control.Window
{
    public partial class FilterDialogVertical : UserControl
    {
        public static readonly DependencyProperty HeaderContentProperty = DependencyProperty.Register("HeaderContent", typeof(string), typeof(FilterDialogVertical));
        public string HeaderContent
        {
            get { return (string)GetValue(HeaderContentProperty); }
            set { SetValue(HeaderContentProperty, value); }
        }

        public static readonly DependencyProperty ListBoxContentProperty = DependencyProperty.Register("ListBoxContent", typeof(ObservableCollection<string>), typeof(FilterDialogVertical));
        public ObservableCollection<string> ListBoxContent
        {
            get { return (ObservableCollection<string>)GetValue(ListBoxContentProperty); }
            set { SetValue(ListBoxContentProperty, value); }
        }


        public static readonly DependencyProperty ColumnSelectedProperty = DependencyProperty.Register("ColumnSelected", typeof(string), typeof(FilterDialogVertical));
        public string ColumnSelected
        {
            get { return (string)GetValue(ColumnSelectedProperty); }
            set { SetValue(ColumnSelectedProperty, value); }
        }

        public static readonly DependencyProperty FilterBoxProperty = DependencyProperty.Register("FilterBox", typeof(string), typeof(FilterDialogVertical)); 
        public string FilterBox
        {
            get { return (string)GetValue(FilterBoxProperty); }
            set { SetValue(FilterBoxProperty, value); }
        }

        public static readonly DependencyProperty ButtonCommandProperty = DependencyProperty.Register("ButtonCommand", typeof(RelayCommand), typeof(FilterDialogVertical));
        public RelayCommand ButtonCommand
        {
            get { return (RelayCommand)GetValue(ButtonCommandProperty); }
            set { SetValue(ButtonCommandProperty, value); }
        }

        public static readonly DependencyProperty SortModeArrayProperty = DependencyProperty.Register("SortMode", typeof(bool[]), typeof(FilterDialogVertical));
        public bool[] SortMode
        {
            get { return (bool[])GetValue(SortModeArrayProperty); }
            set { SetValue(SortModeArrayProperty, value); }
        }

        public FilterDialogVertical()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if(content.Visibility == Visibility.Hidden)
            {
                content.Visibility = Visibility.Visible;
            }
            else
            {
                content.Visibility = Visibility.Hidden;
            }
                
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            ColumnSelected = string.Empty;
            FilterBox = string.Empty;
            filterBox.Text = string.Empty;
            SortMode = new bool[] { true, false };

            ButtonCommand.Execute(null);

            if (content.Visibility == Visibility.Visible)
                content.Visibility = Visibility.Hidden;
        }

        private void apply_Click(object sender, RoutedEventArgs e)
        {
            ButtonCommand.Execute(null);

            if (content.Visibility == Visibility.Visible)
                content.Visibility = Visibility.Hidden;
        }
    }
}
