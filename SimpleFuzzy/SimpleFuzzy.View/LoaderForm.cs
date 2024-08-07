using MetroFramework.Forms;
using MetroFramework;
using MetroFramework.Controls;
using SimpleFuzzy.Abstract;
using SimpleFuzzy.Service;
using System.Runtime.Loader;
using System.Reflection;

namespace SimpleFuzzy.View
{
    public partial class LoaderForm : MetroUserControl
    {
        private IAssemblyLoaderService moduleLoaderService;

        public LoaderForm()
        {
            InitializeComponent();
            moduleLoaderService = AutofacIntegration.GetInstance<IAssemblyLoaderService>();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "DLL files (*.dll)|*.dll";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePathTextBox.Text = openFileDialog.FileName;
                }
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            string filePath = filePathTextBox.Text;
            if (string.IsNullOrWhiteSpace(filePath))
            {
                messageTextBox.Text = "Пожалуйста, укажите путь к файлу.";
                return;
            }

            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("Указанный файл не существует.", filePath);
                }

                if (Path.GetExtension(filePath).ToLower() != ".dll")
                {
                    throw new FileFormatException("Файл должен иметь расширение .dll");
                }

                string assemblyName = moduleLoaderService.GetInfo(filePath);
                TreeViewShow();
                messageTextBox.Text = $"Модуль успешно загружен: {assemblyName}";
            }
            catch (FileNotFoundException ex)
            {
                messageTextBox.Text = $"Ошибка: Файл не найден. {ex.Message}";
            }
            catch (FileFormatException ex)
            {
                messageTextBox.Text = $"Ошибка: Неверный формат файла. {ex.Message}";
            }
            catch (Exception ex)
            {
                messageTextBox.Text = $"Неизвестная ошибка: {ex.Message}";
            }
        }
        private void TreeViewShow()
        {
            var (membershipFunctions, objectSets, simulators) = moduleLoaderService.AddElements(moduleLoaderService.AssemblyContextList);
            treeView1.Nodes.Clear();

            TreeNode termsNode = treeView1.Nodes.Add("Термы");
            TreeNode setsNode = treeView1.Nodes.Add("Базовые множества");
            TreeNode simulationsNode = treeView1.Nodes.Add("Симуляции");

            foreach (var term in membershipFunctions) { termsNode.Nodes.Add(term.GetType().Name); }
            foreach (var set in objectSets) { setsNode.Nodes.Add(set.GetType().Name); }
            foreach (var simulation in simulators) { simulationsNode.Nodes.Add(simulation.GetType().Name); }

            treeView1.ExpandAll(); // Для лучшей видимости
        }
    }
}