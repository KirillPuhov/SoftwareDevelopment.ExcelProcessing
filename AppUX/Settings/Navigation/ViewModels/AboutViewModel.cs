using AppUX.Settings.Navigation.Utils;

namespace AppUX.Settings.Navigation.ViewModels
{
    public class AboutViewModel : ViewModelBase, INavigationAware
    {
        #region Fields

        private readonly INavigationManager _navigationManager;

        #endregion

        #region Ctor

        public AboutViewModel(INavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }

        #endregion

        #region NavigationAware

        public void OnNavigatingFrom() { }

        public void OnNavigatingTo(object arg) { }

        #endregion
    }
}
