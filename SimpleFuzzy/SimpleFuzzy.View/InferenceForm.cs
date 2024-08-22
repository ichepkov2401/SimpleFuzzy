using MetroFramework.Controls;
using SimpleFuzzy.Abstract;
using SimpleFuzzy.Model;


namespace SimpleFuzzy.View
{
    public partial class InferenceForm : MetroUserControl
    {
        public IRepositoryService? repositoryService;
        Dictionary<string, string> isUsed = new();
        public InferenceForm()
        {
            repositoryService = AutofacIntegration.GetInstance<IRepositoryService>();
            var variableList = GetLinguisticVariableList();
            foreach (var linguisticVariable in variableList) isUsed[linguisticVariable.Name] = "false";
            RefreshAll();
            InitializeComponent();
            stringsListView.Columns.AddRange(new ColumnHeader[] { stringsListViewСolumnHeader, StringsCloseButtons });
            ListViewExtender stringExtender = new ListViewExtender(stringsListView);
            ListViewButtonColumn stringButtonAction = new ListViewButtonColumn(1);
            stringButtonAction.Click += StringOnButtonActionClick;
            stringButtonAction.FixedWidth = true;
            stringExtender.AddColumn(stringButtonAction);
            columnsListView.Columns.AddRange(new ColumnHeader[] { columnsListViewСolumnHeader, columnsCloseButtons });
            ListViewExtender columnExtender = new ListViewExtender(columnsListView);
            ListViewButtonColumn columnButtonAction = new ListViewButtonColumn(1);
            columnButtonAction.Click += ColumnOnButtonActionClick;
            columnButtonAction.FixedWidth = true;
            columnExtender.AddColumn(columnButtonAction);
        }

        public List<LinguisticVariable> GetLinguisticVariableList()
        {
            return repositoryService.GetCollection<LinguisticVariable>();
        }

        public void RefreshAll()
        {
            RefreshOutputVariables(GetLinguisticVariableList());
            RefreshInputStringVariables(GetLinguisticVariableList());
            RefreshInputColumnVariables(GetLinguisticVariableList());
        }

        public void RefreshInputVariables()
        {
            RefreshInputStringVariables(GetLinguisticVariableList());
            RefreshInputColumnVariables(GetLinguisticVariableList());
        }

        public void RefreshOutputVariables(List<LinguisticVariable> linguisticVariableList)
        {
            if (outputVariableComboBox != null) outputVariableComboBox.Items.Clear();
            foreach (var linguisticVariable in linguisticVariableList) if (!linguisticVariable.isInput) outputVariableComboBox?.Items.Add(linguisticVariable.Name);
        }


        public void RefreshInputStringVariables(List<LinguisticVariable> linguisticVariableList)
        {
            if (stringsComboBox != null) outputVariableComboBox.Items.Clear();
            foreach (var linguisticVariable in linguisticVariableList) if (linguisticVariable.isInput && isUsed[linguisticVariable.Name] == "false") stringsComboBox?.Items.Add(linguisticVariable.Name);
        }

        public void RefreshInputColumnVariables(List<LinguisticVariable> linguisticVariableList)
        {
            if (columnsComboBox != null) outputVariableComboBox.Items.Clear();
            foreach (var linguisticVariable in linguisticVariableList) if (linguisticVariable.isInput && isUsed[linguisticVariable.Name] == "false") columnsComboBox?.Items.Add(linguisticVariable.Name);
        }

        private void ColumnOnButtonActionClick(object sender, ListViewColumnMouseEventArgs e)
        {
            const string message = "Вы уверенны, что хотите удалить выбранный файл?";
            const string caption = "Удаление элемента";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                isUsed[e.Item.Text] = "false";
                columnsListView.Items.Remove(e.Item);
                RefreshInputVariables();
            }
        }
        private void StringOnButtonActionClick(object sender, ListViewColumnMouseEventArgs e)
        {
            const string message = "Вы уверенны, что хотите удалить выбранный файл?";
            const string caption = "Удаление элемента";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                isUsed[e.Item.Text] = "false";
                stringsListView.Items.Remove(e.Item);
                RefreshInputVariables();
            }
        }

        private void StringsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string selectedItem = (string)comboBox.SelectedItem;
            var linguisticVariableList = GetLinguisticVariableList();
            foreach (var linguisticVariable in linguisticVariableList)
            {
                if (linguisticVariable.Name == selectedItem) isUsed[linguisticVariable.Name] = "isString"; break;
            }
            RefreshInputVariables();
            RefreshStringsListView(linguisticVariableList);
        }

        private void ColumnsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string selectedItem = (string)comboBox.SelectedItem;
            var linguisticVariableList = GetLinguisticVariableList();
            foreach (var linguisticVariable in linguisticVariableList)
            {
                if (linguisticVariable.Name == selectedItem) isUsed[linguisticVariable.Name] = "isColumn"; break;
            }
            RefreshInputVariables();
            RefreshColumnsListView(linguisticVariableList);
        }

        public void RefreshStringsListView(List<LinguisticVariable> linguisticVariableList)
        {
            foreach (var linguisticVariable in linguisticVariableList)
            {
                if (isUsed[linguisticVariable.Name] == "isString")
                {
                    ListViewItem listViewItem = stringsListView.Items.Add(linguisticVariable.Name);
                    listViewItem.SubItems.Add("X");
                }
            }
        }

        public void RefreshColumnsListView(List<LinguisticVariable> linguisticVariableList)
        {
            foreach (var linguisticVariable in linguisticVariableList)
            {
                if (isUsed[linguisticVariable.Name] == "isColumn")
                {
                    ListViewItem listViewItem = columnsListView.Items.Add(linguisticVariable.Name);
                    listViewItem.SubItems.Add("X");
                }
            }
        }

        private void OutputVariableComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string selectedItem = (string)comboBox.SelectedItem;
            var linguisticVariableList = GetLinguisticVariableList();
            foreach (var linguisticVariable in linguisticVariableList)
            {
                if (linguisticVariable.Name == selectedItem) isUsed[linguisticVariable.Name] = "isOutput"; break;
            }
            RefreshOutputVariables(linguisticVariableList);
        }
    }
}
