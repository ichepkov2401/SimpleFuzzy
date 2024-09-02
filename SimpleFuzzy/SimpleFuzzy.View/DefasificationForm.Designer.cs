namespace SimpleFuzzy.View
{
    partial class DefasificationForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            OutputVariables = new ComboBox();
            MaxProd = new RadioButton();
            MaxMin = new RadioButton();
            MaximumMethod = new RadioButton();
            MethodAverageMax = new RadioButton();
            MetodLeftLineDef = new RadioButton();
            MethodRightLineDef = new RadioButton();
            MethodSenterGravity = new RadioButton();
            MethodsOfInference = new GroupBox();
            MethodsOfDefasification = new GroupBox();
            pictureBox1 = new PictureBox();
            textBox1 = new TextBox();
            pictureBox2 = new PictureBox();
            MethodsOfInference.SuspendLayout();
            MethodsOfDefasification.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // OutputVariables
            // 
            OutputVariables.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            OutputVariables.FormattingEnabled = true;
            OutputVariables.Location = new Point(352, 23);
            OutputVariables.Name = "OutputVariables";
            OutputVariables.Size = new Size(396, 28);
            OutputVariables.TabIndex = 0;
            OutputVariables.SelectedIndexChanged += OutputVariables_SelectedIndexChanged;
            // 
            // MaxProd
            // 
            MaxProd.AutoSize = true;
            MaxProd.Checked = true;
            MaxProd.Location = new Point(10, 20);
            MaxProd.Name = "MaxProd";
            MaxProd.Size = new Size(95, 24);
            MaxProd.TabIndex = 1;
            MaxProd.TabStop = true;
            MaxProd.Text = "Max-Prod";
            MaxProd.UseVisualStyleBackColor = true;
            MaxProd.CheckedChanged += MaxProd_CheckedChanged;
            // 
            // MaxMin
            // 
            MaxMin.AutoSize = true;
            MaxMin.Location = new Point(10, 45);
            MaxMin.Name = "MaxMin";
            MaxMin.Size = new Size(89, 24);
            MaxMin.TabIndex = 2;
            MaxMin.Text = "Max-Min";
            MaxMin.UseVisualStyleBackColor = true;
            // 
            // MaximumMethod
            // 
            MaximumMethod.AutoSize = true;
            MaximumMethod.Checked = true;
            MaximumMethod.Location = new Point(10, 20);
            MaximumMethod.Name = "MaximumMethod";
            MaximumMethod.Size = new Size(157, 24);
            MaximumMethod.TabIndex = 3;
            MaximumMethod.TabStop = true;
            MaximumMethod.Text = "Метод максимума";
            MaximumMethod.UseVisualStyleBackColor = true;
            MaximumMethod.CheckedChanged += MaximumMethod_CheckedChanged;
            // 
            // MethodAverageMax
            // 
            MethodAverageMax.AutoSize = true;
            MethodAverageMax.Location = new Point(10, 69);
            MethodAverageMax.Name = "MethodAverageMax";
            MethodAverageMax.Size = new Size(304, 24);
            MethodAverageMax.TabIndex = 4;
            MethodAverageMax.Text = "Метод среднего значения максимумов";
            MethodAverageMax.UseVisualStyleBackColor = true;
            MethodAverageMax.CheckedChanged += MaximumMethod_CheckedChanged;
            // 
            // MetodLeftLineDef
            // 
            MetodLeftLineDef.AutoSize = true;
            MetodLeftLineDef.Location = new Point(10, 95);
            MetodLeftLineDef.Name = "MetodLeftLineDef";
            MetodLeftLineDef.Size = new Size(316, 24);
            MetodLeftLineDef.TabIndex = 5;
            MetodLeftLineDef.Text = "Метод линейной дефазификации (слева)";
            MetodLeftLineDef.UseVisualStyleBackColor = true;
            MetodLeftLineDef.CheckedChanged += MaximumMethod_CheckedChanged;
            // 
            // MethodRightLineDef
            // 
            MethodRightLineDef.AutoSize = true;
            MethodRightLineDef.Location = new Point(10, 120);
            MethodRightLineDef.Name = "MethodRightLineDef";
            MethodRightLineDef.Size = new Size(326, 24);
            MethodRightLineDef.TabIndex = 6;
            MethodRightLineDef.Text = "Метод линейной дефазификации (справа)";
            MethodRightLineDef.UseVisualStyleBackColor = true;
            MethodRightLineDef.CheckedChanged += MaximumMethod_CheckedChanged;
            // 
            // MethodSenterGravity
            // 
            MethodSenterGravity.AutoSize = true;
            MethodSenterGravity.Location = new Point(10, 45);
            MethodSenterGravity.Name = "MethodSenterGravity";
            MethodSenterGravity.Size = new Size(186, 24);
            MethodSenterGravity.TabIndex = 7;
            MethodSenterGravity.Text = "Метод центра тяжести";
            MethodSenterGravity.UseVisualStyleBackColor = true;
            MethodSenterGravity.CheckedChanged += MaximumMethod_CheckedChanged;
            // 
            // MethodsOfInference
            // 
            MethodsOfInference.Controls.Add(MaxProd);
            MethodsOfInference.Controls.Add(MaxMin);
            MethodsOfInference.Location = new Point(7, 179);
            MethodsOfInference.Name = "MethodsOfInference";
            MethodsOfInference.Size = new Size(171, 77);
            MethodsOfInference.TabIndex = 8;
            MethodsOfInference.TabStop = false;
            MethodsOfInference.Text = "Методы инференции";
            // 
            // MethodsOfDefasification
            // 
            MethodsOfDefasification.Controls.Add(MaximumMethod);
            MethodsOfDefasification.Controls.Add(MethodAverageMax);
            MethodsOfDefasification.Controls.Add(MetodLeftLineDef);
            MethodsOfDefasification.Controls.Add(MethodRightLineDef);
            MethodsOfDefasification.Controls.Add(MethodSenterGravity);
            MethodsOfDefasification.Location = new Point(7, 23);
            MethodsOfDefasification.Name = "MethodsOfDefasification";
            MethodsOfDefasification.Size = new Size(338, 151);
            MethodsOfDefasification.TabIndex = 9;
            MethodsOfDefasification.TabStop = false;
            MethodsOfDefasification.Text = "Методы дефазификации";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Location = new Point(352, 60);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(397, 308);
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(352, 376);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(396, 27);
            textBox1.TabIndex = 11;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox2.Location = new Point(352, 415);
            pictureBox2.Margin = new Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(397, 316);
            pictureBox2.TabIndex = 12;
            pictureBox2.TabStop = false;
            // 
            // DefasificationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pictureBox2);
            Controls.Add(textBox1);
            Controls.Add(pictureBox1);
            Controls.Add(MethodsOfDefasification);
            Controls.Add(MethodsOfInference);
            Controls.Add(OutputVariables);
            Name = "DefasificationForm";
            Size = new Size(760, 738);
            MethodsOfInference.ResumeLayout(false);
            MethodsOfInference.PerformLayout();
            MethodsOfDefasification.ResumeLayout(false);
            MethodsOfDefasification.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox OutputVariables;
        private RadioButton MaxProd;
        private RadioButton MaxMin;
        private RadioButton MaximumMethod;
        private RadioButton MethodAverageMax;
        private RadioButton MetodLeftLineDef;
        private RadioButton MethodRightLineDef;
        private RadioButton MethodSenterGravity;
        private GroupBox MethodsOfInference;
        private GroupBox MethodsOfDefasification;
        private PictureBox pictureBox1;
        private TextBox textBox1;
        private PictureBox pictureBox2;
    }
}
