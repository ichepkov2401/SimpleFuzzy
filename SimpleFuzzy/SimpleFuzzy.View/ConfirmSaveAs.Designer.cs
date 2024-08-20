namespace SimpleFuzzy.View
{
    partial class ConfirmSaveAs
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
            metroLabel1 = new MetroFramework.Controls.MetroLabel();
            metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.Highlight = false;
            button1.Location = new Point(681, 29);
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
            textBox1.Location = new Point(13, 29);
            textBox1.Margin = new Padding(4, 5, 4, 5);
            textBox1.Multiline = false;
            textBox1.Name = "textBox1";
            textBox1.SelectedText = "";
            textBox1.Size = new Size(660, 29);
            textBox1.Style = MetroFramework.MetroColorStyle.Blue;
            textBox1.StyleManager = null;
            textBox1.TabIndex = 2;
            textBox1.Text = "";
            textBox1.Theme = MetroFramework.MetroThemeStyle.Light;
            textBox1.UseStyleColors = false;
            // 
            // button2
            // 
            button2.Highlight = false;
            button2.Location = new Point(467, 63);
            button2.Margin = new Padding(4, 5, 4, 5);
            button2.Name = "button2";
            button2.Size = new Size(206, 29);
            button2.Style = MetroFramework.MetroColorStyle.Blue;
            button2.StyleManager = null;
            button2.TabIndex = 3;
            button2.Text = "Сохранить";
            button2.Theme = MetroFramework.MetroThemeStyle.Light;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Highlight = false;
            button3.Location = new Point(681, 63);
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
            groupBox1.ForeColor = SystemColors.ControlText;
            groupBox1.Location = new Point(4, 4);
            groupBox1.Margin = new Padding(4, 5, 4, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 5, 4, 5);
            groupBox1.Size = new Size(893, 100);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Сохранить проект как";
            // 
            // metroLabel1
            // 
            metroLabel1.AutoSize = true;
            metroLabel1.CustomBackground = false;
            metroLabel1.FontSize = MetroFramework.MetroLabelSize.Medium;
            metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Light;
            metroLabel1.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            metroLabel1.Location = new Point(13, 63);
            metroLabel1.Name = "metroLabel1";
            metroLabel1.Size = new Size(91, 20);
            metroLabel1.Style = MetroFramework.MetroColorStyle.Blue;
            metroLabel1.StyleManager = null;
            metroLabel1.TabIndex = 6;
            metroLabel1.Text = "Введите имя";
            metroLabel1.Theme = MetroFramework.MetroThemeStyle.Light;
            metroLabel1.UseStyleColors = false;
            // 
            // metroTextBox1
            // 
            metroTextBox1.FontSize = MetroFramework.MetroTextBoxSize.Small;
            metroTextBox1.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            metroTextBox1.Location = new Point(110, 63);
            metroTextBox1.Multiline = false;
            metroTextBox1.Name = "metroTextBox1";
            metroTextBox1.SelectedText = "";
            metroTextBox1.Size = new Size(350, 29);
            metroTextBox1.Style = MetroFramework.MetroColorStyle.Blue;
            metroTextBox1.StyleManager = null;
            metroTextBox1.TabIndex = 7;
            metroTextBox1.Theme = MetroFramework.MetroThemeStyle.Light;
            metroTextBox1.UseStyleColors = false;
            // 
            // ConfirmSaveAs
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(metroTextBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(metroLabel1);
            Controls.Add(groupBox1);
            Name = "ConfirmSaveAs";
            Size = new Size(901, 113);
            Load += ConfirmCopy_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MetroFramework.Controls.MetroButton button1;
        private MetroFramework.Controls.MetroTextBox textBox1;
        private MetroFramework.Controls.MetroButton button2;
        private MetroFramework.Controls.MetroButton button3;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox metroTextBox1;
    }
}
