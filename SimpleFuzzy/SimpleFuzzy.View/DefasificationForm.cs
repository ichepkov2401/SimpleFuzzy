using MetroFramework.Controls;
using SimpleFuzzy.Abstract;
using SimpleFuzzy.Model;

namespace SimpleFuzzy.View
{
    public partial class DefasificationForm : MetroUserControl
    {
        IRepositoryService repositoryService;
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
                OutputVariables.Items.Add(repositoryService.GetCollection<LinguisticVariable>()[i].Name);
            }
        }

        private void OutputVariables_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
