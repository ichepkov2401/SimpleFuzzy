using MetroFramework.Forms;

namespace SimpleFuzzy.View
{
    public partial class HelpWindow : MetroForm
    {
        MainWindow window;
        public HelpWindow(MainWindow mainWindow)
        {
            window = mainWindow;
            InitializeComponent();
        }
    }
}