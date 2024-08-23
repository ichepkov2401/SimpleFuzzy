using MetroFramework.Controls;
using SimpleFuzzy.Abstract;
using SimpleFuzzy.Model;
using System.Windows.Forms;

namespace SimpleFuzzy.View
{
    public partial class InferenceForm : UserControl
    {
        public IRepositoryService? repositoryService;
        public LinguisticVariable currentOutputVar;
        private int Id = 1;
        public InferenceForm()
        {
            InitializeComponent();
            repositoryService = AutofacIntegration.GetInstance<IRepositoryService>();
            foreach (LinguisticVariable variable in repositoryService.GetCollection<LinguisticVariable>())
            {
                if (!variable.IsInput) outputVariableComboBox.Items.Add(variable.Name);
                else inputVariablesComboBox.Items.Add(variable.Name);
            }
            if (outputVariableComboBox.Items.Count > 0)
            {
                outputVariableComboBox.SelectedIndex = 0;
            }
        }
        private void AddTable(string name)
        {
            if (dataTable != null) dataTable.Columns.Clear();
            dataTable.Columns.Add("", "ID");
            dataTable.Columns[0].ReadOnly = true;
            dataTable.Rows[0].Cells[0].Value = Id;
            Id++;

            DataGridViewTextBoxColumn textBox = new DataGridViewTextBoxColumn();
            textBox.HeaderText = "Релевантность";
            dataTable.Columns.Add(textBox);

            DataGridViewComboBoxColumn comboBox = new DataGridViewComboBoxColumn();
            comboBox.HeaderText = name;
            dataTable.Columns.Add(comboBox);
            Rule rule = new Rule();
            currentOutputVar.listRules.rules.Add(rule);
            dataTable.Rows[0].Cells[1].Value = currentOutputVar.listRules.rules[0].relevance;

            List<string> list = new List<string>();
            foreach (IMembershipFunction func in repositoryService.GetCollection<IMembershipFunction>()) { list.Add(func.Name); }
            (dataTable.Columns[2] as DataGridViewComboBoxColumn).DataSource = list;
        }
        private void OutputVariableComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LinguisticVariable temp = null;
            foreach (LinguisticVariable var in repositoryService.GetCollection<LinguisticVariable>())
            {
                if (currentOutputVar != null && var == currentOutputVar)
                {
                    outputVariableComboBox.Items.Add(var.Name);
                }
                if (var.Name == outputVariableComboBox.SelectedItem.ToString())
                {
                    temp = var;
                }
            }
            currentOutputVar = temp;
            SetRule setRule = new SetRule(currentOutputVar);
            currentOutputVar.listRules = setRule;
            AddTable(outputVariableComboBox.SelectedItem.ToString());
            outputVariableComboBox.Items.Remove(outputVariableComboBox.SelectedItem);
        }
        private void inputVariablesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputVariablesComboBox.Text = inputVariablesComboBox.SelectedItem.ToString();
        }
        private void AddInbutton_Click(object sender, EventArgs e)
        {
            if (inputVariablesComboBox.Text != null)
            {
                foreach (LinguisticVariable var in repositoryService.GetCollection<LinguisticVariable>())
                {
                    if (var.Name == inputVariablesComboBox.Text)
                    {
                        // добавление столбца
                        DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
                        column.HeaderText = inputVariablesComboBox.Text;
                        dataTable.Columns.Insert(1, column);
                        currentOutputVar.listRules.AddInputVar(var);
                        break;
                    }
                }
                inputVariablesComboBox.Items.Remove(inputVariablesComboBox.Text);
            }
        }

        private void dataTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0) { return; } // ID
            else if (e.ColumnIndex == dataTable.ColumnCount - 1) // ВЫХОДНАЯ ПЕРЕМЕНННАЯ
            {

            }
            else if (e.ColumnIndex == dataTable.ColumnCount - 2) // РЕЛЕВАНТНОСТЬ
            {
                double n;
                if (double.TryParse(dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out n) && n >= 0 && n <= 1)
                {
                    currentOutputVar.listRules.rules[e.RowIndex].relevance = n;
                }
                else { 
                    MessageBox.Show("Релевантность должна находиться в диапазоне [0, 1]");
                    dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 1;
                }
            }
        }
    }
}
