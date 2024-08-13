﻿using MetroFramework.Controls;
using SimpleFuzzy.Abstract;

namespace SimpleFuzzy.View
{
    public partial class ConfirmCopy : MetroUserControl
    {
        IProjectListService projectList;
        public ConfirmCopy()
        {
            InitializeComponent();
            projectList = AutofacIntegration.GetInstance<IProjectListService>();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string path = Directory.GetCurrentDirectory() + "\\Projects";
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.RootFolder = Environment.SpecialFolder.Desktop;
            dialog.SelectedPath = path;
            if (dialog.ShowDialog() == DialogResult.Cancel) return;
            else { textBox1.Text = dialog.SelectedPath; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try { projectList.CopyProject(projectList.CurrentProjectName + " - копия", textBox1.Text + $"\\{projectList.CurrentProjectName} - копия"); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            button3_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Parent is MainWindow parent) { parent.OpenButtons(); }
            Parent.Controls.Remove(this);
        }

        private void ConfirmCopy_Load(object sender, EventArgs e)
        {
            if (Parent is MainWindow parent) { parent.BlockButtons(); }
        }
    }
}
