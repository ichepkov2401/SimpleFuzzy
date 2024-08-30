
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
            groupBoxSettings.Location = new Point(13, 19);
            groupBoxSettings.Margin = new Padding(5);
            groupBoxSettings.Name = "groupBoxSettings";
            groupBoxSettings.Padding = new Padding(4);
            groupBoxSettings.Size = new Size(400, 125);
            groupBoxSettings.TabIndex = 0;
            groupBoxSettings.TabStop = false;
            groupBoxSettings.Text = "Настройки";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(133, 88);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(257, 27);
            textBox1.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 32);
            label1.Name = "label1";
            label1.Size = new Size(108, 40);
            label1.TabIndex = 4;
            label1.Text = "Имя базового\r\nмножества:";
            // 
            // labelBaseSet
            // 
            labelBaseSet.AutoSize = true;
            labelBaseSet.Location = new Point(8, 78);
            labelBaseSet.Margin = new Padding(4, 0, 4, 0);
            labelBaseSet.MaximumSize = new Size(116, 0);
            labelBaseSet.Name = "labelBaseSet";
            labelBaseSet.Size = new Size(90, 40);
            labelBaseSet.TabIndex = 2;
            labelBaseSet.Text = "Базовое множество:";
            // 
            // comboBoxBaseSet
            // 
            comboBoxBaseSet.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBaseSet.FormattingEnabled = true;
            comboBoxBaseSet.Location = new Point(133, 32);
            comboBoxBaseSet.Margin = new Padding(5);
            comboBoxBaseSet.Name = "comboBoxBaseSet";
            comboBoxBaseSet.Size = new Size(257, 28);
            comboBoxBaseSet.TabIndex = 3;
            comboBoxBaseSet.SelectedIndexChanged += comboBoxBaseSet_SelectedIndexChanged;
            // 
            // groupBoxConditions
            // 
            groupBoxConditions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            groupBoxConditions.Controls.Add(panelConditions);
            groupBoxConditions.Controls.Add(buttonAddCondition);
            groupBoxConditions.Location = new Point(13, 144);
            groupBoxConditions.Margin = new Padding(4);
            groupBoxConditions.Name = "groupBoxConditions";
            groupBoxConditions.Padding = new Padding(5);
            groupBoxConditions.Size = new Size(400, 211);
            groupBoxConditions.TabIndex = 1;
            groupBoxConditions.TabStop = false;
            groupBoxConditions.Text = "Условия";
            // 
            // panelConditions
            // 
            panelConditions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panelConditions.AutoScroll = true;
            panelConditions.Location = new Point(8, 29);
            panelConditions.Margin = new Padding(5);
            panelConditions.Name = "panelConditions";
            panelConditions.Size = new Size(384, 128);
            panelConditions.TabIndex = 0;
            // 
            // buttonAddCondition
            // 
            buttonAddCondition.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonAddCondition.Location = new Point(9, 166);
            buttonAddCondition.Margin = new Padding(5);
            buttonAddCondition.Name = "buttonAddCondition";
            buttonAddCondition.Size = new Size(384, 35);
            buttonAddCondition.TabIndex = 1;
            buttonAddCondition.Text = "Добавить условие";
            buttonAddCondition.UseVisualStyleBackColor = true;
            buttonAddCondition.Click += buttonAddCondition_Click;
            // 
            // groupBoxActions
            // 
            groupBoxActions.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            groupBoxActions.Controls.Add(buttonGenerateCode);
            groupBoxActions.Controls.Add(buttonVisualize);
            groupBoxActions.Location = new Point(13, 363);
            groupBoxActions.Margin = new Padding(4);
            groupBoxActions.Name = "groupBoxActions";
            groupBoxActions.Padding = new Padding(4);
            groupBoxActions.Size = new Size(401, 64);
            groupBoxActions.TabIndex = 2;
            groupBoxActions.TabStop = false;
            groupBoxActions.Text = "Действия";
            // 
            // buttonGenerateCode
            // 
            buttonGenerateCode.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonGenerateCode.Location = new Point(9, 20);
            buttonGenerateCode.Margin = new Padding(5);
            buttonGenerateCode.Name = "buttonGenerateCode";
            buttonGenerateCode.Size = new Size(187, 35);
            buttonGenerateCode.TabIndex = 0;
            buttonGenerateCode.Text = "Сгенерировать";
            buttonGenerateCode.UseVisualStyleBackColor = true;
            buttonGenerateCode.Click += buttonGenerateCode_Click;
            // 
            // buttonVisualize
            // 
            buttonVisualize.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonVisualize.Location = new Point(204, 20);
            buttonVisualize.Margin = new Padding(5);
            buttonVisualize.Name = "buttonVisualize";
            buttonVisualize.Size = new Size(187, 35);
            buttonVisualize.TabIndex = 1;
            buttonVisualize.Text = "Сохранить";
            buttonVisualize.UseVisualStyleBackColor = true;
            buttonVisualize.Click += buttonVisualize_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(421, 19);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(543, 408);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // GenerationMembershipUI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pictureBox1);
            Controls.Add(groupBoxActions);
            Controls.Add(groupBoxConditions);
            Controls.Add(groupBoxSettings);
            Margin = new Padding(5);
            Name = "GenerationMembershipUI";
            Size = new Size(970, 436);
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

