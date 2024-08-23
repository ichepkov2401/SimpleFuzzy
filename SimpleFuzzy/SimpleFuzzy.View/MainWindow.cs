using MetroFramework.Forms;
using System.IO;
using System.Runtime.Loader;
using SimpleFuzzy.Abstract;

namespace SimpleFuzzy.View
{
    public delegate UserControl ControlConstruct();
    public partial class MainWindow : Form
    {
        Dictionary<UserControlsEnum, ControlConstruct> UserControls = new Dictionary<UserControlsEnum, ControlConstruct>();
        public UserControl currentControl = null;
        IProjectListService projectList;
        IRepositoryService repositoryService;
        private ToolStripMenuItem[] workspaceButtons;
        bool IsShownToolTip1 = true;
        public bool isContainSimulator = false;
        public MainWindow()
        {
            InitializeComponent();
            projectList = AutofacIntegration.GetInstance<IProjectListService>();
            repositoryService = AutofacIntegration.GetInstance<IRepositoryService>();
            // Инициализация массива кнопок рабочего пространства
            workspaceButtons = new ToolStripMenuItem[] { button7, button8, button9, button10, button11 };

            UserControls.Add(UserControlsEnum.Create, () => new ConfirmCreate());
            UserControls.Add(UserControlsEnum.Open, () => new ConfirmOpen());
            UserControls.Add(UserControlsEnum.Delete, () => new ConfirmDelete());
            UserControls.Add(UserControlsEnum.Rename, () => new ConfirmRename());
            UserControls.Add(UserControlsEnum.Copy, () => new ConfirmSaveAs());
            UserControls.Add(UserControlsEnum.Loader, () => new LoaderForm());
            UserControls.Add(UserControlsEnum.Fasification, () => new FasificationForm());
            UserControls.Add(UserControlsEnum.Inference, () => new InferenceForm());
            UserControls.Add(UserControlsEnum.Defasification, () => new DefasificationForm());
            UserControls.Add(UserControlsEnum.Simulation, () => AddSimulation());

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            Locked();
            timer1.Start();
        }

        private UserControl AddSimulation()
        {
            ISimulator simulator = repositoryService.GetCollection<ISimulator>().FirstOrDefault(t => t.Active);
            if (simulator != null) 
            {
                return simulator.GetVisualObject() as UserControl;
            }
            throw new Exception("Нет активной симуляции");
        }

        public void ChangeNameOfProject()
        {
            if (projectList.CurrentProjectName != null) metroLabel1.Text = "Имя текущего проекта: " + projectList.CurrentProjectName;
            else metroLabel1.Text = "";
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
            projectList.SaveAll();
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
                currentControl.Location = new Point(932 / 2 - currentControl.Width / 2, 120);
                currentControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                currentControl.Size = new Size(currentControl.Width + Width - 932, currentControl.Height + Height - 647);
                toRemove.Controls.Add(currentControl);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            HelpWindow help = new HelpWindow();
            help.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var v = new Point(MousePosition.X - (Location.X + menuStrip2.Location.X + button11.Bounds.Location.X),
                MousePosition.Y - (Location.Y + menuStrip2.Location.Y + button11.Bounds.Location.Y));
            if (v.X >= 0 && v.X <= button11.Width && v.Y >= 0 && v.Y <= button11.Height)
            {
                if (!IsShownToolTip1 && projectList.CurrentProjectName != null && !isContainSimulator)
                {
                    toolTip1.Show("Симуляция не загружена в проект или отключена в окне загрузчика", menuStrip2);
                    IsShownToolTip1 = true;
                }
            }
            else
            {
                if (IsShownToolTip1)
                {
                    toolTip1.Hide(menuStrip2);
                    IsShownToolTip1 = false;
                }
            }
        }
    }
}