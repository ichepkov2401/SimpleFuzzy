using MetroFramework.Forms;
using SimpleFuzzy.Abstract;

namespace SimpleFuzzy.View
{
    public delegate UserControl ControlConstruct();
    public partial class MainWindow : MetroForm
    {
        Dictionary<UserControlsEnum, ControlConstruct> UserControls = new Dictionary<UserControlsEnum, ControlConstruct>();
        public UserControl currentControl = null;
        IProjectListService projectList;
        private ToolStripMenuItem[] workspaceButtons;
        bool IsShownToolTip1 = true;
        public bool isContainSimulator = false;
        public MainWindow()
        {
            InitializeComponent();
            projectList = AutofacIntegration.GetInstance<IProjectListService>();

            // Инициализация массива кнопок рабочего пространства
            workspaceButtons = new ToolStripMenuItem[] { button7, button8, button9, button10, button11 };

            UserControls.Add(UserControlsEnum.Create, () => new ConfirmCreate());
            UserControls.Add(UserControlsEnum.Open, () => new ConfirmOpen());
            UserControls.Add(UserControlsEnum.Delete, () => new ConfirmDelete());
            UserControls.Add(UserControlsEnum.Rename, () => new ConfirmRename());
            UserControls.Add(UserControlsEnum.Copy, () => new ConfirmCopy());
            UserControls.Add(UserControlsEnum.Loader, () => new LoaderForm());
            UserControls.Add(UserControlsEnum.Fasification, () => new FasificationForm());
            UserControls.Add(UserControlsEnum.Inference, () => new InferenceForm());
            UserControls.Add(UserControlsEnum.Defasification, () => new DefasificationForm());
            UserControls.Add(UserControlsEnum.Simulation, () => new SimulationForm());

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            Locked();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SwichUserControl(UserControlsEnum.Create);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SwichUserControl(UserControlsEnum.Open);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SwichUserControl(UserControlsEnum.Delete);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SwichUserControl(UserControlsEnum.Rename);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SwichUserControl(UserControlsEnum.Copy);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // сохранение
        }
        private void button7_Click(object sender, EventArgs e)
        {
            SwitchWorkspace(UserControlsEnum.Loader, button7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SwitchWorkspace(UserControlsEnum.Fasification, button8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SwitchWorkspace(UserControlsEnum.Inference, button9);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SwitchWorkspace(UserControlsEnum.Defasification, button10);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SwitchWorkspace(UserControlsEnum.Simulation, button11);
        }
        public void OpenLoader()
        {
            SwitchWorkspace(UserControlsEnum.Loader, button7);
        }
        private void button12_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();

        }
        private void SwitchWorkspace(UserControlsEnum workspace, ToolStripMenuItem clickedButton)
        {
            foreach (var item in workspaceButtons) { item.Enabled = true; }
            clickedButton.Enabled = false;
            if (!isContainSimulator) button11.Enabled = false;
            SwichUserControl(workspace);
        }
        public void Locked()
        {
            if (projectList.CurrentProjectName == null)
            {
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
                button10.Enabled = false;
                button11.Enabled = false;
            }
            else
            {
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
                if (isContainSimulator) button11.Enabled = true;
            }
        }
        public void BlockButtons()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;
        }
        public void OpenButtons()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            if (isContainSimulator) button11.Enabled = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void EnableSimulationsButton(bool enable)
        {
            this.button11.Enabled = enable;
        }

        public void SwichUserControl(UserControlsEnum? newWindowName)
        {
            var toRemove = this;
            if (currentControl != null)
            {
                toRemove.Controls.Remove(currentControl);
                currentControl.Dispose();
            }
            if (newWindowName.HasValue)
            {
                currentControl = UserControls[newWindowName.Value]();
                toRemove.Controls.Add(currentControl);
                currentControl.Location = new Point(0, 120);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            HelpWindow help = new HelpWindow(this);
            help.Show();
        }


        // Так как нынешний MoveMouse не может обрабатывать объекты типа ToolScriptItem, в этой сборке было решено адаптировать метод MouseMove
        private void MainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            // Находим элемент меню, над которым находится курсор
            ToolStripItem item = menuStrip2.GetItemAt(menuStrip2.PointToClient(MousePosition));

            if (item != null && item == button11)
            {
                if (!IsShownToolTip1 && projectList.CurrentProjectName != null && !isContainSimulator)
                {
                    button11.ToolTipText = "Симуляция не загружена в проект или отключена в окне загрузчика";
                    IsShownToolTip1 = true;
                }
            }
            else
            {
                if (IsShownToolTip1)
                {
                    button11.ToolTipText = "";
                    IsShownToolTip1 = false;
                }
            }
        }
    }
}