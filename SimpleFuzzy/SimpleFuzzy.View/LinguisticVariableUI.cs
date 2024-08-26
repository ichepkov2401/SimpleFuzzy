using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using SimpleFuzzy.Abstract;
using SimpleFuzzy.Model;
using System.Drawing;

namespace SimpleFuzzy.View
{
    public partial class LinguisticVariableUI : UserControl
    {
        private LinguisticVariable linguisticVariable;
        private Dictionary<string, IObjectSet> objectSetsName = new Dictionary<string, IObjectSet>();
        private Dictionary<string, IMembershipFunction> termsName = new Dictionary<string, IMembershipFunction>();
        IRepositoryService _repositoryService;
        string oldName;
        Action nameChange;
        Action treeChange;
        IMembershipFunction nowFunction;
        object nowObject;
        LineSeries xLine = new LineSeries();
        LineSeries yLine = new LineSeries();
        Type objectSetType;

        public LinguisticVariableUI()
        {
            InitializeComponent();
        }

        public LinguisticVariableUI(LinguisticVariable linguisticVariable, Action nameChange, Action treeChange)
        {
            _repositoryService = AutofacIntegration.GetInstance<IRepositoryService>();
            this.linguisticVariable = linguisticVariable;
            this.nameChange = nameChange;
            this.treeChange = treeChange;
            oldName = linguisticVariable.Name;
            InitializeComponent();
            ListViewExtender extender = new ListViewExtender(termsListView);
            ListViewButtonColumn colorAction = new ListViewButtonColumn(1);
            ListViewButtonColumn buttonAction = new ListViewButtonColumn(2);
            colorAction.Click += OnColorActionClick;
            buttonAction.Click += OnButtonActionClick;
            colorAction.FixedWidth = true;
            buttonAction.FixedWidth = true;
            extender.AddColumn(colorAction);
            extender.AddColumn(buttonAction);
            SetObjectSet();
            nameTextBox.Text = linguisticVariable.Name;
            radioButton1.Checked = linguisticVariable.isInput;
            radioButton2.Checked = !linguisticVariable.isInput;
            FazificationObjectChaged(null, null);
            if (!linguisticVariable.isRedact)
            {
                baseSetComboBox.Enabled = false;
                nameTextBox.Enabled = false;
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
            }
            termsListView.GetType()
                            .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                            .SetValue(termsListView, true);
        }

        private void SetObjectSet()
        {
            objectSetsName.Clear();
            baseSetComboBox.Items.Clear();
            var baseSets = _repositoryService.GetCollection<IObjectSet>().Where(x => x.Active || !linguisticVariable.isRedact);
            foreach (var baseSet in baseSets)
            {
                string name = baseSet.Name;
                if (baseSets.Count(t => t.Name == name) > 1)
                {
                    name = $"{baseSet.Name} - {baseSet.GetType()}";
                    if (baseSets.Where(t => t.Name == name).Count(x => x.GetType() == baseSet.GetType()) > 1)
                    {
                        name = $"{baseSet.Name} - {baseSet.GetType()} - {baseSet.GetType().Assembly.FullName}";
                    }
                }
                objectSetsName.Add(name, baseSet);
                baseSetComboBox.Items.Add(name);
            }
            if (linguisticVariable.baseSet == null)
            {
                if (baseSetComboBox.Items.Count > 0)
                    baseSetComboBox.SelectedIndex = 0;
            }
            else
            {
                baseSetComboBox.SelectedItem = objectSetsName.FirstOrDefault(t => t.Value == linguisticVariable.baseSet).Key;
            }
        }

        private void SetTerms()
        {
            termsName.Clear();
            termsComboBox.Items.Clear();
            termsListView.Items.Clear();
            var terms = _repositoryService.GetCollection<IMembershipFunction>().Where(x =>
            x.Active &&
            (x.GetType() != typeof(FuzzyOperation) || linguisticVariable.isInput) &&
            x.InputType.IsAssignableFrom(objectSetType));
            foreach (var term in terms)
            {
                string name = term.Name;
                if (terms.Count(t => t.Name == name) > 1)
                {
                    name = $"{term.Name} - {term.GetType()}";
                    if (terms.Where(x => x.InputType.IsAssignableFrom(objectSetType) && x.Name == name).Count(x => x.GetType() == term.GetType()) > 1)
                    {
                        name = $"{term.Name} - {term.GetType()} - {term.GetType().Assembly.FullName}";
                    }
                }
                if (linguisticVariable.ContainsFunc(term))
                {
                    ListViewItem item = new ListViewItem(name);
                    item.SubItems.Add("🎨");
                    item.SubItems.Add("X");
                    item.ForeColor = linguisticVariable.GetColor(term);
                    termsListView.Items.Add(item);
                }
                else
                {
                    termsComboBox.Items.Add(name);
                }
                termsName.Add(name, term);
            }
            UpdateGraph();
            if (termsComboBox.Items.Count > 0)
                termsComboBox.SelectedIndex = 0;
            else termsComboBox.Text = string.Empty;
        }

