using System.Diagnostics;
using System.Windows.Controls;

namespace AppUX.Settings.Navigation.Pages
{
    public partial class AboutView : UserControl
    {
        public AboutView()
        {
            InitializeComponent();
        }

        private void Hyperlink1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Process.Start("https://github.com/KirillPuhov");
        }

        private void Hyperlink2_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Process.Start("https://github.com/xceedsoftware/DocX");
        }

        private void Hyperlink3_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Process.Start("https://github.com/EPPlusSoftware/EPPlus");
        }

        private void Hyperlink4_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Process.Start("https://github.com/ExcelDataReader/ExcelDataReader");

        }
    }
}
