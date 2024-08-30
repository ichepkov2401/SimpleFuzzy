
using OxyPlot.WindowsForms;

namespace SimpleFuzzy.View
{
    partial class GenerationMembershipUI
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

        private void InitializeComponent()
        {
            groupBoxSettings = new GroupBox();
            textBox1 = new TextBox();
            label1 = new Label();
            labelBaseSet = new Label();
            comboBoxBaseSet = new ComboBox();
            groupBoxConditions = new GroupBox();
            panelConditions = new Panel();
            buttonAddCondition = new Button();
            groupBoxActions = new GroupBox();
            buttonGenerateCode = new Button();
            buttonVisualize = new Button();
            pictureBox1 = new PictureBox();
            groupBoxSettings.SuspendLayout();
            groupBoxConditions.SuspendLayout();
            groupBoxActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // groupBoxSettings
            // 
            groupBoxSettings.Controls.Add(textBox1);
            groupBoxSettings.Controls.Add(label1);
            groupBoxSettings.Controls.Add(labelBaseSet);
            groupBoxSettings.Controls.Add(comboBoxBaseSet);
            groupBoxSettings.Location = new Point(16, 19);
            groupBoxSettings.Margin = new Padding(5);
            groupBoxSettings.Name = "groupBoxSettings";
            groupBoxSettings.Padding = new Padding(5);
            groupBoxSettings.Size = new Size(400, 89);
            groupBoxSettings.TabIndex = 0;
            groupBoxSettings.TabStop = false;
            groupBoxSettings.Text = "Настройки";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(152, 39);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(197, 23);
            textBox1.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 32);
            label1.Name = "label1";
            label1.Size = new Size(84, 30);
            label1.TabIndex = 4;
            label1.Text = "Имя базового\r\nмножества";
            // 
            // labelBaseSet
            // 
            labelBaseSet.AutoSize = true;
            labelBaseSet.Location = new Point(7, 84);
            labelBaseSet.Margin = new Padding(4, 0, 4, 0);
            labelBaseSet.MaximumSize = new Size(116, 0);
            labelBaseSet.Name = "labelBaseSet";
            labelBaseSet.Size = new Size(72, 30);
            labelBaseSet.TabIndex = 2;
            labelBaseSet.Text = "Базовое множество:";
            // 
            // comboBoxBaseSet
            // 
            comboBoxBaseSet.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBaseSet.FormattingEnabled = true;
            comboBoxBaseSet.Location = new Point(166, 27);
            comboBoxBaseSet.Margin = new Padding(5);
            comboBoxBaseSet.Name = "comboBoxBaseSet";
            comboBoxBaseSet.Size = new Size(197, 23);
            comboBoxBaseSet.TabIndex = 3;
            comboBoxBaseSet.SelectedIndexChanged += comboBoxBaseSet_SelectedIndexChanged;
            // 
            // groupBoxConditions
            // 
            groupBoxConditions.Controls.Add(panelConditions);
            groupBoxConditions.Controls.Add(buttonAddCondition);
            groupBoxConditions.Location = new Point(16, 119);
            groupBoxConditions.Margin = new Padding(5);
            groupBoxConditions.Name = "groupBoxConditions";
            groupBoxConditions.Padding = new Padding(5);
            groupBoxConditions.Size = new Size(400, 381);
            groupBoxConditions.TabIndex = 1;
            groupBoxConditions.TabStop = false;
            groupBoxConditions.Text = "Условия";
            // 
            // panelConditions
            // 
            panelConditions.AutoScroll = true;
            panelConditions.Location = new Point(8, 29);
            panelConditions.Margin = new Padding(5);
            panelConditions.Name = "panelConditions";
            panelConditions.Size = new Size(384, 298);
            panelConditions.TabIndex = 0;
            // 
            // buttonAddCondition
            // 
            buttonAddCondition.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonAddCondition.Location = new Point(9, 336);
            buttonAddCondition.Margin = new Padding(5);
            buttonAddCondition.Name = "buttonAddCondition";
            buttonAddCondition.Size = new Size(336, 26);
            buttonAddCondition.TabIndex = 1;
            buttonAddCondition.Text = "Добавить условие";
            buttonAddCondition.UseVisualStyleBackColor = true;
            buttonAddCondition.Click += buttonAddCondition_Click;
            // 
            // groupBoxActions
            // 
            groupBoxActions.Controls.Add(buttonGenerateCode);
            groupBoxActions.Controls.Add(buttonVisualize);
            groupBoxActions.Location = new Point(16, 502);
            groupBoxActions.Margin = new Padding(5);
            groupBoxActions.Name = "groupBoxActions";
            groupBoxActions.Padding = new Padding(5);
            groupBoxActions.Size = new Size(400, 85);
            groupBoxActions.TabIndex = 2;
            groupBoxActions.TabStop = false;
            groupBoxActions.Text = "Действия";
            // 
            // buttonGenerateCode
            // 
            buttonGenerateCode.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonGenerateCode.Location = new Point(8, 29);
            buttonGenerateCode.Margin = new Padding(5);
            buttonGenerateCode.Name = "buttonGenerateCode";
            buttonGenerateCode.Size = new Size(164, 26);
            buttonGenerateCode.TabIndex = 0;
            buttonGenerateCode.Text = "Сгенерировать";
            buttonGenerateCode.UseVisualStyleBackColor = true;
            buttonGenerateCode.Click += buttonGenerateCode_Click;
            // 
            // buttonVisualize
            // 
            buttonVisualize.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonVisualize.Location = new Point(203, 29);
            buttonVisualize.Margin = new Padding(5);
            buttonVisualize.Name = "buttonVisualize";
            buttonVisualize.Size = new Size(164, 26);
            buttonVisualize.TabIndex = 1;
            buttonVisualize.Text = "Сохранить";
            buttonVisualize.UseVisualStyleBackColor = true;
            buttonVisualize.Click += buttonVisualize_Click;
            // 
            // splitContainer
            // 
            splitContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer.Location = new Point(424, 19);
            splitContainer.Margin = new Padding(5);
            splitContainer.Name = "splitContainer";
            splitContainer.Orientation = Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(textBoxGeneratedCode);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(plotView);
            splitContainer.Size = new Size(605, 568);
            splitContainer.SplitterDistance = 284;
            splitContainer.SplitterWidth = 5;
            splitContainer.TabIndex = 3;
            // 
            // textBoxGeneratedCode
            // 
            textBoxGeneratedCode.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxGeneratedCode.Location = new Point(5, 5);
            textBoxGeneratedCode.Margin = new Padding(5);
            textBoxGeneratedCode.Multiline = true;
            textBoxGeneratedCode.Name = "textBoxGeneratedCode";
            textBoxGeneratedCode.ReadOnly = true;
            textBoxGeneratedCode.ScrollBars = ScrollBars.Vertical;
            textBoxGeneratedCode.Size = new Size(595, 274);
            textBoxGeneratedCode.TabIndex = 0;
            // 
            // plotView
            // 
            plotView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            plotView.Location = new Point(5, 3);
            plotView.Name = "plotView";
            plotView.PanCursor = Cursors.Hand;
            plotView.Size = new Size(595, 272);
            plotView.TabIndex = 1;
            plotView.ZoomHorizontalCursor = Cursors.SizeWE;
            plotView.ZoomRectangleCursor = Cursors.SizeNWSE;
            plotView.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // GenerationMembershipUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pictureBox1);
            Controls.Add(groupBoxActions);
            Controls.Add(groupBoxConditions);
            Controls.Add(groupBoxSettings);
            Margin = new Padding(5);
            MinimumSize = new Size(1061, 605);
            Name = "GenerationMembershipUI";
            Size = new Size(928, 454);
            groupBoxSettings.ResumeLayout(false);
            groupBoxSettings.PerformLayout();
            groupBoxConditions.ResumeLayout(false);
            groupBoxActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.Label labelBaseSet;
        private System.Windows.Forms.GroupBox groupBoxConditions;
        private System.Windows.Forms.Panel panelConditions;
        private System.Windows.Forms.Button buttonAddCondition;
        private System.Windows.Forms.GroupBox groupBoxActions;
        private System.Windows.Forms.Button buttonGenerateCode;
        private System.Windows.Forms.Button buttonVisualize;
        private ComboBox comboBoxBaseSet;
        private TextBox textBox1;
        private Label label1;
        private PictureBox pictureBox1;
    }
}

