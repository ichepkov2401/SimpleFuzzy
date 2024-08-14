using System.IO;
using System.Runtime.Loader;
using System.Text;
using System.Xml;
using SimpleFuzzy.Abstract;

namespace SimpleFuzzy.Service
{
    public class ProjectListService : IProjectListService
    {
        public string pathPL = Directory.GetCurrentDirectory() + "\\ProjectsList.tt";
        public IRepositoryService repository;
        public IAssemblyLoaderService loaderService;
        public ProjectListService(IAssemblyLoaderService loaderService, IRepositoryService repositoryService)
        {
            repository = repositoryService;
            this.loaderService = loaderService;
        }
        public string? CurrentProjectName { get; set; }
        public void AddProject(string name, string path)
        {
            if (!IsContainsName(name))
            {
                if (name == "") throw new InvalidOperationException("Некорректное имя проекта");
                CurrentProjectName = name;
                FileStream file = new FileStream(pathPL, FileMode.Append);
                StreamWriter writer = new StreamWriter(file);
                writer.WriteLine(name);
                writer.WriteLine(path);
                writer.WriteLine("--------------------");
                writer.Close();
                file.Close();
                DirectoryInfo directory = new DirectoryInfo(path);
                directory.Create();
                loaderService.UnloadAllAssemblies();
            }
            else { throw new InvalidOperationException("Проект с таким именем уже существует"); }
        }
        private void AddAssemblies(string path) 
        {
                foreach (string fileName in Directory.GetFiles(path))
                {
                    if (fileName.Split('\\')[^1] != "Save.xml") loaderService.AssemblyLoader(fileName);
                }
        }
        private void ChooseActive()
        {
            if (File.Exists(GivePath(CurrentProjectName, true) + "\\Save.xml"))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(GivePath(CurrentProjectName, true) + "\\Save.xml");
                XmlNodeList list = doc.ChildNodes[0].ChildNodes[0].ChildNodes;
                foreach (XmlNode moduleNode in list)
                {
                    XmlNodeList moduleList = moduleNode.ChildNodes;
                    string moduleName = moduleList[0].InnerText;
                    string assemblyName = moduleList[1].InnerText;
                    string active = moduleList[2].InnerText;
                    bool status;
                    if (active == "true") status = true;
                    else status = false;
                    bool isContinue = false;
                    for (int i = 0; i < repository.GetCollection<IMembershipFunction>().Count; i++)
                    {
                        if (repository.GetCollection<IMembershipFunction>()[i].GetType().Name == moduleName &&
                            repository.GetCollection<IMembershipFunction>()[i].GetType().Assembly.FullName == assemblyName)
                        {
                            repository.GetCollection<IMembershipFunction>()[i].Active = status;
                            isContinue = true;
                            break;
                        }
                    }
                    if (isContinue) continue;
                    for (int i = 0; i < repository.GetCollection<IObjectSet>().Count; i++)
                    {
                        if (repository.GetCollection<IObjectSet>()[i].GetType().Name == moduleName &&
                            repository.GetCollection<IObjectSet>()[i].GetType().Assembly.FullName == assemblyName)
                        {
                            repository.GetCollection<IObjectSet>()[i].Active = status;
                            isContinue = true;
                            break;
                        }
                    }
                    if (isContinue) continue;
                    for (int i = 0; i < repository.GetCollection<ISimulator>().Count; i++)
                    {
                        if (repository.GetCollection<ISimulator>()[i].GetType().Name == moduleName &&
                            repository.GetCollection<ISimulator>()[i].GetType().Assembly.FullName == assemblyName)
                        {
                            repository.GetCollection<ISimulator>()[i].Active = status;
                            break;
                        }
                    }
                }
            }
        }
        public void OpenProjectfromName(string name)
        {
            if (IsContainsName(name))
            {
                OpenProjectfromPath(GivePath(name, true));
            }
            else
            {
                throw new InvalidOperationException("Проекта с таким именем не существует");
            }
        }
        public void OpenProjectfromPath(string path) 
        {
            if (IsContainsPath(path))
            {
                // открытие проекта
                repository.ClearAll();
                CurrentProjectName = path.Split('\\')[^1];
                loaderService.UnloadAllAssemblies();
                AddAssemblies(path); // подключение сборок
                ChooseActive(); // подключение активности сборок
            }
            else
            {
                throw new InvalidOperationException("Проекта по данному пути не существует");
            }
        }
        public void CopyProject(string name, string path)
        {
            string lastName = CurrentProjectName;
            AddProject(name, path);
            DirectoryInfo directory = new DirectoryInfo(path);
            directory.Create();
            DirectoryInfo source = new DirectoryInfo(GivePath(lastName, true));
            DirectoryInfo destin = new DirectoryInfo(GivePath(name, true));
            foreach (var item in source.GetFiles()) { item.CopyTo(destin + item.Name, true); }
        }
        public void DeleteProject(string name)
        {
            if (IsContainsName(name))
            {
                DirectoryInfo directory = new DirectoryInfo(GivePath(name, true));
                foreach (FileInfo file1 in directory.GetFiles()) { file1.Delete(); }
                Directory.Delete(GivePath(name, true), true);
                loaderService.UnloadAllAssemblies();
                string[] text = GiveList();
                FileStream file = new FileStream(pathPL, FileMode.Truncate);
                StreamWriter writer = new StreamWriter(file);
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] != name) { writer.WriteLine(text[i]); }
                    else { i += 2; }
                }
                writer.Close();
                file.Close();
                CurrentProjectName = null;
            }
            else { throw new InvalidOperationException("Проекта с таким именем не существует"); }
        }
        public void DeleteOnlyInList(string name)
        {
            if (CurrentProjectName == name) { CurrentProjectName = null; }
            string[] text = GiveList();
            FileStream file = new FileStream(pathPL, FileMode.Truncate);
            StreamWriter writer = new StreamWriter(file);
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != name) { writer.WriteLine(text[i]); }
                else { i += 2; }
            }
            writer.Close();
            file.Close();
        }
        public void RenameProject(string name)
        {
            string lastName = CurrentProjectName;
            CopyProject(name, GivePath(CurrentProjectName, false) + $"\\{name}");
            string currentName = CurrentProjectName;
            DeleteProject(lastName);
            CurrentProjectName = currentName;
        }
        public bool IsContainsName(string name)
        {
            FileStream file = new FileStream(pathPL, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(file);
            string? line;
            while (true)
            {
                line = reader.ReadLine();
                if (line != null)
                {
                    if (line == name)
                    {
                        reader.Close();
                        file.Close();
                        return true;
                    }
                }
                else
                {
                    reader.Close();
                    file.Close();
                    return false;
                }
                reader.ReadLine();
                reader.ReadLine();
            }
        }
        public bool IsContainsPath(string path)
        {
            string[] list = GiveList();
            for (int i = 1; i < list.Length; i++)
            {
                if (path == list[i])
                {
                    CurrentProjectName = list[i - 1]; // Устанавливаем имя текущего проекта
                    return true;
                }
            }
            return false;
        }
        public string GivePath(string name, bool isFull) 
        {
            if (IsContainsName(name))
            {
                string path = "";
                string[] text = GiveList();
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] == name)
                    {
                        path = text[i + 1];
                        break;
                    }
                }
                if (isFull) return path;
                else
                {
                    string newPath = "";
                    int count = 0;
                    for (int i = path.Length - 1, j = 0; i != 0; i--, j++) { if (path[i] == '\\') { count = j + 1; break; } }
                    for (int i = 0; i < path.Length - count; i++) { newPath += path[i]; }
                    return newPath;
                }
            }
            else { throw new InvalidOperationException("Проекта с таким именем не существует"); }
        }
        public string[] GiveList()
        {
            FileStream file = new FileStream(pathPL, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(file);
            List<string> list = new List<string>();
            while (true)
            {
                string line = reader.ReadLine();
                if (line == null) { break; }
                else
                {
                    list.Add(line);
                }
            }
            reader.Close();
            file.Close();
            string[] text = new string[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                text[i] = list.ElementAt(i);
            }
            return text;
        }
        public void SaveActiveModulesXML()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("saves");
            doc.AppendChild(root);
            XmlElement activeModules = doc.CreateElement("activeModules");
            root.AppendChild(activeModules);
            for (int i = 0; i < repository.GetCollection<IMembershipFunction>().Count; i++)
            {
                XmlElement module = doc.CreateElement("module");
                activeModules.AppendChild(module);
                string moduleName = repository.GetCollection<IMembershipFunction>()[i].GetType().Name;
                string assemblyName = repository.GetCollection<IMembershipFunction>()[i].GetType().Assembly.FullName;
                string active;
                if (repository.GetCollection<IMembershipFunction>()[i].Active) active = "true";
                else active = "false";
                XmlElement moduleNameXML = doc.CreateElement("moduleName");
                moduleNameXML.InnerText = moduleName;
                module.AppendChild(moduleNameXML);
                XmlElement assemblyNameXML = doc.CreateElement("assemblyName");
                assemblyNameXML.InnerText = assemblyName;
                module.AppendChild(assemblyNameXML);
                XmlElement activeXML = doc.CreateElement("active");
                activeXML.InnerText = active;
                module.AppendChild(activeXML);
            }
            for (int i = 0; i < repository.GetCollection<IObjectSet>().Count; i++)
            {
                XmlElement module = doc.CreateElement("module");
                activeModules.AppendChild(module);
                string moduleName = repository.GetCollection<IObjectSet>()[i].GetType().Name;
                string assemblyName = repository.GetCollection<IObjectSet>()[i].GetType().Assembly.FullName;
                string active;
                if (repository.GetCollection<IObjectSet>()[i].Active) active = "true";
                else active = "false";
                XmlElement moduleNameXML = doc.CreateElement("moduleName");
                moduleNameXML.InnerText = moduleName;
                module.AppendChild(moduleNameXML);
                XmlElement assemblyNameXML = doc.CreateElement("assemblyName");
                assemblyNameXML.InnerText = assemblyName;
                module.AppendChild(assemblyNameXML);
                XmlElement activeXML = doc.CreateElement("active");
                activeXML.InnerText = active;
                module.AppendChild(activeXML);
            }
            for (int i = 0; i < repository.GetCollection<ISimulator>().Count; i++)
            {
                XmlElement module = doc.CreateElement("module");
                activeModules.AppendChild(module);
                string moduleName = repository.GetCollection<ISimulator>()[i].GetType().Name;
                string assemblyName = repository.GetCollection<ISimulator>()[i].GetType().Assembly.FullName;
                string active;
                if (repository.GetCollection<ISimulator>()[i].Active) active = "true";
                else active = "false";
                XmlElement moduleNameXML = doc.CreateElement("moduleName");
                moduleNameXML.InnerText = moduleName;
                module.AppendChild(moduleNameXML);
                XmlElement assemblyNameXML = doc.CreateElement("assemblyName");
                assemblyNameXML.InnerText = assemblyName;
                module.AppendChild(assemblyNameXML);
                XmlElement activeXML = doc.CreateElement("active");
                activeXML.InnerText = active;
                module.AppendChild(activeXML);
            }
            doc.Save(GivePath(CurrentProjectName, true) + "\\Save.xml");
        }
    }
}