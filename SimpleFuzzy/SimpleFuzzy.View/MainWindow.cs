using SimpleFuzzy.Abstract;
using SimpleFuzzy.Service;
using System;
using System.Windows.Forms;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System.IO;
using System.Runtime.Loader;

namespace SimpleFuzzy.View
{
    public delegate UserControl ControlConstruct();
    public partial class MainWindow : MetroForm
    {
        Dictionary<UserControlsEnum, ControlConstruct> UserControls = new Dictionary<UserControlsEnum, ControlConstruct>();
        public UserControl currentControl = null;
        IRepositoryService repositoryService;
        IProjectListService projectList;
        private Button[] workspaceButtons;
        bool IsShownToolTip1 = true;
        public bool isContainSimulator = false;
        public MainWindow()
        {
            InitializeComponent();
            projectList = AutofacIntegration.GetInstance<IProjectListService>();
            repositoryService = AutofacIntegration.GetInstance<IRepositoryService>();
            // Инициализация массива кнопок рабочего пространства
            workspaceButtons = new Button[] { button7, button8, button9, button10, button11 };

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
            SaveActiveModules(sender, e);
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
        private void SwitchWorkspace(UserControlsEnum workspace, Button clickedButton)
        {
            foreach (Button button in workspaceButtons) { button.Enabled = true; }
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
                toRemove.Controls.Add(currentControl);
                currentControl.Location = new Point(0, 160);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            HelpWindow help = new HelpWindow(this);
            help.Show();
        }


        private void MainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            Control ctrl = this.GetChildAtPoint(e.Location);

            if (ctrl != null)
            {
                if (ctrl == this.button11 && !IsShownToolTip1 && projectList.CurrentProjectName != null && !isContainSimulator)
                {
                    toolTip1.SetToolTip(this.button11, "Симуляция не загружена в проект или отключена в окне загрузчика");
                    string tipstring = this.toolTip1.GetToolTip(this.button11);
                    this.toolTip1.Show(tipstring, this.button11, this.button11.Width / 2, this.button11.Height / 2);
                    IsShownToolTip1 = true;
                }
            }
            else
            {
                this.toolTip1.Hide(this.button11);
                IsShownToolTip1 = false;
                toolTip1.SetToolTip(this.button11, null);
            }
        }
        private void SaveActiveModules(object sender, EventArgs e)
        {
            string path = projectList.GivePath(projectList.CurrentProjectName, true) + "\\ActiveAssemblies.tt";
            if (File.Exists(path))
            {
                FileStream file = new FileStream(path, FileMode.Truncate);
                StreamWriter writer = new StreamWriter(file);
                for (int i = 0; i < repositoryService.GetCollection<IMembershipFunction>().Count; i++)
                {
                    string active;
                    if (repositoryService.GetCollection<IMembershipFunction>()[i].Active) active = "true";
                    else active = "false";
                    string moduleName = repositoryService.GetCollection<IMembershipFunction>()[i].GetType().Name;
                    string assemblyName = repositoryService.GetCollection<IMembershipFunction>()[i].GetType().Assembly.FullName;
                    string answer = assemblyName + " , " + moduleName + " - " + active;
                    writer.WriteLine(answer);
                }
                for (int i = 0; i < repositoryService.GetCollection<IObjectSet>().Count; i++)
                {
                    string active;
                    if (repositoryService.GetCollection<IObjectSet>()[i].Active) active = "true";
                    else active = "false";
                    string moduleName = repositoryService.GetCollection<IObjectSet>()[i].GetType().Name;
                    string assemblyName = repositoryService.GetCollection<IObjectSet>()[i].GetType().Assembly.FullName;
                    string answer = assemblyName + " , " + moduleName + " - " + active;
                    writer.WriteLine(answer);
                }
                for (int i = 0; i < repositoryService.GetCollection<ISimulator>().Count; i++)
                {
                    string active;
                    if (repositoryService.GetCollection<ISimulator>()[i].Active) active = "true";
                    else active = "false";
                    string moduleName = repositoryService.GetCollection<ISimulator>()[i].GetType().Name;
                    string assemblyName = repositoryService.GetCollection<ISimulator>()[i].GetType().Assembly.FullName;
                    string answer = assemblyName + " , " + moduleName + " - " + active;
                    writer.WriteLine(answer);
                }
                writer.Close();
                file.Close();
            }
            else
            {
                FileStream file1 = new FileStream(path, FileMode.Create);
                file1.Close();
                button6_Click(sender, e);
            }
        }
    }
}