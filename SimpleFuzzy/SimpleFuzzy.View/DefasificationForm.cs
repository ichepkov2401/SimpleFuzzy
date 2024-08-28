using OxyPlot.Series;
using OxyPlot;
using OxyPlot.WindowsForms;
using SimpleFuzzy.Abstract;
using SimpleFuzzy.Model;

namespace SimpleFuzzy.View
{
    public partial class DefasificationForm : UserControl
    {
        IRepositoryService repositoryService;
        List<(LinguisticVariable, PictureBox, TrackBar, Label)> inputs = new List<(LinguisticVariable, PictureBox, TrackBar, Label)>();
        public DefasificationForm()
        {
            InitializeComponent();
            repositoryService = AutofacIntegration.GetInstance<IRepositoryService>();
            FillComboBox();
        }

        private void FillComboBox()
        {
            for (int i = 0; i < repositoryService.GetCollection<LinguisticVariable>().Count; i++)
            {
                if (!repositoryService.GetCollection<LinguisticVariable>()[i].isInput)
                OutputVariables.Items.Add(repositoryService.GetCollection<LinguisticVariable>()[i].Name);
            }
        }

        private void OutputVariables_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var variable in inputs)
            {
                Controls.Remove(variable.Item2);
                Controls.Remove(variable.Item3);
                Controls.Remove(variable.Item4);
            }
            inputs.Clear();
            var output = repositoryService.GetCollection<LinguisticVariable>()
                .FirstOrDefault(t => t.Name == (string)OutputVariables.SelectedItem);
            pictureBox1.Controls.Clear();
            pictureBox1.Controls.Add(DrawInput(output));
            var newInput = output.ListRules.inputVariables;
            for (int i = 0; i < newInput.Count; i++)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.Size = new Size(287, 193);
                pictureBox.Location = new Point(15, 197 + i * 250);
                pictureBox.Controls.Add(DrawInput(newInput[i]));
                Controls.Add(pictureBox);
                TrackBar trackBar = new TrackBar();
                trackBar.Size = new Size(148, 45);
                trackBar.Location = new Point(15, 396 + i * 250);
                Controls.Add(trackBar);
                Label label = new Label();
                label.Text = newInput[i].Name;
                label.Location = new Point(169, 405 + i * 250);
                Controls.Add(label);
                inputs.Add((newInput[i], pictureBox, trackBar, label));
            }
        }

        private PlotView DrawInput(LinguisticVariable variable)
        {
            if (variable.BaseSet == null)
            {
                return null;
            }

            var plotModel = new PlotModel { Title = variable.Name };

            var baseSetValues = variable.ObjectSetToList();
            var data = variable.Graphic();

            LineSeries[] lineSeries = new LineSeries[variable.CountFunc];
            for (int i = 0; i < lineSeries.Length; i++)
            {
                Color color = variable.GetColor(variable[i]);
                lineSeries[i] = new LineSeries
                {
                    Title = variable[i].Name,
                    Color = OxyColor.FromRgb(color.R, color.G, color.B)
                };
            }

            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 0; j < variable.CountFunc; j++)
                {
                    lineSeries[j].Points.Add(new DataPoint(Convert.ToDouble(baseSetValues[i]), data[i].Item2[j]));
                }
            }

            foreach (var value in lineSeries)
            {
                plotModel.Series.Add(value);
            }

            ScatterSeries series = new ScatterSeries();
            series.Points.Add(new ScatterPoint(Convert.ToDouble(baseSetValues[0]), 0, 0));
            series.Points.Add(new ScatterPoint(Convert.ToDouble(baseSetValues[^1]), 0, 0));
            plotModel.Series.Add(series);

            return new PlotView
            {
                Model = plotModel,
                Dock = DockStyle.Fill
            };
        }
    }
}
