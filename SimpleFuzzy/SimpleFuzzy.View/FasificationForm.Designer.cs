using System.Windows.Forms;

namespace SimpleFuzzy.View
{
    partial class FasificationForm
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TreeNode treeNode1 = new TreeNode("Термы");
            TreeNode treeNode2 = new TreeNode("Базовые множества");
            treeView1 = new TreeView();
            SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.Location = new Point(3, 3);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(187, 223);
            treeView1.TabIndex = 0;
            treeNode1.Name = "";
            treeNode1.Text = "Термы";
            treeNode2.Name = "";
            treeNode2.Text = "Базовые множества";
            treeView1.Nodes.AddRange(new TreeNode[] { treeNode1, treeNode2 });
            // 
            // FasificationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(treeView1);
            Name = "FasificationForm";
            Size = new Size(952, 477);
            ResumeLayout(false);
        }

        #endregion

        private TreeView treeView1;
    }
}
