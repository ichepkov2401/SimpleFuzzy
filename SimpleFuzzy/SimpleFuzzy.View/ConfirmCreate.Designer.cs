namespace SimpleFuzzy.View
{
    partial class ConfirmCreate
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
            button1 = new MetroFramework.Controls.MetroButton();
            groupBox1 = new GroupBox();
            button3 = new MetroFramework.Controls.MetroButton();
            textBox1 = new MetroFramework.Controls.MetroTextBox();
            textBox2 = new MetroFramework.Controls.MetroTextBox();
            button2 = new MetroFramework.Controls.MetroButton();
            groupBox2 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            // 
            // button1
            // 
            button1.Highlight = false;
            button1.Location = new Point(653, 24);
            button1.Name = "button1";
            button1.Size = new Size(202, 29);
            button1.Style = MetroFramework.MetroColorStyle.Blue;
            button1.StyleManager = null;
            button1.TabIndex = 0;
            button1.Text = "Готово";
            button1.Theme = MetroFramework.MetroThemeStyle.Light;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(button1);
            groupBox1.Location = new Point(23, 198);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(867, 68);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Введите имя проекта";
            // 
            // button3
            // 
            button3.Highlight = false;
            button3.Location = new Point(445, 24);
            button3.Name = "button3";
            button3.Size = new Size(202, 29);
            button3.Style = MetroFramework.MetroColorStyle.Blue;
            button3.StyleManager = null;
            button3.TabIndex = 7;
            button3.Text = "Отмена";
            button3.Theme = MetroFramework.MetroThemeStyle.Light;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // textBox1
            // 
            textBox1.FontSize = MetroFramework.MetroTextBoxSize.Small;
            textBox1.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            textBox1.Location = new Point(6, 26);
            textBox1.Multiline = false;
            textBox1.Name = "textBox1";
            textBox1.SelectedText = "";
            textBox1.Size = new Size(433, 27);
            textBox1.Style = MetroFramework.MetroColorStyle.Blue;
            textBox1.StyleManager = null;
            textBox1.TabIndex = 3;
            textBox1.Theme = MetroFramework.MetroThemeStyle.Light;
            textBox1.UseStyleColors = false;
            // 
            // textBox2
            // 
            textBox2.FontSize = MetroFramework.MetroTextBoxSize.Small;
            textBox2.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            textBox2.Location = new Point(12, 26);
            textBox2.Multiline = false;
            textBox2.Name = "textBox2";
            textBox2.SelectedText = "";
            textBox2.Size = new Size(635, 27);
            textBox2.Style = MetroFramework.MetroColorStyle.Blue;
            textBox2.StyleManager = null;
            textBox2.TabIndex = 4;
            textBox2.Text = Directory.GetCurrentDirectory() + "\\Projects";
            textBox2.Theme = MetroFramework.MetroThemeStyle.Light;
            textBox2.UseStyleColors = false;
            // 
            // button2
            // 
            button2.Highlight = false;
            button2.Location = new Point(653, 26);
            button2.Name = "button2";
            button2.Size = new Size(202, 29);
            button2.Style = MetroFramework.MetroColorStyle.Blue;
            button2.StyleManager = null;
            button2.TabIndex = 5;
            button2.Text = "Открыть проводник";
            button2.Theme = MetroFramework.MetroThemeStyle.Light;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.Transparent;
            groupBox2.Controls.Add(textBox2);
            groupBox2.Controls.Add(button2);
            groupBox2.Location = new Point(23, 127);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(867, 65);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Расположение";
            // 
            // ConfirmCreate
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Name = "ConfirmCreate";
            Size = new Size(1434, 559);
            Load += ConfirmCreate_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private MetroFramework.Controls.MetroButton button1;
        private GroupBox groupBox1;
        private MetroFramework.Controls.MetroTextBox textBox1;
        private MetroFramework.Controls.MetroTextBox textBox2;
        private MetroFramework.Controls.MetroButton button2;
        private GroupBox groupBox2;
        private MetroFramework.Controls.MetroButton button3;
    }
}
