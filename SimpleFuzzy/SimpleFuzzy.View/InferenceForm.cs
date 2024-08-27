using SimpleFuzzy.Abstract;
using SimpleFuzzy.Model;

namespace SimpleFuzzy.View
{
    public partial class InferenceForm : UserControl
    {
        public IRepositoryService? repositoryService;
        public LinguisticVariable currentOutputVar;
        public int Id = 0;
        public InferenceForm()
        {
            InitializeComponent();
            repositoryService = AutofacIntegration.GetInstance<IRepositoryService>();
            dataTable.EditMode = DataGridViewEditMode.EditOnEnter;
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

        private void StartTable(SetRule setRule)
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
            comboBox.HeaderText = currentOutputVar.Name;
            comboBox.FlatStyle = FlatStyle.Flat;
            dataTable.Columns.Add(comboBox);
            dataTable.Columns[2].Name = currentOutputVar.Name;

            List<string> term = new List<string>();
            foreach (var func in currentOutputVar.func) { term.Add(func.Item1.Name); }
            (dataTable.Columns[2] as DataGridViewComboBoxColumn).DataSource = term;

            for (int i = currentOutputVar.ListRules.inputVariables.Count - 1; i >= 0; i--)
            {
                DataGridViewComboBoxColumn comboBoxInput = new DataGridViewComboBoxColumn();
                comboBoxInput.HeaderText = currentOutputVar.ListRules.inputVariables[i].Name;
                comboBoxInput.FlatStyle = FlatStyle.Flat;
                dataTable.Columns.Insert(1, comboBoxInput);
                dataTable.Columns[1].Name = currentOutputVar.ListRules.inputVariables[i].Name;

                List<string> termInput = new List<string>();
                foreach (var func in currentOutputVar.ListRules.inputVariables[i].func) { termInput.Add(func.Item1.Name); }
            (dataTable.Columns[1] as DataGridViewComboBoxColumn).DataSource = termInput;
            }
        }

        /// <summary>
        /// Функция определеяет цвет терма заданной Лингвистической переменной
        /// </summary>
        /// <param name="name">Имя лингвитситческой переменной для которой определяется цвет</param>
        /// <param name="func">Функция принадледности для которой определяется цвет</param>
        /// <param name="isActive">1 - если правило активно, 2 - если не активно</param>
        /// <returns>Цвет терма</returns>
        private Color SetColorTerm(string name, IMembershipFunction func, byte isActive)
        {
            if (currentOutputVar.Name == name)
            {
                for (int i = 0; i < currentOutputVar.func.Count; i++)
                {
                    if (currentOutputVar.func[i].Item1 == func)
                    {
                        return Color.FromArgb(currentOutputVar.func[i].Item2.R / isActive,
                            currentOutputVar.func[i].Item2.G / isActive,
                            currentOutputVar.func[i].Item2.B / isActive);
                    }
                }
            }
            for (int i = 0; i < currentOutputVar.ListRules.inputVariables.Count; i++)
            {
                if (currentOutputVar.ListRules.inputVariables[i].Name == name)
                {
                    for (int j = 0; j < currentOutputVar.ListRules.inputVariables[i].func.Count; j++)
                    {
                        if (currentOutputVar.ListRules.inputVariables[i].func[j].Item1 == func)
                        {
                            return Color.FromArgb(currentOutputVar.ListRules.inputVariables[i].func[j].Item2.R / isActive,
                                currentOutputVar.ListRules.inputVariables[i].func[j].Item2.G / isActive,
                                currentOutputVar.ListRules.inputVariables[i].func[j].Item2.B / isActive);
                        }
                    }
                }
            }
            return DefaultBackColor; // Чтобы все пути к коду возвращали значение
        }

        /// <summary>
        /// Функция расчитывает цвет релевантности на основе чилосвого значения и состояния активности
        /// </summary>
        /// <param name="var">Значение [0, 1] отображающее релвантность</param>
        /// <param name="isActive">1 - если правило активно, 2 - если не активно</param>
        /// <returns>Цветовая индикация релевантности</returns>
        private Color SetColorToRelevation(double var, byte isActive)
        {
            return Color.FromArgb((int)((var > 0.5 ? ((1 - (var - 0.5) * 2) * 255) : 255) / isActive),
                (int)((var > 0.5 ? 255 : var * 511) / isActive), 0);
        }

        //private bool SetColorText(Color color)
        //{
        //    color.
        //}
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
            comboBox.FlatStyle = FlatStyle.Flat;
            dataTable.Columns.Add(comboBox);
            dataTable.Columns[2].Name = currentOutputVar.Name;
            Rule rule = new Rule(1, currentOutputVar.ListRules);

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
            if (temp.ListRules == null)
            {
                // добавление таблицы
                SetRule setRule = new SetRule(currentOutputVar);
                currentOutputVar.ListRules = setRule;
                AddTable(outputVariableComboBox.SelectedItem.ToString());
            }
            else
            {
                StartTable(temp.ListRules);
            }
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
                        column.FlatStyle = FlatStyle.Flat;
                        dataTable.Columns.Insert(1, column);
                        dataTable.Columns[1].Name = var.Name;
                        currentOutputVar.ListRules.AddInputVar(var);

