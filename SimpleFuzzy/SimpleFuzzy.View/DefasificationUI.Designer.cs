namespace SimpleFuzzy.View
{
    partial class DefasificationUI
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
            Graphic = new Label();
            DefasificationResult = new Label();
            SuspendLayout();
            // 
            // Graphic
            // 
            Graphic.AutoSize = true;
            Graphic.Location = new Point(10, 100);
            Graphic.Name = "Graphic";
            Graphic.Size = new Size(125, 20);
            Graphic.TabIndex = 0;
            Graphic.Text = "Тут будет график";
            // 
            // DefasificationResult
            // 
            DefasificationResult.AutoSize = true;
            DefasificationResult.Location = new Point(10, 150);
            DefasificationResult.Name = "DefasificationResult";
            DefasificationResult.Size = new Size(265, 20);
            DefasificationResult.TabIndex = 1;
            DefasificationResult.Text = "Запись о результате дефазификации";
            // 
            // DefasificationUI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(DefasificationResult);
            Controls.Add(Graphic);
            Name = "DefasificationUI";
            Size = new Size(738, 436);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Graphic;
        private Label DefasificationResult;
    }
}
