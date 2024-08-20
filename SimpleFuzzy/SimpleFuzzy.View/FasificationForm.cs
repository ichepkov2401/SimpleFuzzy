﻿using MetroFramework.Controls;
using SimpleFuzzy.Abstract;
using SimpleFuzzy.Model;


namespace SimpleFuzzy.View
{
    public partial class FasificationForm : MetroUserControl
    {
        IRepositoryService repositoryService;
        public FasificationForm()
        {
            InitializeComponent();
            ListViewExtender extender = new ListViewExtender(listView1);
            ListViewButtonColumn buttonAction = new ListViewButtonColumn(1);
            buttonAction.Click += OnButtonActionClick;
            buttonAction.FixedWidth = true;
            extender.AddColumn(buttonAction);
            repositoryService = AutofacIntegration.GetInstance<IRepositoryService>();
            FillTreeView();
            RefreshLinguisticVariableList();
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
            using (var inputBox = new LinguisticVariableInputForm("Введите имя переменной:", "Создание переменной"))
            {
                if (inputBox.ShowDialog() == DialogResult.OK)
                {
                    string variableName = inputBox.InputText;

                    if (string.IsNullOrWhiteSpace(variableName))
                    {
                        MessageBox.Show("Имя переменной не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var existingVariable = repositoryService.GetCollection<LinguisticVariable>()
                                                            .FirstOrDefault(v => v.Name == variableName);

                    if (existingVariable != null)
                    {
                        MessageBox.Show("Переменная с таким именем уже существует. Пожалуйста, введите другое имя.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var newVariable = new LinguisticVariable(true) { Name = variableName };
                    repositoryService.GetCollection<LinguisticVariable>().Add(newVariable);

                    RefreshLinguisticVariableList();
                }
            }
        }
        private void OnButtonActionClick(object sender, ListViewColumnMouseEventArgs e)
        {
            const string message = "Вы уверенны, что хотите удалить выбранный файл?";
            const string caption = "Удаление элемента";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var item = e.Item;
                string variableName = item.Text;

                var variables = repositoryService.GetCollection<LinguisticVariable>();
                var variableToRemove = variables.FirstOrDefault(v => v.Name == variableName);

                if (variableToRemove != null)
                {
                    variables.Remove(variableToRemove);
                }

                RefreshLinguisticVariableList();
            }
        }
        public void RefreshLinguisticVariableList()
        {
            listView1.Items.Clear();
            List<LinguisticVariable> linguisticVariables = repositoryService.GetCollection<LinguisticVariable>();

            foreach (var variable in linguisticVariables)
            {
                ListViewItem item = new ListViewItem(variable.Name);
                item.SubItems.Add("X");
                listView1.Items.Add(item);
            }
        }
    }
}