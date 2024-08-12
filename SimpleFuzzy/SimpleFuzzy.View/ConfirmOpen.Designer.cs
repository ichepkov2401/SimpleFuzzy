namespace SimpleFuzzy.View
{
    partial class ConfirmOpen
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
            groupBox1 = new GroupBox();
            label2 = new MetroFramework.Controls.MetroLabel();
            label1 = new MetroFramework.Controls.MetroLabel();
            textBox1 = new MetroFramework.Controls.MetroTextBox();
            listBox1 = new ListBox();
            button2 = new MetroFramework.Controls.MetroButton();
            button1 = new MetroFramework.Controls.MetroButton();
            groupBox1.SuspendLayout();

            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(listBox1);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button1);
            groupBox1.Location = new Point(3, 160);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(714, 373);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Открытие проекта";

            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.CustomBackground = false;
            label2.FontSize = MetroFramework.MetroLabelSize.Medium;
            label2.FontWeight = MetroFramework.MetroLabelWeight.Light;
            label2.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            label2.Location = new Point(356, 109);
            label2.Name = "label2";
            label2.Size = new Size(46, 20);
            label2.Style = MetroFramework.MetroColorStyle.Blue;
            label2.StyleManager = null;
            label2.TabIndex = 11;
            label2.Text = "label2";
            label2.Theme = MetroFramework.MetroThemeStyle.Light;
            label2.UseStyleColors = false;

            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.CustomBackground = false;
            label1.FontSize = MetroFramework.MetroLabelSize.Medium;
            label1.FontWeight = MetroFramework.MetroLabelWeight.Light;
            label1.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            label1.Location = new Point(356, 21);
            label1.Name = "label1";
            label1.Size = new Size(147, 20);
            label1.Style = MetroFramework.MetroColorStyle.Blue;
            label1.StyleManager = null;
            label1.TabIndex = 10;
            label1.Text = "Введите имя проекта";
            label1.Theme = MetroFramework.MetroThemeStyle.Light;
            label1.UseStyleColors = false;

            // 
            // textBox1
            // 
            textBox1.FontSize = MetroFramework.MetroTextBoxSize.Small;
            textBox1.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            textBox1.Location = new Point(356, 44);
            textBox1.Multiline = false;
            textBox1.Name = "textBox1";
            textBox1.SelectedText = "";
            textBox1.Size = new Size(348, 27);
            textBox1.Style = MetroFramework.MetroColorStyle.Blue;
            textBox1.StyleManager = null;
            textBox1.TabIndex = 8;
            textBox1.Theme = MetroFramework.MetroThemeStyle.Light;
            textBox1.UseStyleColors = false;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // listBox1
            // 
            listBox1.ItemHeight = 20;
            listBox1.Location = new Point(3, 21);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(347, 344);
            listBox1.TabIndex = 7;
            listBox1.DoubleClick += listBox1_DoubleClick;

            // 
            // button2
            // 
            button2.Highlight = false;
            button2.Location = new Point(356, 77);
            button2.Name = "button2";
            button2.Size = new Size(171, 29);
            button2.Style = MetroFramework.MetroColorStyle.Blue;
            button2.StyleManager = null;
            button2.TabIndex = 5;
            button2.Text = "Отмена";
            button2.Theme = MetroFramework.MetroThemeStyle.Light;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Highlight = false;
            button1.Location = new Point(533, 77);
            button1.Name = "button1";
            button1.Size = new Size(171, 27);
            button1.Style = MetroFramework.MetroColorStyle.Blue;
            button1.StyleManager = null;
            button1.TabIndex = 4;
            button1.Text = "Открыть проводник";
            button1.Theme = MetroFramework.MetroThemeStyle.Light;
            button1.Click += button1_Click;
            // 
            // ConfirmOpen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Name = "ConfirmOpen";
            Size = new Size(1062, 552);
            Load += ConfirmOpen_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();

            ResumeLayout(false);
        }

        #endregion


        private GroupBox groupBox1;
        private MetroFramework.Controls.MetroButton button1;
        private MetroFramework.Controls.MetroButton button2;
        private ListBox listBox1;
        private MetroFramework.Controls.MetroTextBox textBox1;
        private MetroFramework.Controls.MetroLabel label1;
        private MetroFramework.Controls.MetroLabel label2;
    }
}
