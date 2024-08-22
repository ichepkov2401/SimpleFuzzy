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
        private int ID = 0;
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

            DataGridViewTextBoxColumn textBox = new DataGridViewTextBoxColumn();
            textBox.HeaderText = "Релевантность";
            dataTable.Columns.Add(textBox);

            DataGridViewComboBoxColumn comboBox = new DataGridViewComboBoxColumn();
            comboBox.HeaderText = name;
            dataTable.Columns.Add(comboBox);

            List<string> list = new List<string>();
            foreach (IMembershipFunction func in  repositoryService.GetCollection<IMembershipFunction>()) { list.Add(func.Name); }
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
            AddTable(outputVariableComboBox.SelectedItem.ToString());
            outputVariableComboBox.Items.Remove(outputVariableComboBox.SelectedItem);
            SetRule setRule = new SetRule(currentOutputVar);
            currentOutputVar.listRules = setRule;
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

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (LinguisticVariable var in repositoryService.GetCollection<LinguisticVariable>())
            {
                var.isInput = true;
            }
            foreach (LinguisticVariable variable in repositoryService.GetCollection<LinguisticVariable>())
            {
                if (!variable.IsInput) outputVariableComboBox.Items.Add(variable.Name);
                else inputVariablesComboBox.Items.Add(variable.Name);
            }
        }
        ////////////////////////////////////////////////
        private void dataTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cell is DataGridViewComboBoxCell)
            {
                dataTable.BeginEdit(false);
                (dataTable.EditingControl as DataGridViewComboBoxEditingControl).DroppedDown = true;
            }
        }
    }
}
