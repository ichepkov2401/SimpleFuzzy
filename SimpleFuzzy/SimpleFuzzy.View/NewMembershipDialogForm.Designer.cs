namespace SimpleFuzzy.View
{
    partial class NewMembershipDialogForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            metroRadioButton1 = new MetroFramework.Controls.MetroRadioButton();
            metroRadioButton2 = new MetroFramework.Controls.MetroRadioButton();
            SuspendLayout();
            // 
            // metroRadioButton1
            // 
            metroRadioButton1.AutoSize = true;
            metroRadioButton1.Checked = true;
            metroRadioButton1.CustomBackground = false;
            metroRadioButton1.FontSize = MetroFramework.MetroLinkSize.Small;
            metroRadioButton1.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            metroRadioButton1.Location = new Point(12, 12);
            metroRadioButton1.Name = "metroRadioButton1";
            metroRadioButton1.Size = new Size(258, 15);
            metroRadioButton1.Style = MetroFramework.MetroColorStyle.Blue;
            metroRadioButton1.StyleManager = null;
            metroRadioButton1.TabIndex = 0;
            metroRadioButton1.TabStop = true;
            metroRadioButton1.Text = "Сгенерировать функцию принадлежности";
            metroRadioButton1.Theme = MetroFramework.MetroThemeStyle.Light;
            metroRadioButton1.UseStyleColors = false;
            metroRadioButton1.UseVisualStyleBackColor = true;
            metroRadioButton1.CheckedChanged += metroRadioButton1_CheckedChanged;
            // 
            // metroRadioButton2
            // 
            metroRadioButton2.AutoSize = true;
            metroRadioButton2.CustomBackground = false;
            metroRadioButton2.FontSize = MetroFramework.MetroLinkSize.Small;
            metroRadioButton2.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            metroRadioButton2.Location = new Point(276, 12);
            metroRadioButton2.Name = "metroRadioButton2";
            metroRadioButton2.Size = new Size(206, 15);
            metroRadioButton2.Style = MetroFramework.MetroColorStyle.Blue;
            metroRadioButton2.StyleManager = null;
            metroRadioButton2.TabIndex = 1;
            metroRadioButton2.Text = "Задать терм нечеткой операцией";
            metroRadioButton2.Theme = MetroFramework.MetroThemeStyle.Light;
            metroRadioButton2.UseStyleColors = false;
            metroRadioButton2.UseVisualStyleBackColor = true;
            // 
            // NewMembershipDialogForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(705, 328);
            Controls.Add(metroRadioButton2);
            Controls.Add(metroRadioButton1);
            Name = "NewMembershipDialogForm";
            Text = "NewMembershipDialogForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MetroFramework.Controls.MetroRadioButton metroRadioButton1;
        private MetroFramework.Controls.MetroRadioButton metroRadioButton2;
    }
}