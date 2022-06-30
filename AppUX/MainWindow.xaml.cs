using AppUX.ViewModel;
using AppUX.Services;
using AppUX.Theme.Window;

namespace AppUX
{
    public partial class MainWindow : RayeWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel(new DialogService(this), new ValidationService(), new FilterService());
        }
    }
}
