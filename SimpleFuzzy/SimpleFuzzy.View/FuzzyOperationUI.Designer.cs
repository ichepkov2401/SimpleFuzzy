﻿namespace SimpleFuzzy.View
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
            operand1 = new ComboBox();
            Uno = new RadioButton();
            Bin = new RadioButton();
            nameLabel = new Label();
            pLabel = new Label();
            nameTextBox = new TextBox();
            operations = new ComboBox();
            operand2 = new ComboBox();
            okButton = new Button();
            cancelButton = new Button();
            pictureBox1 = new PictureBox();
            pNumericUpDown = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // operand1
            // 
            operand1.FormattingEnabled = true;
            operand1.Location = new Point(3, 100);
            operand1.Margin = new Padding(3, 4, 3, 4);
            operand1.Name = "operand1";
            operand1.Size = new Size(140, 28);
            operand1.TabIndex = 0;
            operand1.SelectedIndexChanged += operand1_SelectedIndexChanged;
            // 
            // Uno
            // 
            Uno.AutoSize = true;
            Uno.Location = new Point(3, 68);
            Uno.Margin = new Padding(3, 4, 3, 4);
            Uno.Name = "Uno";
            Uno.Size = new Size(163, 24);
            Uno.TabIndex = 1;
            Uno.TabStop = true;
            Uno.Text = "Унарная операция";
            Uno.UseVisualStyleBackColor = true;
            Uno.CheckedChanged += Uno_CheckedChanged;
            // 
            // Bin
            // 
            Bin.AutoSize = true;
            Bin.Location = new Point(271, 68);
            Bin.Margin = new Padding(3, 4, 3, 4);
            Bin.Name = "Bin";
            Bin.Size = new Size(172, 24);
            Bin.TabIndex = 2;
            Bin.Text = "Бинарная операция";
            Bin.UseVisualStyleBackColor = true;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(3, 4);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(143, 20);
            nameLabel.TabIndex = 12;
            nameLabel.Text = "Введите имя терма";
            // 
            // pLabel
            // 
            pLabel.Location = new Point(3, 155);
            pLabel.Name = "pLabel";
            pLabel.Size = new Size(190, 23);
            pLabel.TabIndex = 13;
            pLabel.Text = "Введите значение параметра \"p\"";
            pLabel.Visible = false;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(3, 24);
            nameTextBox.Margin = new Padding(3, 4, 3, 4);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(432, 27);
            nameTextBox.TabIndex = 5;
            nameTextBox.Leave += nameTextBox_Leave;
            // 
            // operations
            // 
            operations.FormattingEnabled = true;
            operations.ItemHeight = 20;
            operations.Location = new Point(149, 100);
            operations.Margin = new Padding(3, 4, 3, 4);
            operations.Name = "operations";
            operations.Size = new Size(140, 28);
            operations.TabIndex = 7;
            operations.SelectedIndexChanged += operations_SelectedIndexChanged;
            // 
            // operand2
            // 
            operand2.FormattingEnabled = true;
            operand2.ItemHeight = 20;
            operand2.Location = new Point(295, 100);
            operand2.Margin = new Padding(3, 4, 3, 4);
            operand2.Name = "operand2";
            operand2.Size = new Size(140, 28);
            operand2.TabIndex = 8;
            operand2.SelectedIndexChanged += operand2_SelectedIndexChanged;
            // 
            // okButton
            // 
            okButton.Location = new Point(3, 210);
            okButton.Margin = new Padding(3, 4, 3, 4);
            okButton.Name = "okButton";
            okButton.Size = new Size(99, 31);
            okButton.TabIndex = 9;
            okButton.Text = "Сохранить";
            okButton.Click += okButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(108, 210);
            cancelButton.Margin = new Padding(3, 4, 3, 4);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(99, 31);
            cancelButton.TabIndex = 10;
            cancelButton.Text = "Удалить";
            cancelButton.Click += cancelButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(441, 4);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(366, 207);
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // pNumericUpDown
            // 
            pNumericUpDown.Visible = false;
            pNumericUpDown.Location = new Point(139, 153);
            pNumericUpDown.Name = "pNumericUpDown";
            pNumericUpDown.Size = new Size(150, 27);
            pNumericUpDown.TabIndex = 14;
            pNumericUpDown.ValueChanged += pNumericUpDown_ValueChanged;
            pNumericUpDown.Minimum = (decimal)Double.Epsilon;
            pNumericUpDown.Maximum = 1;
            pNumericUpDown.Increment = (decimal)0.1;
            pNumericUpDown.DecimalPlaces = 2;
            // 
            // FuzzyOperationUI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            Controls.Add(pNumericUpDown);
            Controls.Add(pictureBox1);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(operand2);
            Controls.Add(operations);
            Controls.Add(nameTextBox);
            Controls.Add(nameLabel);
            Controls.Add(pLabel);
            Controls.Add(Bin);
            Controls.Add(Uno);
            Controls.Add(operand1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FuzzyOperationUI";
            Size = new Size(821, 245);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox operand1;
        private RadioButton Uno;
        private RadioButton Bin;
        private Label nameLabel;
        private Label pLabel;
        private TextBox nameTextBox;
        private ComboBox operations;
        private ComboBox operand2;
        private Button okButton;
        private Button cancelButton;
        private PictureBox pictureBox1;
        private NumericUpDown pNumericUpDown;
    }
}
