
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace SimpleFuzzy.View 
{ 
    partial class LoaderForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            filePathTextBox = new TextBox();
            browseButton = new Button();
            loadButton = new Button();
            messageTextBox = new TextBox();
            treeView1 = new RadioTree();
            dllListView = new ListView();
            FileName = new ColumnHeader();
            CloseButton = new ColumnHeader();
            groupBoxLoader = new GroupBox();
            groupBoxModules = new GroupBox();
            groupBoxDLL = new GroupBox();
            groupBoxLoader.SuspendLayout();
            groupBoxModules.SuspendLayout();
            groupBoxDLL.SuspendLayout();
            SuspendLayout();
            // 
            // filePathTextBox
            // 
            filePathTextBox.Location = new Point(8, 61);
            filePathTextBox.Name = "filePathTextBox";
            filePathTextBox.Size = new Size(358, 27);
            filePathTextBox.TabIndex = 0;
            // 
            // browseButton
            // 
            browseButton.Location = new Point(372, 62);
            browseButton.Name = "browseButton";
            browseButton.Size = new Size(99, 27);
            browseButton.TabIndex = 1;
            browseButton.Text = "Обзор";
            browseButton.Click += browseButton_Click;
            // 
            // loadButton
            // 
            loadButton.Location = new Point(8, 28);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(463, 30);
            loadButton.TabIndex = 2;
            loadButton.Text = "Загрузить модуль";
            loadButton.Click += loadButton_Click;
            // 
            // messageTextBox
            // 
            messageTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            messageTextBox.Enabled = false;
            messageTextBox.Location = new Point(8, 95);
            messageTextBox.Multiline = true;
            messageTextBox.Name = "messageTextBox";
            messageTextBox.Size = new Size(463, 164);
            messageTextBox.TabIndex = 3;
            // 
            // treeView1
            // 
            treeView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            treeView1.Location = new Point(10, 26);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(521, 233);
            treeView1.TabIndex = 0;
            treeView1.BaseSetCheckedChange += BaseSetCheck;
            treeView1.TermCheckedChange += TermCheck;
            treeView1.SimulatorCheckedChange += SimulatorCheck;
            // 
            // dllListView
            // 
            dllListView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dllListView.FullRowSelect = true;
            dllListView.Location = new Point(10, 26);
            dllListView.Name = "dllListView";
            dllListView.ShowItemToolTips = true;
            dllListView.Size = new Size(1004, 170);
            dllListView.TabIndex = 6;
            dllListView.UseCompatibleStateImageBehavior = false;
            dllListView.View = System.Windows.Forms.View.Details;
            // 
            // FileName
            // 
            FileName.Text = "Имя";
            // 
            // CloseButton
            // 
            CloseButton.Text = "";
            // 
            // groupBoxLoader
            // 
            groupBoxLoader.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            groupBoxLoader.Controls.Add(filePathTextBox);
            groupBoxLoader.Controls.Add(browseButton);
            groupBoxLoader.Controls.Add(loadButton);
            groupBoxLoader.Controls.Add(messageTextBox);
            groupBoxLoader.Location = new Point(553, 3);
            groupBoxLoader.Name = "groupBoxLoader";
            groupBoxLoader.Size = new Size(483, 268);
            groupBoxLoader.TabIndex = 0;
            groupBoxLoader.TabStop = false;
            groupBoxLoader.Text = "Загрузка модуля";
            // 
            // groupBoxModules
            // 
            groupBoxModules.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxModules.Controls.Add(treeView1);
            groupBoxModules.Location = new Point(10, 3);
            groupBoxModules.Name = "groupBoxModules";
            groupBoxModules.Size = new Size(537, 268);
            groupBoxModules.TabIndex = 1;
            groupBoxModules.TabStop = false;
            groupBoxModules.Text = "Загруженные модули";
            // 
            // groupBoxDLL
            // 
            groupBoxDLL.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxDLL.Controls.Add(dllListView);
            groupBoxDLL.Location = new Point(10, 277);
            groupBoxDLL.Name = "groupBoxDLL";
            groupBoxDLL.Size = new Size(1026, 204);
            groupBoxDLL.TabIndex = 7;
            groupBoxDLL.TabStop = false;
            groupBoxDLL.Text = "Загруженные DLL файлы";
            // 
            // LoaderForm
            // 
            BackColor = SystemColors.Control;
            Controls.Add(groupBoxLoader);
            Controls.Add(groupBoxModules);
            Controls.Add(groupBoxDLL);
            Name = "LoaderForm";
            Size = new Size(1039, 484);
            groupBoxLoader.ResumeLayout(false);
            groupBoxLoader.PerformLayout();
            groupBoxModules.ResumeLayout(false);
            groupBoxDLL.ResumeLayout(false);
            ResumeLayout(false);
        }
        #endregion

        private TextBox filePathTextBox;
        private Button browseButton;
        private Button loadButton;
        private TextBox messageTextBox;
        private RadioTree treeView1;
        public ListView dllListView;
        private ColumnHeader FileName;
        private ColumnHeader CloseButton;
        private GroupBox groupBoxLoader;
        private GroupBox groupBoxModules;
        private GroupBox groupBoxDLL;
    }
}

