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
            inputVariableLabel = new Label();
            stringsListView = new ListView();
            stringsListViewСolumnHeader = new ColumnHeader();
            StringsCloseButtons = new ColumnHeader();
            columnsListView = new ListView();
            columnsListViewСolumnHeader = new ColumnHeader();
            columnsCloseButtons = new ColumnHeader();
            columnsComboBox = new ComboBox();
            stringsComboBox = new ComboBox();
            SuspendLayout();
            // 
            // outputVariableComboBox
            // 
            outputVariableComboBox.Location = new Point(420, 72);
            outputVariableComboBox.Name = "outputVariableComboBox";
            outputVariableComboBox.Size = new Size(194, 28);
            outputVariableComboBox.TabIndex = 0;
            outputVariableComboBox.SelectedIndexChanged += OutputVariableComboBox_SelectedIndexChanged;
            // 
            // outputVariableLabel
            // 
            outputVariableLabel.AutoSize = true;
            outputVariableLabel.Location = new Point(242, 75);
            outputVariableLabel.Name = "outputVariableLabel";
            outputVariableLabel.Size = new Size(172, 20);
            outputVariableLabel.TabIndex = 1;
            outputVariableLabel.Text = "Выходная переменная:";
            // 
            // windowHeaderLabel
            // 
            windowHeaderLabel.AutoSize = true;
            windowHeaderLabel.Location = new Point(406, 19);
            windowHeaderLabel.Name = "windowHeaderLabel";
            windowHeaderLabel.Size = new Size(144, 20);
            windowHeaderLabel.TabIndex = 2;
            windowHeaderLabel.Text = "РЕДАКТОР ПРАВИЛ";
            // 
            // inputVariableLabel
            // 
            inputVariableLabel.AutoSize = true;
            inputVariableLabel.Location = new Point(113, 146);
            inputVariableLabel.Name = "inputVariableLabel";
            inputVariableLabel.Size = new Size(161, 20);
            inputVariableLabel.TabIndex = 3;
            inputVariableLabel.Text = "Входная переменная:";
            // 
            // stringsListView
            // 
            stringsListView.Columns.AddRange(new ColumnHeader[] { stringsListViewСolumnHeader, StringsCloseButtons });
            stringsListView.FullRowSelect = true;
            stringsListView.Location = new Point(188, 169);
            stringsListView.Name = "stringsListView";
            stringsListView.Size = new Size(246, 276);
            stringsListView.TabIndex = 4;
            stringsListView.UseCompatibleStateImageBehavior = false;
            stringsListView.View = System.Windows.Forms.View.Details;
            // 
            // stringsListViewСolumnHeader
            // 
            stringsListViewСolumnHeader.Text = "Строки";
            stringsListViewСolumnHeader.Width = 117;
            // 
            // StringsCloseButtons
            // 
            StringsCloseButtons.Text = "";
            // 
            // columnsListView
            // 
            columnsListView.Columns.AddRange(new ColumnHeader[] { columnsListViewСolumnHeader, columnsCloseButtons });
            columnsListView.FullRowSelect = true;
            columnsListView.Location = new Point(481, 169);
            columnsListView.Name = "columnsListView";
            columnsListView.Size = new Size(244, 276);
            columnsListView.TabIndex = 5;
            columnsListView.UseCompatibleStateImageBehavior = false;
            columnsListView.View = System.Windows.Forms.View.Details;
            // 
            // columnsListViewСolumnHeader
            // 
            columnsListViewСolumnHeader.Text = "Столбцы";
            columnsListViewСolumnHeader.Width = 117;
            // 
            // columnsCloseButtons
            // 
            columnsCloseButtons.Text = "";
            // 
            // columnsComboBox
            // 
            columnsComboBox.FormattingEnabled = true;
            columnsComboBox.Location = new Point(556, 169);
            columnsComboBox.Name = "columnsComboBox";
            columnsComboBox.Size = new Size(169, 28);
            columnsComboBox.TabIndex = 6;
            columnsComboBox.SelectedIndexChanged += ColumnsComboBox_SelectedIndexChanged;
            // 
            // stringsComboBox
            // 
            stringsComboBox.FormattingEnabled = true;
            stringsComboBox.Location = new Point(262, 169);
            stringsComboBox.Name = "stringsComboBox";
            stringsComboBox.Size = new Size(172, 28);
            stringsComboBox.TabIndex = 7;
            stringsComboBox.SelectedIndexChanged += StringsComboBox_SelectedIndexChanged;
            // 
            // InferenceForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(stringsComboBox);
            Controls.Add(columnsComboBox);
            Controls.Add(columnsListView);
            Controls.Add(stringsListView);
            Controls.Add(inputVariableLabel);
            Controls.Add(windowHeaderLabel);
            Controls.Add(outputVariableLabel);
            Controls.Add(outputVariableComboBox);
            Name = "InferenceForm";
            Size = new Size(941, 490);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox outputVariableComboBox;
        private Label outputVariableLabel;
        private Label windowHeaderLabel;
        private Label inputVariableLabel;
        private ListView stringsListView;
        private ListView columnsListView;
        private ComboBox columnsComboBox;
        private ComboBox stringsComboBox;
        private ColumnHeader stringsListViewСolumnHeader;
        private ColumnHeader columnsListViewСolumnHeader;
        private ColumnHeader StringsCloseButtons;
        private ColumnHeader columnsCloseButtons;
    }
}
