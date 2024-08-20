using MetroFramework.Controls;
using SimpleFuzzy.Abstract;
using SimpleFuzzy.Model;

namespace SimpleFuzzy.View
{
    public partial class DefasificationForm : MetroUserControl
    {
        IRepositoryService repositoryService;
        DefasificationUI defasificationUI;
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
            if (defasificationUI != null)
            {
                Controls.Remove(defasificationUI);
                defasificationUI.Dispose();

            }
            var variable = repositoryService.GetCollection<LinguisticVariable>().FirstOrDefault(v => v.Name == OutputVariables.SelectedItem.ToString());
            defasificationUI = new DefasificationUI(variable);
            Controls.Add(defasificationUI);
            defasificationUI.Location = new Point(0, 0);
                
        }
    }
}
