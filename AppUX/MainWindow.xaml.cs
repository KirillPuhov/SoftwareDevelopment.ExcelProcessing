using AppUX.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using AppUX.Animations.Methods;
using AppUX.Settings;
using AppUX.Settings.Navigation.Utils;
using AppUX.Settings.Navigation.ViewModels;
using AppUX.Settings.Navigation.Pages;

namespace AppUX
{
    public partial class MainWindow : Window
    {
        #region Fields

        private readonly MainViewModel _viewModel = new MainViewModel();

        private readonly GridAnimation _animator = new GridAnimation();

        #endregion

        #region Ctor

        public MainWindow()
        {
            InitializeComponent();
            DataContext = _viewModel;
        }

        #endregion

        #region Filter

        private void Filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            _viewModel.Filter = FilterBox.Text;
            _viewModel.FilterCommand.Execute(null);
        }

        #endregion

        #region Animations

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new SettingsWindow();
            var navigationManager = new NavigationManager(Dispatcher, window.FrameContent);

            var viewModel = new SettingsViewModel(navigationManager);
            window.DataContext = viewModel;

            navigationManager.Register<LanguageViewModel, LanguageView>(new LanguageViewModel(navigationManager), "LanguagePage");
            navigationManager.Register<ThemeViewModel, ThemeView>(new ThemeViewModel(navigationManager), "ThemePage");
            navigationManager.Register<FileViewModel, FileView>(new FileViewModel(navigationManager), "FilePage");
            navigationManager.Register<AboutViewModel, AboutView>(new AboutViewModel(navigationManager), "AboutPage");
            navigationManager.Navigate("AboutPage");

            window.Owner = this;
            window.Show();
        }

        private void FilterOpenButton_Click(object sender, RoutedEventArgs e)
        {
            _animator.DoubleAnimationShow(0, 1, 0.3, Filter);
        }

        private void FilterBackButton_Click(object sender, RoutedEventArgs e)
        {
            _animator.DoubleAnimationHide(1, 0, 0.3, Filter);
        }

        #endregion

        #region AutoGeneratingColumn

        private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType == typeof(DateTime))
                (e.Column as DataGridTextColumn).Binding.StringFormat = "dd.MM.yyyy";
        }

        #endregion
    }
}
