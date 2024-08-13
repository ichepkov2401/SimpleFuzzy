﻿using MetroFramework.Controls;
using SimpleFuzzy.Abstract;

namespace SimpleFuzzy.View
{
    public partial class ConfirmOpen : MetroUserControl
    {
        IProjectListService projectList;
        IRepositoryService repositoryService;
        public ConfirmOpen()
        {
            InitializeComponent();
            projectList = AutofacIntegration.GetInstance<IProjectListService>();
            repositoryService = AutofacIntegration.GetInstance<IRepositoryService>();
            if (Parent is MainWindow parent) { parent.BlockButtons(); }
            label2.Visible = false;
            string[] list = projectList.GiveList();
            for (int i = 1; i < list.Length; i += 3)
            {
                if (Directory.Exists(list[i])) { listBox1.Items.Add(list[i - 1]); }
                else { projectList.DeleteOnlyInList(list[i - 1]); }
            }
            if (listBox1.Items.Count == 0)
            {
                label2.Text = "Проектов пока нет, перейдите к созданию проекта";
                label2.Visible = true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.RootFolder = Environment.SpecialFolder.Desktop;
            dialog.SelectedPath = Directory.GetCurrentDirectory() + "\\Projects\\";
            if (dialog.ShowDialog() == DialogResult.Cancel) { return; }
            if (dialog.SelectedPath == "") { return; }
            try
            {
                // дальше по выбранной папке открывается проект
                repositoryService.ClearAll();
                projectList.OpenProjectfromPath(dialog.SelectedPath);
                if (Parent is MainWindow parent)
                {
                    parent.OpenButtons();
                    parent.Locked();
                    parent.OpenLoader();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Parent is MainWindow parent)
            {
                parent.OpenButtons();
                parent.Locked();
            }
            Parent.Controls.Remove(this);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (listBox1 == null) { return; }
            label2.Visible = false;
            string[] list = projectList.GiveList();
            bool isEmpty = true;
            listBox1.Items.Clear();
            for (int i = 0; i < list.Length; i += 3)
            {
                bool isContain = true;
                for (int j = 0; j < textBox1.Text.Length && j < list[i].Length; j++)
                {
                    if (list[i][j] != textBox1.Text[j])
                    {
                        isContain = false;
                        break;
                    }
                }
                if (isContain && textBox1.Text.Length <= list[i].Length)
                {
                    listBox1.Items.Add(list[i]);
                    isEmpty = false;
                }
            }
            if (isEmpty)
            {
                label2.Text = "Файлов с таким именем не найдено...";
                label2.Visible = true;
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string projectName = listBox1.SelectedItem.ToString();
                try
                {
                    // открытие проекта
                    repositoryService.ClearAll();
                    projectList.OpenProjectfromName(projectName);
                    if (Parent is MainWindow parent)
                    {
                        parent.OpenButtons();
                        parent.Locked();
                        parent.OpenLoader();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }
    }
}
