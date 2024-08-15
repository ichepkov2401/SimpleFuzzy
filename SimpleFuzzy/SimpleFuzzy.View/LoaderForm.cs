﻿using MetroFramework.Controls;
using SimpleFuzzy.Abstract;
using System.Runtime.Loader;

namespace SimpleFuzzy.View
{
    public partial class LoaderForm : MetroUserControl
    {
        public IAssemblyLoaderService moduleLoaderService;
        public IRepositoryService repositoryService;
        Dictionary<string, IModulable> modules = new Dictionary<string, IModulable>();
        Dictionary<ListViewItem, AssemblyLoadContext> LoadedAssembies = new Dictionary<ListViewItem, AssemblyLoadContext>();
        public LoaderForm()
        {
            InitializeComponent();
            moduleLoaderService = AutofacIntegration.GetInstance<IAssemblyLoaderService>();
            repositoryService = AutofacIntegration.GetInstance<IRepositoryService>();
            RefreshDllList(repositoryService.GetCollection<AssemblyLoadContext>());
            TreeViewShow();
            moduleLoaderService.UseAssembly += AssemblyHandler;
        }

        public void AssemblyHandler(object sender, EventArgs e)
        {
            modules.Clear();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "DLL files (*.dll)|*.dll";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePathTextBox.Text = openFileDialog.FileName;
                }
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            string filePath = filePathTextBox.Text;
            if (string.IsNullOrWhiteSpace(filePath))
            {
                messageTextBox.Text = "Пожалуйста, укажите путь к файлу.";
                return;
            }

            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("Указанный файл не существует.", filePath);
                }

