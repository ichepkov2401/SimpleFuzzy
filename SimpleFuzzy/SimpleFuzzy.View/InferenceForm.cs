using MetroFramework.Controls;
using SimpleFuzzy.Abstract;
using SimpleFuzzy.Model;
using System.Data.Common;
using System.Windows.Forms;

namespace SimpleFuzzy.View
{
    public partial class InferenceForm : UserControl
    {
        public IRepositoryService? repositoryService;
        public LinguisticVariable currentOutputVar;
        public int Id = 1;
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
        private Color SetColorTerm(string name, IMembershipFunction func)
        {
            for (int i = 0; i < currentOutputVar.listRules.inputVariables.Count; i++)
            {
                if (currentOutputVar.listRules.inputVariables[i].Name == name)
                {
                    for (int j = 0; j < currentOutputVar.listRules.inputVariables[i].func.Count; j++)
                    {
                        if (currentOutputVar.listRules.inputVariables[i].func[j].Item1 == func)
                        {
                            return currentOutputVar.listRules.inputVariables[i].func[j].Item2;
                        }
                    }
                }
            }
            return DefaultBackColor; // Чтобы все пути к коду возвращали значение
        }
        private Color SetColorToRelevation(double var)
        {
            // Нужно переделать на плавный переход между красным и зеленым (пока так и не разобрался как)
            
            if (var <= 0.2) return Color.Red; // color*255 или  1-color*255
            if (var > 0.2 && var <= 0.5) return Color.Orange;
            if (var > 0.5 && var <= 0.7) return Color.Yellow;
            if (var > 0.7 && var <= 0.9) return Color.LightGreen;
            if (var > 0.9) return Color.Green;
            return DefaultBackColor; // Чтобы все пути к коду возвращали значение
        }

        private void AddTable(string name)
        {
            if (dataTable != null) dataTable.Columns.Clear();
            dataTable.Columns.Add("", "ID");
            dataTable.Columns[0].ReadOnly = true;
            dataTable.Columns[0].Width = 40;
            dataTable.Columns[0].Name = "ID";

            DataGridViewTextBoxColumn textBox = new DataGridViewTextBoxColumn();
            textBox.HeaderText = "Релевантность";
            dataTable.Columns.Add(textBox);
            dataTable.Columns[1].Name = "Релевантность";

            DataGridViewComboBoxColumn comboBox = new DataGridViewComboBoxColumn();
            comboBox.HeaderText = name;
            dataTable.Columns.Add(comboBox);
            dataTable.Columns[2].Name = currentOutputVar.Name;
            Rule rule = new Rule(1);
            currentOutputVar.listRules.rules.Add(rule);

            List<string> term = new List<string>();
            foreach (var func in currentOutputVar.func) { term.Add(func.Item1.Name); }
            (dataTable.Columns[2] as DataGridViewComboBoxColumn).DataSource = term;
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
            // добавление таблицы
            SetRule setRule = new SetRule(currentOutputVar);
            currentOutputVar.listRules = setRule;
            AddTable(outputVariableComboBox.SelectedItem.ToString());
            outputVariableComboBox.Items.Remove(outputVariableComboBox.SelectedItem);
        }
        private void inputVariablesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputVariablesComboBox.Text = inputVariablesComboBox.SelectedItem.ToString();
        }
        //////////////////// Добавление столбца
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
                        dataTable.Columns[1].Name = var.Name;
                        currentOutputVar.listRules.AddInputVar(var);

                        List<string> term = new List<string>();
                        foreach (var func in currentOutputVar.func)
                        {
                            term.Add(func.Item1.Name);
                        }
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            (dataTable.Columns[1] as DataGridViewComboBoxColumn).DataSource = term;
                        }
                        break;
                    }
                }
                inputVariablesComboBox.Items.Remove(inputVariablesComboBox.Text);
                inputVariablesComboBox.Text = null;
            }
        }
        private IMembershipFunction GiveFunc(string name, LinguisticVariable variable)
        {
            for (int i = 0; i < variable.func.Count; i++)
            {
                if (variable.func[i].Item1.Name == name) { return variable.func[i].Item1; }
            }
            return null; // Сюда заходить не будет (надо чтобы все пути к коду возвращали значение)
        }

        ////////////////// Изменение значений
        private void dataTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0) { return; } // ID
            else if (e.ColumnIndex == dataTable.ColumnCount - 1) // ВЫХОДНАЯ ПЕРЕМЕНННАЯ
            {
                IMembershipFunction func = GiveFunc(dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), currentOutputVar);
                currentOutputVar.listRules.rules[e.RowIndex].RedactTerm(func, 0);
                currentOutputVar.listRules.BlockedSameRules(e.RowIndex);
                // Цвет уже есть, но пока не работает
                dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = SetColorTerm(dataTable.Columns[e.ColumnIndex].Name, func);
            }
            else if (e.ColumnIndex == dataTable.ColumnCount - 2) // РЕЛЕВАНТНОСТЬ
            {
                double n;
                if (double.TryParse(dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out n) && n >= 0 && n <= 1)
                {
                    currentOutputVar.listRules.rules[e.RowIndex].relevance = n;
                    dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = SetColorToRelevation(n);
                }
                else
                {
                    MessageBox.Show("Релевантность должна находиться в диапазоне [0, 1]");
                    dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 1;
                    dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = SetColorToRelevation(1);
                }
            }
            else // СТОЛБЦЫ С ВХОДНЫМИ ПЕРЕМЕННЫМИ
            {
                IMembershipFunction func = null;
                for (int i = 0; i < currentOutputVar.listRules.inputVariables.Count; i++)
                {
                    if (currentOutputVar.listRules.inputVariables[i].Name == dataTable.Columns[e.ColumnIndex].Name)
                    {
                        func = GiveFunc(dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), currentOutputVar.listRules.inputVariables[i]);
                        // Цвет уже есть, но пока не работает
                        dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = SetColorTerm(dataTable.Columns[e.ColumnIndex].Name, func);
                        break;
                    }
                }
                currentOutputVar.listRules.rules[e.RowIndex].RedactTerm(func, e.ColumnIndex);
                currentOutputVar.listRules.BlockedSameRules(e.RowIndex);
            }
        }
        //////////////////// Добавление строк
        private void dataTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == dataTable.RowCount - 1)
            {
                dataTable.Rows.Add();
                dataTable.Rows[e.RowIndex].Cells[0].Value = Id;
                Id++;
                // Возможно потом добавить это условие, требуется обсуждение
                //if (e.ColumnIndex != dataTable.Columns.Count - 2)
                {
                    dataTable.Rows[e.RowIndex].Cells[dataTable.Columns.Count - 2].Value = currentOutputVar.listRules.rules[0].relevance;
                    dataTable.Rows[0].Cells[1].Style.BackColor = SetColorToRelevation(1);
                }
                
                Rule rule = new Rule(dataTable.ColumnCount - 2);
                currentOutputVar.listRules.rules.Add(rule);
                for (int i = 0; i < dataTable.ColumnCount - 2; i++)
                {
                    List<string> term = new List<string>();
                    foreach (var func in currentOutputVar.func)
                    {
                        term.Add(func.Item1.Name);
                    }
                    if (i == 0)
                    {
                        (dataTable.Columns[dataTable.ColumnCount - 1] as DataGridViewComboBoxColumn).DataSource = term;
                    }
                    else
                    {
                        (dataTable.Columns[i] as DataGridViewComboBoxColumn).DataSource = term;
                    }
                }
            }
        }
    }
}
