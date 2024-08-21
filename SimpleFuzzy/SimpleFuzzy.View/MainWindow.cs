using MetroFramework.Forms;
using System.IO;
using System.Runtime.Loader;
using SimpleFuzzy.Abstract;

namespace SimpleFuzzy.View
{
    public delegate UserControl ControlConstruct();
    public partial class MainWindow : MetroForm
    {
        Dictionary<UserControlsEnum, ControlConstruct> UserControls = new Dictionary<UserControlsEnum, ControlConstruct>();
        public UserControl currentControl = null;
        IProjectListService projectList;
        IRepositoryService repositoryService;
        private ToolStripMenuItem[] workspaceButtons;
        bool IsShownToolTip1 = false;
        bool IsShownToolTip2 = false;
        public bool isContainSimulator = false;

        public UserControlsEnum? currentControlEnum;
        public UserControlsEnum? lastControlEnum;
        public ToolStripMenuItem lastButton;
        public ToolStripMenuItem currentButton;
        public MainWindow()
        {
            InitializeComponent();
            projectList = AutofacIntegration.GetInstance<IProjectListService>();
            repositoryService = AutofacIntegration.GetInstance<IRepositoryService>();
            // Инициализация массива кнопок рабочего пространства
            workspaceButtons = new ToolStripMenuItem[] { button1, button2, button3, button4, button5, button7, button8,
                button9, button10, button11 };

            UserControls.Add(UserControlsEnum.Create, () => new ConfirmCreate());
            UserControls.Add(UserControlsEnum.Open, () => new ConfirmOpen());
            UserControls.Add(UserControlsEnum.Delete, () => new ConfirmDelete());
            UserControls.Add(UserControlsEnum.Rename, () => new ConfirmRename());
            UserControls.Add(UserControlsEnum.SaveAs, () => new ConfirmSaveAs());
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
            if (projectList.CurrentProjectName != null) label1.Text = "Имя текущего проекта: " + projectList.CurrentProjectName;
            else label1.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SwichUserControl(UserControlsEnum.Create, button1);
            Left.Enabled = false;
            Right.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SwichUserControl(UserControlsEnum.Open, button2);
            Left.Enabled = false;
            Right.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SwichUserControl(UserControlsEnum.Delete, button3);
            Left.Enabled = false;
            Right.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SwichUserControl(UserControlsEnum.Rename, button4);
            Left.Enabled = false;
            Right.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SwichUserControl(UserControlsEnum.SaveAs, button5);
            Left.Enabled = false;
            Right.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            projectList.SaveAll();
            // сохранение
        }
        private void button7_Click(object sender, EventArgs e)
        {
            SwichUserControl(UserControlsEnum.Loader, button7);
            Left.Enabled = false;
            Right.Enabled = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SwichUserControl(UserControlsEnum.Fasification, button8);
            Left.Enabled = true;
            Right.Enabled = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SwichUserControl(UserControlsEnum.Inference, button9);
            Left.Enabled = true;
            Right.Enabled = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SwichUserControl(UserControlsEnum.Defasification, button10);
            Left.Enabled = true;
            if (isContainSimulator) Right.Enabled = true;
            else { Right.Enabled = false; }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SwichUserControl(UserControlsEnum.Simulation, button11);
            Left.Enabled = true;
            Right.Enabled = false;
        }
        public void OpenLoader()
        {
            if (projectList.CurrentProjectName != null) label1.Text = "Имя текущего проекта: " + projectList.CurrentProjectName;
            SwichUserControl(UserControlsEnum.Loader, button7);
            Left.Enabled = false;
            Right.Enabled = true;
        }
        private void button12_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.Show();

        }
        private void menuStrip2_GotFocus(object sender, EventArgs e)
        {

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
                Left.Enabled = false;
                Right.Enabled = false;
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
                Left.Enabled = true;
                Right.Enabled = true;
            }
        }

        public void EnableSimulationsButton(bool enable)
        {
            this.button11.Enabled = enable;
        }
        public void ColorDelete()
        {
            button1.BackColor = DefaultBackColor;
            button2.BackColor = DefaultBackColor;
            button3.BackColor = DefaultBackColor;
            lastControlEnum = null;
            lastButton = null;
            button1.Enabled = true;
            button2.Enabled = true;
        }

        private bool IsSecondMenu(UserControlsEnum? control)
        {
            if (control == UserControlsEnum.Create || control == UserControlsEnum.Open ||
                control == UserControlsEnum.Delete || control == UserControlsEnum.Rename ||
                control == UserControlsEnum.SaveAs) return false;
            else return true;
        }

        public void SwichUserControl(UserControlsEnum? newWindowName, ToolStripMenuItem clickedButton)
        {
            foreach (var item in workspaceButtons)
            {
                item.Enabled = true;
                item.BackColor = DefaultBackColor;
            }
            clickedButton.BackColor = Color.LightBlue;
            clickedButton.Enabled = false;
            if (!isContainSimulator) button11.Enabled = false;
            if (IsSecondMenu(currentControlEnum))
            {
                lastControlEnum = currentControlEnum;
                lastButton = currentButton;
            }

            var toRemove = this;
            if (currentControl != null)
            {
                toRemove.Controls.Remove(currentControl);
                currentControl.Dispose();
            }
            if (newWindowName.HasValue)
            {
                currentControl = UserControls[newWindowName.Value]();
                currentControlEnum = newWindowName;
                currentButton = clickedButton;
                toRemove.Controls.Add(currentControl);
                currentControl.Location = new Point(0, 140);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            HelpWindow help = new HelpWindow();
            help.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var v = new Point(MousePosition.X - (Location.X + menuStrip2.Location.X + button11.Bounds.Location.X),
                MousePosition.Y - (Location.Y + menuStrip2.Location.Y + button11.Bounds.Location.Y));
            if (v.X >= 0 && v.X <= button11.Width && v.Y >= 0 && v.Y <= button11.Height)
            {
                if (!IsShownToolTip1 && projectList.CurrentProjectName != null && !isContainSimulator)
                {
                    toolTip1.SetToolTip(menuStrip2, "Симуляция не загружена в проект или отключена в окне загрузчика");
                    string tipstring = toolTip1.GetToolTip(menuStrip2);
                    toolTip1.Show(tipstring, menuStrip2, menuStrip2.Width / 2, menuStrip2.Height / 2);
                    IsShownToolTip1 = true;
                }
            }
            else
            {
                toolTip1.Hide(menuStrip2);
                IsShownToolTip1 = false;
                toolTip1.SetToolTip(menuStrip2, null);
            }

            var t = new Point(MousePosition.X - (Location.X + Right.Location.X),
               MousePosition.Y - (Location.Y + Right.Location.Y));
            if (t.X >= 0 && t.X <= Right.Width && t.Y >= 0 && t.Y <= Right.Height)
            {
                if (!IsShownToolTip2 && !isContainSimulator && projectList.CurrentProjectName != null && Right.Enabled == false)
                {
                    toolTip2.SetToolTip(Right, "Симуляция не загружена в проект или отключена в окне загрузчика");
                    string tipstring = toolTip2.GetToolTip(Right);
                    toolTip2.Show(tipstring, Right, Right.Width / 2, Right.Height / 2);
                    IsShownToolTip2 = true;
                }
            }
            else
            {
                toolTip2.Hide(Right);
                IsShownToolTip2 = false;
                toolTip2.SetToolTip(Right, null);

            }
        }

        private void Left_Click(object sender, EventArgs e)
        {
            if (button8.Enabled == false)
            {
                SwichUserControl(UserControlsEnum.Loader, button7);
                Left.Enabled = false;
                return;
            }
            if (button9.Enabled == false)
            {
                SwichUserControl(UserControlsEnum.Fasification, button8);
                return;
            }
            if (button10.Enabled == false)
            {
                SwichUserControl(UserControlsEnum.Inference, button9);
                Right.Enabled = true;
                return;
            }
            if (button11.Enabled == false && isContainSimulator == true)
            {
                SwichUserControl(UserControlsEnum.Defasification, button10);
                Right.Enabled = true;
                return;
            }
        }

        private void Right_Click(object sender, EventArgs e)
        {
            if (button7.Enabled == false)
            {
                SwichUserControl(UserControlsEnum.Fasification, button8);
                Left.Enabled = true;
                return;
            }
            if (button8.Enabled == false)
            {
                SwichUserControl(UserControlsEnum.Inference, button9);
                return;
            }
            if (button9.Enabled == false)
            {
                SwichUserControl(UserControlsEnum.Defasification, button10);
                if (!isContainSimulator) Right.Enabled = false;
                return;
            }
            if (button10.Enabled == false && isContainSimulator == true)
            {
                SwichUserControl(UserControlsEnum.Simulation, button11);
                Right.Enabled = false;
                return;
            }
        }
    }
}