using System;
using System.IO;
using System.Windows.Forms;
using SimpleFuzzy.Service;
// ��-�� ��������� ��������������� Metroframework � .NET 6.0,
// �������� ���������� ���������� ��� WinForms

namespace SimpleFuzzy.View
{
    public partial class LoaderForm : Form
    {
        private readonly SimpleFuzzy.Service.AssemblyLoaderService assemblyLoaderService;

        public LoaderForm()
        {
            InitializeComponent();
            assemblyLoaderService = new SimpleFuzzy.Service.AssemblyLoaderService();
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
                messageTextBox.Text = "����������, ������� ���� � �����.";
                return;
            }

            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("��������� ���� �� ����������.", filePath);
                }

                if (Path.GetExtension(filePath).ToLower() != ".dll")
                {
                    throw new BadImageFormatException("���� ������ ����� ���������� .dll");
                }

                string assemblyName = assemblyLoaderService.GetInfo(filePath);
                messageTextBox.Text = $"������ ������� ��������: {assemblyName}";
            }
            catch (FileNotFoundException ex)
            {
                messageTextBox.Text = $"������: ���� �� ������. {ex.Message}";
            }
            catch (BadImageFormatException ex)
            {
                messageTextBox.Text = $"������: �������� ������ �����. {ex.Message}";
            }
            catch (Exception ex)
            {
                messageTextBox.Text = $"������ ��� �������� ������: {ex.Message}";
            }
        }
    }
}