        private void AddTermButton_Click(object sender, EventArgs e)
        {
            if (termsComboBox.SelectedIndex != -1)
            {
                linguisticVariable.AddTerm((termsName[(string)termsComboBox.SelectedItem], GetColor(linguisticVariable.CountFunc)));
                termsComboBox.Text = "";
                SetTerms();
                nameChange();
            }
        }

        private void UpdateGraph()
        {
            if (linguisticVariable.BaseSet == null)
            {
                graphPictureBox.Controls.Clear();
                return;
            }

            var plotModel = new PlotModel { Title = $"{linguisticVariable.Name}" };

            var baseSetValues = linguisticVariable.ObjectSetToList();
            var data = linguisticVariable.Graphic();

            LineSeries[] lineSeries = new LineSeries[linguisticVariable.CountFunc];
            for (int i = 0; i < lineSeries.Length; i++)
            {
                Color color = linguisticVariable.GetColor(linguisticVariable[i]);
                lineSeries[i] = new LineSeries
                {
                    Title = linguisticVariable[i].Name,
                    Color = OxyColor.FromRgb(color.R, color.G, color.B)
                };
            }

            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 0; j < linguisticVariable.CountFunc; j++)
                {
                    lineSeries[j].Points.Add(new DataPoint(Convert.ToDouble(baseSetValues[i]), data[i].Item2[j]));
                }
            }

            xLine = new LineSeries() { Color = OxyColor.FromRgb(0, 0, 0) };
            xLine.Points.Add(new DataPoint(Convert.ToDouble(linguisticVariable.BaseSet[trackBar.Value]), 0));
            xLine.Points.Add(new DataPoint(Convert.ToDouble(linguisticVariable.BaseSet[trackBar.Value]), 1));
            yLine = new LineSeries() { Color = OxyColor.FromRgb(0, 0, 0), LineStyle = LineStyle.Dash };
            yLine.Points.Add(new DataPoint(Convert.ToDouble(linguisticVariable.BaseSet[0]), (double)NumericUpDown1.Value));
            yLine.Points.Add(new DataPoint(Convert.ToDouble(linguisticVariable.BaseSet[^1]), (double)NumericUpDown1.Value));

            foreach (var value in lineSeries)
            {
                plotModel.Series.Add(value);
            }
            plotModel.Series.Add(xLine);
            plotModel.Series.Add(yLine);

            ScatterSeries series = new ScatterSeries();
            series.Points.Add(new ScatterPoint(Convert.ToDouble(baseSetValues[0]), 0, 0));
            series.Points.Add(new ScatterPoint(Convert.ToDouble(baseSetValues[^1]), 0, 0));
            plotModel.Series.Add(series);

            var plotView = new PlotView
            {
                Model = plotModel,
                Dock = DockStyle.Fill
            };