                if (Path.GetExtension(filePath).ToLower() != ".dll")
                {
                    throw new FileFormatException("Файл должен иметь расширение .dll");
                }
                moduleLoaderService.AssemblyLoader(filePath);
                foreach (var assemblyLoadContext in repositoryService.GetCollection<AssemblyLoadContext>())
                {
                    if (assemblyLoadContext.Name == filePath)
                    {
                        messageTextBox.Text = assemblyLoadContext.Assemblies.ElementAt(0).FullName;
                    }
                }
                RefreshDllList(repositoryService.GetCollection<AssemblyLoadContext>());
                TreeViewShow();
            }
            catch (FileNotFoundException ex)
            {
                messageTextBox.Text = $"Ошибка: Файл не найден. {ex.Message}";
            }
            catch (FileFormatException ex)
            {
                messageTextBox.Text = $"Ошибка: Неверный формат файла. {ex.Message}";
            }
            catch (Exception ex)
            {
                messageTextBox.Text = $"Неизвестная ошибка: {ex.Message}";
            }
        }

        private void TreeViewShow()
        {
            foreach (TreeNode node in treeView1.Nodes) { node.Nodes.Clear(); }
            modules.Clear();
            List<IMembershipFunction> list1 = repositoryService.GetCollection<IMembershipFunction>();
            for (int i = 0; i < list1.Count; i++)
            {

                if (list1.Count(v => v.Name == list1[i].Name) > 1)
                {
                    treeView1.Nodes[0].Nodes.Add(list1[i].Name + " - " + list1[i].GetType().Name + " - " + list1[i].GetType().Assembly.Location);
                    modules.Add(list1[i].Name + " - " + list1[i].GetType().Name + " - " + list1[i].GetType().Assembly.Location, list1[i]);
                }
                else
                {
                    treeView1.Nodes[0].Nodes.Add(list1[i].Name);
                    modules.Add(list1[i].Name, list1[i]);
                }
                treeView1.Nodes[0].Nodes[^1].Checked = list1[i].Active;
                treeView1.Nodes[0].Nodes[^1].ToolTipText = list1[i].GetType().Assembly.Location;
            }
            treeView1.Nodes[0].Checked = list1.Any(t => t.Active);

            List<IObjectSet> list2 = repositoryService.GetCollection<IObjectSet>();
            for (int i = 0; i < list2.Count; i++)
            {
                if (list2.Count(v => v.Name == list2[i].Name) > 1)
                {
                    treeView1.Nodes[1].Nodes.Add(list2[i].Name + " - " + list2[i].GetType().Name + " - " + list2[i].GetType().Assembly.Location);
                    modules.Add(list2[i].Name + " - " + list2[i].GetType().Name + " - " + list2[i].GetType().Assembly.Location, list2[i]);
                }
                else
                {
                    treeView1.Nodes[1].Nodes.Add(list2[i].Name);
                    modules.Add(list2[i].Name, list2[i]);
                }
                treeView1.Nodes[1].Nodes[^1].Checked = list2[i].Active;
                treeView1.Nodes[1].Nodes[^1].ToolTipText = list2[i].GetType().Assembly.Location;
            }
            treeView1.Nodes[1].Checked = list2.Any(t => t.Active);

            List<ISimulator> list3 = repositoryService.GetCollection<ISimulator>();
            for (int i = 0; i < list3.Count; i++)
            {
                if (list3.Count(v => v.Name == list3[i].Name) > 1)
                {
                    treeView1.Nodes[2].Nodes.Add(list3[i].Name + " - " + list3[i].GetType().Name + " - " + list3[i].GetType().Assembly.Location);
                    modules.Add(list3[i].Name + " - " + list3[i].GetType().Name + " - " + list3[i].GetType().Assembly.Location, list3[i]);
                }
                else
                {
                    treeView1.Nodes[2].Nodes.Add(list3[i].Name);
                    modules.Add(list3[i].Name, list3[i]);
                }
                treeView1.Nodes[2].Nodes[^1].Checked = list3[i].Active;
                treeView1.Nodes[2].Nodes[^1].ToolTipText = list3[i].GetType().Assembly.Location;
            }
            treeView1.ExpandAll();
        }

        private void ParentChecked(TreeViewEventArgs e)
        {
            // Костыль для отключения симуляции
            if (e.Node == treeView1.Nodes[2] && e.Node.Checked)
            {
                e.Node.Checked = false;
                return;
            }

            // Общий случай включения всех детей
            foreach (TreeNode node in treeView1.Nodes)
            {
                if (node == e.Node)
                {
                    if (e.Node == treeView1.Nodes[2])
                    {
                        return;
                    }
                    foreach (TreeNode child in node.Nodes)
                    {
                        child.Checked = e.Node.Checked;
                        modules[child.Text].Active = e.Node.Checked;
                    }
                    return;
                }
            }

        }

        private void ChildChecked(TreeViewEventArgs e)
        {
            foreach (TreeNode node in treeView1.Nodes[2].Nodes)
            {
                if (node == e.Node)
                {
                    if (e.Node.Checked)
                    {
                        if (Parent is MainWindow parent)
                        {
                            parent.isContainSimulator = true;
                            parent.EnableSimulationsButton(true);
                        }
                        if (repositoryService.GetCollection<ISimulator>().Any(v => v.Active) && !modules[e.Node.Text].Active)
                        {
                            DialogResult result = MessageBox.Show(
                            "Изменить симуляцию?",
                            "Симуляцию можно загрузить только одну",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.None,
                            MessageBoxDefaultButton.Button1);

                            if (result == DialogResult.Yes)
                            {
                                foreach (TreeNode node1 in treeView1.Nodes[2].Nodes)
                                {
                                    if (node1.Checked) 
                                    {
                                        node1.Checked = false;
                                        modules[node1.Text].Active = false;
                                    }
                                }
                                node.Checked = true;
                                modules[node.Text].Active = true;
                            }
                            else { node.Checked = false; }
                            return;
                        }
                    }
                    else
                    {
                        if (Parent is MainWindow parent)
                        {
                            parent.isContainSimulator = false;
                            parent.EnableSimulationsButton(false);
                        }
                    }
                }
            }
            modules[e.Node.Text].Active = e.Node.Checked;

            if (e.Node.Parent != treeView1.Nodes[2])
            {
                if (e.Node.Parent.Nodes.OfType<TreeNode>().Any(t => t.Checked) && !e.Node.Parent.Checked)
                {
                    e.Node.Parent.Checked = true;
                }
                else if (e.Node.Parent.Nodes.OfType<TreeNode>().All(t => !t.Checked) && e.Node.Parent.Checked)
                {
                    e.Node.Parent.Checked = false;
                }
            }
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByKeyboard || e.Action == TreeViewAction.ByMouse)
            {
                if (e.Node == treeView1.Nodes[0] || e.Node == treeView1.Nodes[1] || e.Node == treeView1.Nodes[2])
                {

                    ParentChecked(e);
                }
                else
                {
                    ChildChecked(e);
                }
            }
        }
        //----------------------------------------------------------------------------------------


        public void RefreshDllList(List<AssemblyLoadContext> dllList)
        {
            dllListView.Items.Clear();
            foreach (var dll in dllList)
            {
                string s = dll.Name;
                ListViewItem item = dllListView.Items.Add(s.Split('\\')[^1]);
                string dllInfo = dll.Name + "\n" + "\n";
                LoadedAssembies[item] = dll;
                item.SubItems.Add("X");
                FileName.Width = -1;
                Type[] array = dll.Assemblies.ElementAt(0).GetTypes();
                //--------------------------------------------------------------------------------------
                s = "Термы:\n";
                bool checker = false;
                List<IMembershipFunction> MembershipList = repositoryService.GetCollection<IMembershipFunction>();
                foreach (Type type in array)
                {
                    foreach (var type2 in MembershipList)
                    {
                        if (type == type2.GetType())
                        {
                            checker = true;
                            s += "    " + type2.Name + "\n";
                        }
                    }
                }
                if (checker) dllInfo += s;
                //----------------------------------------------------------------------------------
                s = "Симуляции:\n";
                checker = false;
                List<ISimulator> SimulationshipList = repositoryService.GetCollection<ISimulator>();
                foreach (Type type in array)
                {
                    foreach (var type2 in SimulationshipList)
                    {
                        if (type == type2.GetType())
                        {
                            checker = true;
                            s += "    " + type2.Name + "\n";
                        }
                    }
                }
                if (checker) dllInfo += s;
                //-----------------------------------------------------------------------------------
                s = "Базовые множества:\n";
                checker = false;
                List<IObjectSet> ObjectSetList = repositoryService.GetCollection<IObjectSet>();
                foreach (Type type in array)
                {
                    foreach (var type2 in ObjectSetList)
                    {
                        if (type == type2.GetType())
                        {
                            checker = true;
                            s += "    " + type2.Name + "\n";
                        }
                    }
                }
                if (checker) dllInfo += s;
                //----------------------------------------------------------------------------------
                item.ToolTipText = dllInfo;
            }
        }
        //----------------------------------------------------------------------------------------
        private void OnButtonActionClick(object sender, ListViewColumnMouseEventArgs e)
        {
            const string message = "Вы уверенны, что хотите удалить выбранный файл?";
            const string caption = "Удаление элемента";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                dllListView.Items.Remove(e.Item);
                moduleLoaderService.UnloadAssembly(LoadedAssembies[e.Item].Assemblies.ElementAt(0).FullName);
                LoadedAssembies.Remove(e.Item);
                TreeViewShow();
            }
        }

        //----------------------------------------------------------------------------------------
        /*принудительное закрытие окна 
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.Dll")]
        static extern int PostMessage(IntPtr hWnd, UInt32 msg, int wParam, int lParam);

        const UInt32 WM_CLOSE = 0x0010;

        Thread thread;
        void CloseMessageBox()
        {
            IntPtr hWnd = FindWindowByCaption(IntPtr.Zero, "Удаление элемента");
            if (hWnd != IntPtr.Zero)
                PostMessage(hWnd, WM_CLOSE, 0, 0);

            if (thread.IsAlive)
                thread.Abort();
        }*/
    }
}