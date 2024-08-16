namespace SimpleFuzzy.View
{
    partial class ConfirmCopy
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
            textBox1 = new MetroFramework.Controls.MetroTextBox();
            button2 = new MetroFramework.Controls.MetroButton();
            button3 = new MetroFramework.Controls.MetroButton();
            groupBox1 = new GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.Highlight = false;
            button1.Location = new Point(681, 30);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(206, 29);
            button1.Style = MetroFramework.MetroColorStyle.Blue;
            button1.StyleManager = null;
            button1.TabIndex = 1;
            button1.Text = "Открыть проводник";
            button1.Theme = MetroFramework.MetroThemeStyle.Light;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.ActiveBorder;
            textBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.FontSize = MetroFramework.MetroTextBoxSize.Small;
            textBox1.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            textBox1.ForeColor = SystemColors.ControlText;
            textBox1.Location = new Point(13, 30);
            textBox1.Margin = new Padding(4, 5, 4, 5);
            textBox1.Multiline = false;
            textBox1.Name = "textBox1";
            textBox1.SelectedText = "";
            textBox1.Size = new Size(660, 29);
            textBox1.Style = MetroFramework.MetroColorStyle.Blue;
            textBox1.StyleManager = null;
            textBox1.TabIndex = 2;
            textBox1.Text = Directory.GetCurrentDirectory() + "\\Projects";
            textBox1.Theme = MetroFramework.MetroThemeStyle.Light;
            textBox1.UseStyleColors = false;
            // 
            // button2
            // 
            button2.Highlight = false;
            button2.Location = new Point(467, 68);
            button2.Margin = new Padding(4, 5, 4, 5);
            button2.Name = "button2";
            button2.Size = new Size(206, 29);
            button2.Style = MetroFramework.MetroColorStyle.Blue;
            button2.StyleManager = null;
            button2.TabIndex = 3;
            button2.Text = "Готово";
            button2.Theme = MetroFramework.MetroThemeStyle.Light;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Highlight = false;
            button3.Location = new Point(681, 68);
            button3.Margin = new Padding(4, 5, 4, 5);
            button3.Name = "button3";
            button3.Size = new Size(206, 29);
            button3.Style = MetroFramework.MetroColorStyle.Blue;
            button3.StyleManager = null;
            button3.TabIndex = 4;
            button3.Text = "Отмена";
            button3.Theme = MetroFramework.MetroThemeStyle.Light;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button1);
            groupBox1.ForeColor = SystemColors.ControlText;
            groupBox1.Location = new Point(4, 4);
            groupBox1.Margin = new Padding(4, 5, 4, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 5, 4, 5);
            groupBox1.Size = new Size(904, 106);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Копирование проекта";
            // 
            // ConfirmCopy
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(groupBox1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "ConfirmCopy";
            Size = new Size(912, 114);
            Load += ConfirmCopy_Load;
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private MetroFramework.Controls.MetroButton button1;
        private MetroFramework.Controls.MetroTextBox textBox1;
        private MetroFramework.Controls.MetroButton button2;
        private MetroFramework.Controls.MetroButton button3;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