            graphPictureBox.Controls.Clear();
            graphPictureBox.Controls.Add(plotView);
        }

        private void DrawX()
        {
            if (linguisticVariable.BaseSet != null && graphPictureBox.Controls.Count > 0)
            {
                var plot = graphPictureBox.Controls[0] as PlotView;
                xLine.Points.Clear();
                xLine.Points.Add(new DataPoint(Convert.ToDouble(linguisticVariable.BaseSet[trackBar.Value]), 0));
                xLine.Points.Add(new DataPoint(Convert.ToDouble(linguisticVariable.BaseSet[trackBar.Value]), 1));
                plot.InvalidatePlot(true);
            }
        }

        private void DrawY()
        {
            if (linguisticVariable.BaseSet != null && graphPictureBox.Controls.Count > 0)
            {
                var plot = graphPictureBox.Controls[0] as PlotView;
                yLine.Points.Clear();
                yLine.Points.Add(new DataPoint(Convert.ToDouble(linguisticVariable.BaseSet[0]), (double)NumericUpDown1.Value));
                yLine.Points.Add(new DataPoint(Convert.ToDouble(linguisticVariable.BaseSet[^1]), (double)NumericUpDown1.Value));
                plot.InvalidatePlot(true);
            }
        }

        private Color GetColor(int index)
        {
            Color[] colors = { Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Purple, Color.Brown };
            return colors[index % colors.Length];
        }

        private void NameChangedHandler(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Имя переменной не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nameTextBox.Text = oldName;
            }
            else if (_repositoryService.GetCollection<LinguisticVariable>().Exists(x => x.Name == nameTextBox.Text) && oldName != nameTextBox.Text)
            {
                MessageBox.Show("Переменная с таким именем уже существует. Пожалуйста, введите другое имя.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nameTextBox.Text = oldName;
            }
            else
            {
                linguisticVariable.Name = nameTextBox.Text;
                nameChange();
                UpdateGraph();
            }
        }

        private void BaseSetChange(object sender, EventArgs e)
        {
            string name = "";
            if (linguisticVariable.baseSet != null) { name = linguisticVariable.baseSet.Name; }
            try { linguisticVariable.BaseSet = objectSetsName[(string)baseSetComboBox.SelectedItem]; }
            catch 
            {
                DialogResult result = MessageBox.Show(
                            "При изменении базового множества будут автоматически удалены все" +
                             "выбранные термы, так как у нового множества другой тип данных. Продолжить? ",
                            "Предупреждение",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.None,
                            MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    termsListView.Clear();
                    linguisticVariable.func.Clear();
                    
                    linguisticVariable.BaseSet = objectSetsName[(string)baseSetComboBox.SelectedItem];
                    objectSetType = linguisticVariable.BaseSet[0].GetType();
                    trackBar.Maximum = linguisticVariable.BaseSet.Count - 1;
                    trackBar.Value = trackBar.Maximum / 2;
                    SetTerms();
                    nameChange();
                }
                else 
                { 
                    baseSetComboBox.Text = name;
                    return;
                };
            }
            objectSetType = linguisticVariable.BaseSet[0].GetType();
            trackBar.Maximum = linguisticVariable.BaseSet.Count - 1;
            trackBar.Value = trackBar.Maximum / 2;
            SetTerms();
            nameChange();
        }

        private void OnButtonActionClick(object sender, ListViewColumnMouseEventArgs e)
        {
            const string message = "Вы уверенны, что хотите удалить выбранный файл?";
            const string caption = "Удаление элемента";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                var term = termsName[e.Item.Text];
                linguisticVariable.DeleteTerm(term);
                SetTerms();
                termView_SelectedIndexChanged(sender, null);
                nameChange();
            }
        }

        private void OnColorActionClick(object sender, ListViewColumnMouseEventArgs e)
        {
            if (MainWindow.colorDialog.ShowDialog() == DialogResult.OK)
            {
                var term = termsName[e.Item.Text];
                linguisticVariable.SetColor(term, MainWindow.colorDialog.Color);
                SetTerms();
                termView_SelectedIndexChanged(sender, null);
            }
        }

        private void termView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (termsListView.SelectedIndices.Count == 1)
            {
                nowFunction = termsName[termsListView.SelectedItems[0].Text];
                HeightLabel.Visible = true;
                NumericUpDown1.Visible = true;
                FazificationObjectChaged(null, null);
                var value = linguisticVariable.CalculationFuzzySetProperties(nowFunction, (double)NumericUpDown1.Value);
                SetProperty.Text = $"Тип нечеткого множества: {value.Item2}" +
                    $"\nВысота нечеткого множества: {value.Item1}" +
                    $"\n{value.Item3.AsQueryable().Aggregate("Область влияния нечеткого множества: ", (x, y) => x + " " + y.ToString())}" +
                    $"\n{value.Item4.AsQueryable().Aggregate("Ядро нечеткого множества: ", (x, y) => x + " " + y.ToString())}" +
                    $"\n{value.Item5.AsQueryable().Aggregate($"Сечение на выстое {(double)NumericUpDown1.Value}: ", (x, y) => x + " " + y.ToString())}";
                DrawY();
            }
            else
            {
                nowFunction = null;
                HeightLabel.Visible = false;
                NumericUpDown1.Visible = false;
                SetProperty.Text = "";
            }
        }

        private void FazificationObjectChaged(object sender, EventArgs e)
        {
            if (linguisticVariable.BaseSet != null)
            {
                nowObject = linguisticVariable.BaseSet[trackBar.Value];
                ObjectSetLabel.Text = nowObject.ToString();
                FazificationDescription.Text = linguisticVariable.GetResultofFuzzy(linguisticVariable.Fazzification(nowObject));
                //UpdateGraph();
                DrawX();
            }
        }

        private void GenerateMembershipFunction_Click(object sender, EventArgs e)
        {
            using (var inputBox = new NewMembershipDialogForm(linguisticVariable.BaseSet))
            {
                inputBox.ShowDialog();
                SetTerms();
                treeChange();
            }
        }

        private void termsListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (termsName[termsListView.SelectedItems[0].Text] is FuzzyOperation fuzzyOperation)
            {
                using (var inputBox = new NewMembershipDialogForm(fuzzyOperation, linguisticVariable.BaseSet))
                {
                    inputBox.ShowDialog();
                    SetTerms();
                }
            }
        }

        private void GenerateBaseSet_Click(object sender, EventArgs e)
        {
            using (var inputBox = new GenerationObjectSetUI())
            {
                inputBox.ShowDialog();
                SetObjectSet();
                treeChange();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            linguisticVariable.isInput = radioButton1.Checked;
            if (!radioButton1.Checked)
                linguisticVariable.func = linguisticVariable.func.Where(t => t.Item1.GetType() != typeof(FuzzyOperation)).ToList();
            SetTerms();
        }

        private void termsListView_MouseMove(object sender, MouseEventArgs e)
        {
            termsListView.Invalidate();
        }

        private void termsListView_MouseLeave(object sender, EventArgs e)
        {
            termsListView.Invalidate();
        }
    }
}