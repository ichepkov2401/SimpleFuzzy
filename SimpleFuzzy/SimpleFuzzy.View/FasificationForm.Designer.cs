using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

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
            FileName = new ColumnHeader();
            CloseButton = new ColumnHeader();
            treeView1 = new TreeView();
            listView1 = new ListView();
            button1 = new Button();
            SuspendLayout();
            // 
            // FileName
            // 
            FileName.Text = "Лингвистические переменные";
            FileName.Width = 226;
            // 
            // CloseButton
            // 
            CloseButton.Text = "";
            // 
            // treeView1
            // 
            treeView1.Location = new Point(3, 3);
            treeView1.Name = "treeView1";
            treeNode1.Name = "";
            treeNode1.Text = "Термы";
            treeNode2.Name = "";
            treeNode2.Text = "Базовые множества";
            treeView1.Nodes.AddRange(new TreeNode[] { treeNode1, treeNode2 });
            treeView1.Size = new Size(363, 134);
            treeView1.TabIndex = 0;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { FileName, CloseButton });
            listView1.FullRowSelect = true;
            listView1.Location = new Point(3, 178);
            listView1.Name = "listView1";
            listView1.Size = new Size(363, 305);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = System.Windows.Forms.View.Details;
            ListViewExtender extender = new ListViewExtender(listView1);
            ListViewButtonColumn buttonAction = new ListViewButtonColumn(1);
            buttonAction.Click += OnButtonActionClick;
            buttonAction.FixedWidth = true;
            extender.AddColumn(buttonAction);
            // 
            // button1
            // 
            button1.Location = new Point(0, 143);
            button1.Name = "button1";
            button1.Size = new Size(366, 29);
            button1.TabIndex = 2;
            button1.Text = "Добавить лингвистическую переменную";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FasificationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button1);
            Controls.Add(listView1);
            Controls.Add(treeView1);
            Name = "FasificationForm";
            Size = new Size(952, 487);
            ResumeLayout(false);
        }

        #endregion
        private ColumnHeader CloseButton;
        private ColumnHeader FileName;
        private TreeView treeView1;
        private ListView listView1;
        private Button button1;
    }
}
