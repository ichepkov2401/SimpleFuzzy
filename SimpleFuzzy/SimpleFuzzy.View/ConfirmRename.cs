﻿using SimpleFuzzy.Abstract;

namespace SimpleFuzzy.View
{
    public partial class ConfirmRename : UserControl
    {
        IProjectListService projectList;
        public ConfirmRename()
        {
            InitializeComponent();
            projectList = AutofacIntegration.GetInstance<IProjectListService>();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                projectList.RenameProject(textBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            if (Parent is MainWindow parent)
            {
                parent.OpenButtons();
                parent.OpenLoader();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Parent is MainWindow parent) 
            {
                parent.OpenButtons(); 
            }
            Parent.Controls.Remove(this);
        }

        private void ConfirmRename_Load(object sender, EventArgs e)
        {
            if (Parent is MainWindow parent) { parent.BlockButtons(); }
        }
    }
}
