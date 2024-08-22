namespace SimpleFuzzy.View
{
    partial class InferenceForm
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            outputVariableComboBox = new ComboBox();
            outputVariableLabel = new Label();
            windowHeaderLabel = new Label();
            AddInbutton = new Button();
            inputVariablesComboBox = new ComboBox();
            label1 = new Label();
            dataTable = new DataGridView();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataTable).BeginInit();
            SuspendLayout();
            // 
            // outputVariableComboBox
            // 
            outputVariableComboBox.Location = new Point(181, 49);
            outputVariableComboBox.Name = "outputVariableComboBox";
            outputVariableComboBox.Size = new Size(194, 28);
            outputVariableComboBox.TabIndex = 0;
            outputVariableComboBox.SelectedIndexChanged += OutputVariableComboBox_SelectedIndexChanged;
            // 
            // outputVariableLabel
            // 
            outputVariableLabel.AutoSize = true;
            outputVariableLabel.Location = new Point(3, 52);
            outputVariableLabel.Name = "outputVariableLabel";
            outputVariableLabel.Size = new Size(175, 20);
            outputVariableLabel.TabIndex = 1;
            outputVariableLabel.Text = "Выходные переменные";
            // 
            // windowHeaderLabel
            // 
            windowHeaderLabel.AutoSize = true;
            windowHeaderLabel.Location = new Point(384, 10);
            windowHeaderLabel.Name = "windowHeaderLabel";
            windowHeaderLabel.Size = new Size(144, 20);
            windowHeaderLabel.TabIndex = 2;
            windowHeaderLabel.Text = "РЕДАКТОР ПРАВИЛ";
            // 
            // AddInbutton
            // 
            AddInbutton.Location = new Point(370, 95);
            AddInbutton.Name = "AddInbutton";
            AddInbutton.Size = new Size(152, 29);
            AddInbutton.TabIndex = 3;
            AddInbutton.Text = "Добавить ЛП";
            AddInbutton.UseVisualStyleBackColor = true;
            AddInbutton.Click += AddInbutton_Click;
            // 
            // inputVariablesComboBox
            // 
            inputVariablesComboBox.FormattingEnabled = true;
            inputVariablesComboBox.Location = new Point(170, 95);
            inputVariablesComboBox.Name = "inputVariablesComboBox";
            inputVariablesComboBox.Size = new Size(194, 28);
            inputVariablesComboBox.TabIndex = 4;
            inputVariablesComboBox.SelectedIndexChanged += inputVariablesComboBox_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 95);
            label1.Name = "label1";
            label1.Size = new Size(164, 20);
            label1.TabIndex = 5;
            label1.Text = "Входные переменные";
            // 
            // dataTable
            // 
            dataTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataTable.Location = new Point(3, 129);
            dataTable.Name = "dataTable";
            dataTable.RowHeadersWidth = 51;
            dataTable.RowTemplate.Height = 29;
            dataTable.Size = new Size(651, 345);
            dataTable.TabIndex = 7;
            // 
            // button1
            // 
            button1.Location = new Point(805, 64);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 8;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // InferenceForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button1);
            Controls.Add(dataTable);
            Controls.Add(label1);
            Controls.Add(inputVariablesComboBox);
            Controls.Add(AddInbutton);
            Controls.Add(windowHeaderLabel);
            Controls.Add(outputVariableLabel);
            Controls.Add(outputVariableComboBox);
            Name = "InferenceForm";
            Size = new Size(941, 490);
            ((System.ComponentModel.ISupportInitialize)dataTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox outputVariableComboBox;
        private Label outputVariableLabel;
        private Label windowHeaderLabel;
        private Button AddInbutton;
        private ComboBox inputVariablesComboBox;
        private Label label1;
        private DataGridView dataTable;
        private Button button1;
    }
}
