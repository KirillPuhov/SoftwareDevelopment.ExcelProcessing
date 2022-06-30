using AppUX.Theme.Window;

namespace AppUX.Control.Window
{
    public partial class TextDialog : RayeWindow
    {
        public string Header { get; set; }
        public string Body { get; set; }

        public TextDialog(string header, string body)
        {
            InitializeComponent();

            this.Header = header;
            this.Body = body;
        }
    }
}
