﻿using SimpleFuzzy.Abstract;
using SimpleFuzzy.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SimpleFuzzy.View
{
    public partial class ConfirmDelete : UserControl
    {
        IProjectListService projectList;
        public ConfirmDelete()
        {
            InitializeComponent();
            projectList = AutofacIntegration.GetInstance<IProjectListService>();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try { projectList.DeleteProject(projectList.CurrentProjectName); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            if (Parent is MainWindow parent) 
            {
                parent.OpenButtons(sender, e);
                parent.Locked(sender, e);
            }
            Parent.Controls.Remove(this);
        }

        private void button2_Click(object sender, EventArgs e) 
        {
            if (Parent is MainWindow parent) { parent.OpenButtons(sender, e); }
            Parent.Controls.Remove(this);
        }

        private void ConfirmDelete_Load(object sender, EventArgs e)
        {
            if (Parent is MainWindow parent) { parent.BlockButtons(sender, e); }
        }
    }
}
