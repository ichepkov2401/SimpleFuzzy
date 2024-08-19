namespace SimpleFuzzy.View
{
    partial class FuzzyOperationUI
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            operand1 = new MetroFramework.Controls.MetroComboBox();
            Uno = new MetroFramework.Controls.MetroRadioButton();
            Bin = new MetroFramework.Controls.MetroRadioButton();
            nameLabel = new MetroFramework.Controls.MetroLabel();
            nameTextBox = new MetroFramework.Controls.MetroTextBox();
            operations = new MetroFramework.Controls.MetroComboBox();
            operand2 = new MetroFramework.Controls.MetroComboBox();
            okButton = new MetroFramework.Controls.MetroButton();
            cancelButton = new MetroFramework.Controls.MetroButton();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // operand1
            // 
            operand1.DrawMode = DrawMode.OwnerDrawFixed;
            operand1.DropDownStyle = ComboBoxStyle.DropDownList;
            operand1.FontSize = MetroFramework.MetroLinkSize.Medium;
            operand1.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            operand1.FormattingEnabled = true;
            operand1.ItemHeight = 23;
            operand1.Location = new Point(0, 72);
            operand1.Name = "operand1";
            operand1.Size = new Size(125, 29);
            operand1.Style = MetroFramework.MetroColorStyle.Blue;
            operand1.StyleManager = null;
            operand1.TabIndex = 0;
            operand1.Theme = MetroFramework.MetroThemeStyle.Light;
            operand1.SelectedIndexChanged += operand1_SelectedIndexChanged;
            // 
            // Uno
            // 
            Uno.AutoSize = true;
            Uno.CustomBackground = false;
            Uno.FontSize = MetroFramework.MetroLinkSize.Small;
            Uno.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            Uno.Location = new Point(0, 51);
            Uno.Name = "Uno";
            Uno.Size = new Size(125, 15);
            Uno.Style = MetroFramework.MetroColorStyle.Blue;
            Uno.StyleManager = null;
            Uno.TabIndex = 1;
            Uno.TabStop = true;
            Uno.Text = "Унарная операция";
            Uno.Theme = MetroFramework.MetroThemeStyle.Light;
            Uno.UseStyleColors = false;
            Uno.UseVisualStyleBackColor = true;
            Uno.CheckedChanged += Uno_CheckedChanged;
            // 
            // Bin
            // 
            Bin.AutoSize = true;
            Bin.CustomBackground = false;
            Bin.FontSize = MetroFramework.MetroLinkSize.Small;
            Bin.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            Bin.Location = new Point(255, 51);
            Bin.Name = "Bin";
            Bin.Size = new Size(132, 15);
            Bin.Style = MetroFramework.MetroColorStyle.Blue;
            Bin.StyleManager = null;
            Bin.TabIndex = 2;
            Bin.Text = "Бинарная операция";
            Bin.Theme = MetroFramework.MetroThemeStyle.Light;
            Bin.UseStyleColors = false;
            Bin.UseVisualStyleBackColor = true;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.CustomBackground = false;
            nameLabel.FontSize = MetroFramework.MetroLabelSize.Medium;
            nameLabel.FontWeight = MetroFramework.MetroLabelWeight.Light;
            nameLabel.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            nameLabel.Location = new Point(0, 0);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(156, 19);
            nameLabel.Style = MetroFramework.MetroColorStyle.Blue;
            nameLabel.StyleManager = null;
            nameLabel.TabIndex = 3;
            nameLabel.Text = "Имя нового множества:";
            nameLabel.Theme = MetroFramework.MetroThemeStyle.Light;
            nameLabel.UseStyleColors = false;
            // 
            // nameTextBox
            // 
            nameTextBox.FontSize = MetroFramework.MetroTextBoxSize.Small;
            nameTextBox.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            nameTextBox.Location = new Point(0, 22);
            nameTextBox.Multiline = false;
            nameTextBox.Name = "nameTextBox";
            nameTextBox.SelectedText = "";
            nameTextBox.Size = new Size(387, 23);
            nameTextBox.Style = MetroFramework.MetroColorStyle.Blue;
            nameTextBox.StyleManager = null;
            nameTextBox.TabIndex = 4;
            nameTextBox.Theme = MetroFramework.MetroThemeStyle.Light;
            nameTextBox.UseStyleColors = false;
            nameTextBox.Leave += nameTextBox_Leave;
            // 
            // operations
            // 
            operations.DrawMode = DrawMode.OwnerDrawFixed;
            operations.DropDownStyle = ComboBoxStyle.DropDownList;
            operations.FontSize = MetroFramework.MetroLinkSize.Medium;
            operations.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            operations.FormattingEnabled = true;
            operations.ItemHeight = 23;
            operations.Location = new Point(131, 72);
            operations.Name = "operations";
            operations.Size = new Size(125, 29);
            operations.Style = MetroFramework.MetroColorStyle.Blue;
            operations.StyleManager = null;
            operations.TabIndex = 5;
            operations.Theme = MetroFramework.MetroThemeStyle.Light;
            operations.SelectedIndexChanged += operations_SelectedIndexChanged;
            // 
            // operand2
            // 
            operand2.DrawMode = DrawMode.OwnerDrawFixed;
            operand2.DropDownStyle = ComboBoxStyle.DropDownList;
            operand2.FontSize = MetroFramework.MetroLinkSize.Medium;
            operand2.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            operand2.FormattingEnabled = true;
            operand2.ItemHeight = 23;
            operand2.Location = new Point(262, 72);
            operand2.Name = "operand2";
            operand2.Size = new Size(125, 29);
            operand2.Style = MetroFramework.MetroColorStyle.Blue;
            operand2.StyleManager = null;
            operand2.TabIndex = 6;
            operand2.Theme = MetroFramework.MetroThemeStyle.Light;
            operand2.SelectedIndexChanged += operand2_SelectedIndexChanged;
            // 
            // okButton
            // 
            okButton.Highlight = false;
            okButton.Location = new Point(0, 135);
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 23);
            okButton.Style = MetroFramework.MetroColorStyle.Blue;
            okButton.StyleManager = null;
            okButton.TabIndex = 7;
            okButton.Text = "Сохранить";
            okButton.Theme = MetroFramework.MetroThemeStyle.Light;
            okButton.Click += okButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Highlight = false;
            cancelButton.Location = new Point(81, 135);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.Style = MetroFramework.MetroColorStyle.Blue;
            cancelButton.StyleManager = null;
            cancelButton.TabIndex = 8;
            cancelButton.Text = "Удалить";
            cancelButton.Theme = MetroFramework.MetroThemeStyle.Light;
            cancelButton.Click += cancelButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(393, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(313, 155);
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // FuzzyOperationUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            Controls.Add(pictureBox1);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(operand2);
            Controls.Add(operations);
            Controls.Add(nameTextBox);
            Controls.Add(nameLabel);
            Controls.Add(Bin);
            Controls.Add(Uno);
            Controls.Add(operand1);
            Name = "FuzzyOperationUI";
            Size = new Size(718, 184);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MetroFramework.Controls.MetroComboBox operand1;
        private MetroFramework.Controls.MetroRadioButton Uno;
        private MetroFramework.Controls.MetroRadioButton Bin;
        private MetroFramework.Controls.MetroLabel nameLabel;
        private MetroFramework.Controls.MetroTextBox nameTextBox;
        private MetroFramework.Controls.MetroComboBox operations;
        private MetroFramework.Controls.MetroComboBox operand2;
        private MetroFramework.Controls.MetroButton okButton;
        private MetroFramework.Controls.MetroButton cancelButton;
        private PictureBox pictureBox1;
    }
}
