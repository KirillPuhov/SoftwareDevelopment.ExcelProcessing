using System.Windows.Threading;

namespace AppUX.Services
{
    public interface IDialogService
    {
        void ShowError(string error);

        void ShowInfo(string info);

        bool OpenFileDialog();

        string FilePath { get; set; }

        bool OpenSettingsWindow();

        bool OpenGraphWindow();

    }
}