                        List<string> term = new List<string>();
                        foreach (var func in var.func)
                        {
                            term.Add(func.Item1.Name);
                        }
                        var combobox = (dataTable.Columns[1] as DataGridViewComboBoxColumn);
                        combobox.DataSource = term;
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
        private void ChangeActiveRules(int row)
        {
            ChangeRule(row, 2);
            ChangeRule(row, 1);
            ChangeRule(row, 3);
        }
        private void ChangeRule(int row, byte active)
        {
            int position;
            if (active == 1) position = currentOutputVar.ListRules.OpenThisRule(row);
            else if (active == 2) position = currentOutputVar.ListRules.BlockedSameRules(row);
            else 
            {
                position = currentOutputVar.ListRules.OpenOtherRule(row);
                active -= 2;
            }
            if (position != -1)
            {
                for (int i = 1; i < dataTable.Columns.Count - 2; i++)
                {
                        dataTable.Rows[position].Cells[i].Style.BackColor = SetColorTerm(dataTable.Columns[i].Name,
                        GiveFunc(dataTable.Rows[position].Cells[i].Value.ToString(), currentOutputVar.ListRules.inputVariables[i - 1]), active);
                }
                double n;
                if (double.TryParse(dataTable.Rows[position].Cells[dataTable.Columns.Count - 2].Value.ToString(), out n))
                    dataTable.Rows[position].Cells[dataTable.Columns.Count - 2].Style.BackColor = SetColorToRelevation(n, active);
                string name = dataTable.Columns[dataTable.Columns.Count - 1].Name;
                string text = dataTable.Rows[position].Cells[dataTable.Columns.Count - 1].Value.ToString();
                LinguisticVariable var = currentOutputVar.ListRules.outVariable;
                IMembershipFunction func = GiveFunc(text, var);
                dataTable.Rows[position].Cells[dataTable.Columns.Count - 1].Style.BackColor = SetColorTerm(name, func, active);
            }
        }

        ////////////////// Изменение значений
        private void dataTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null) return; // Иногда событие срабатывает до введения значения
            if (e.ColumnIndex == 0) return; // ID
            else if (e.ColumnIndex == dataTable.ColumnCount - 1) // ВЫХОДНАЯ ПЕРЕМЕНННАЯ
            {
                IMembershipFunction func = GiveFunc(dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), currentOutputVar);
                currentOutputVar.ListRules.rules[e.RowIndex].RedactTerm(func, 0);
                ChangeActiveRules(e.RowIndex);
                byte active = 1;
                if (!currentOutputVar.ListRules.rules[e.RowIndex].IsActive) active = 2; 
                dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = SetColorTerm(dataTable.Columns[e.ColumnIndex].Name, func, active);
            }
            else if (e.ColumnIndex == dataTable.ColumnCount - 2) // РЕЛЕВАНТНОСТЬ
            {
                string rel = dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                string newRel = "";
                for (int i = 0; i < rel.Length; i++) 
                {
                    if (rel[i] == '.') newRel += ','; 
                    else newRel += rel[i];
                }
                dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = newRel;
                double n;
                if (double.TryParse(newRel, out n) && n >= 0 && n <= 1)
                {
                    currentOutputVar.ListRules.rules[e.RowIndex].relevance = n;
                    byte active = 1;
                    if (!currentOutputVar.ListRules.rules[e.RowIndex].IsActive) active = 2;
                    dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = SetColorToRelevation(n, active);
                }
                else
                {
                    MessageBox.Show("Релевантность должна находиться в диапазоне [0, 1]");
                    dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 1;
                    byte active = 1;
                    if (!currentOutputVar.ListRules.rules[e.RowIndex].IsActive) active = 2;
                    dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = SetColorToRelevation(1, active);
                }
            }
            else // СТОЛБЦЫ С ВХОДНЫМИ ПЕРЕМЕННЫМИ
            {
                IMembershipFunction func = null;
                for (int i = 0; i < currentOutputVar.ListRules.inputVariables.Count; i++)
                {
                    if (currentOutputVar.ListRules.inputVariables[i].Name == dataTable.Columns[e.ColumnIndex].Name)
                    {
                        func = GiveFunc(dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), currentOutputVar.ListRules.inputVariables[i]);
                        byte active = 1;
                        if (!currentOutputVar.ListRules.rules[e.RowIndex].IsActive) active = 2;
                        dataTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = SetColorTerm(dataTable.Columns[e.ColumnIndex].Name, func, active);
                        break;
                    }
                }
                currentOutputVar.ListRules.rules[e.RowIndex].RedactTerm(func, e.ColumnIndex);
                ChangeActiveRules(e.RowIndex);
            }
        }
        //////////////////// Добавление строк

        private void dataTable_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex == dataTable.RowCount - 1 && Id != dataTable.RowCount)
            {
                Id++;
                dataTable.Rows[e.RowIndex].Cells[0].Value = Id;

                Rule rule = new Rule(dataTable.ColumnCount - 2, currentOutputVar.ListRules);
                currentOutputVar.ListRules.rules.Add(rule);

                for (int i = 0; i < dataTable.ColumnCount - 2; i++)
                {
                    List<string> term = new List<string>();
                    if (i == 0)
                    {
                        foreach (var func in currentOutputVar.func)
                        {
                            term.Add(func.Item1.Name);
                        }
                        (dataTable.Columns[dataTable.ColumnCount - 1] as DataGridViewComboBoxColumn).DataSource = term;
                    }
                    else
                    {
                        foreach (var func in repositoryService.GetCollection<LinguisticVariable>().FirstOrDefault(t => t.Name == dataTable.Columns[i].Name).func)
                        {
                            term.Add(func.Item1.Name);
                        }
                        (dataTable.Columns[i] as DataGridViewComboBoxColumn).DataSource = term;
                    }
                }
                if (e.ColumnIndex != dataTable.Columns.Count - 2)
                {
                    dataTable.Rows[e.RowIndex].Cells[dataTable.Columns.Count - 2].Value = 1;
                    dataTable.Rows[e.RowIndex].Cells[dataTable.Columns.Count - 2].Style.BackColor = SetColorToRelevation(1, 1);
                }
            }
        }
    }
}
