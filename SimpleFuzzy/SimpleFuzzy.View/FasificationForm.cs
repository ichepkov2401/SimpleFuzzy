using MetroFramework.Controls;
using SimpleFuzzy.Abstract;


namespace SimpleFuzzy.View
{
    public partial class FasificationForm : MetroUserControl
    {
        IRepositoryService repositoryService;
        public FasificationForm()
        {
            InitializeComponent();
            repositoryService = AutofacIntegration.GetInstance<IRepositoryService>();
            FillTreeView();
        }

        private void FillTreeView()
        {
            List<IMembershipFunction> list1 = repositoryService.GetCollection<IMembershipFunction>();
            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i].Active)
                {
                    if (list1.Count(v => v.Name == list1[i].Name) > 1)
                    {
                        treeView1.Nodes[0].Nodes.Add(list1[i].Name + " - " + list1[i].GetType().Name + " - " + list1[i].GetType().Assembly.Location);
                    }
                    else
                    {
                        treeView1.Nodes[0].Nodes.Add(list1[i].Name);
                    }
                }
            }
            List<IObjectSet> list2 = repositoryService.GetCollection<IObjectSet>();
            for (int i = 0; i < list2.Count; i++)
            {
                if (list2[i].Active)
                {
                    if (list2.Count(v => v.Name == list2[i].Name) > 1)
                    {
                        treeView1.Nodes[1].Nodes.Add(list2[i].Name + " - " + list2[i].GetType().Name + " - " + list2[i].GetType().Assembly.Location);
                    }
                    else
                    {
                        treeView1.Nodes[1].Nodes.Add(list2[i].Name);
                    }
                }
            }
            treeView1.ExpandAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // добавление лингвистической переменной
            // Пока что добавляется только запись о создании переменной
            ListViewItem item = listView1.Items.Add("Name");
            item.SubItems.Add("X");
        }

        private void OnButtonActionClick(object sender, ListViewColumnMouseEventArgs e)
        {
            const string message = "Вы уверенны, что хотите удалить выбранный файл?";
            const string caption = "Удаление элемента";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                listView1.Items.Remove(e.Item);
                // Дальше удаление лингвистической переменной
            }
        }
    }
}