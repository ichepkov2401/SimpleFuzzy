using SimpleFuzzy.Abstract;

namespace SimpleFuzzy.View
{
    public partial class ConfirmRename : UserControl
    {
        IProjectListService projectList;
        public ConfirmRename()
        {
            InitializeComponent();
            projectList = AutofacIntegration.GetInstance<IProjectListService>();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.TrimEnd('.');// Для файла
            textBox1.Text = textBox1.Text.Trim(' ');
            if (FilesPathsNamesValidator.IsValidFileName(textBox1.Text))
            {
                try
                {
                    projectList.RenameProject(textBox1.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Неверное имя файла!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            button2_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Parent is MainWindow parent && parent.lastControlEnum != null)
            {
                parent.ChangeNameOfProject();
                parent.SwichUserControl(parent.lastControlEnum, parent.lastButton);
            }
            else { Parent.Controls.Remove(this); }
        }
    }
}
