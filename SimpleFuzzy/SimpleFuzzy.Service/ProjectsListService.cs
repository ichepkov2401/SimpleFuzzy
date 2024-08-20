using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.Loader;
using System.Text;
using System.Xml;
using SimpleFuzzy.Abstract;
using SimpleFuzzy.Model;

namespace SimpleFuzzy.Service
{
    public class ProjectListService : IProjectListService
    {
        public string pathPL = Directory.GetCurrentDirectory() + "\\ProjectsList.tt";
        public IRepositoryService repository;
        public IAssemblyLoaderService loaderService;
        Dictionary<string, Action<XmlNodeList>> pair = new Dictionary<string, Action<XmlNodeList>>();
        public ProjectListService(IAssemblyLoaderService loaderService, IRepositoryService repositoryService)
        {
            repository = repositoryService;
            this.loaderService = loaderService;
            pair.Add("activeModules", ChooseActive);
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

        public void LoadAll(string name = "\\Save.xml")
        {
            if (File.Exists(GivePath(CurrentProjectName, true) + name))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(GivePath(CurrentProjectName, true) + name);
                var root = doc.DocumentElement;
                for (int i = 0; i < root.ChildNodes.Count; i++)
                {
                    Action<XmlNodeList> action;
                    if (pair.TryGetValue(root.ChildNodes[i].Name, out action))
                    {
                        action(root.ChildNodes[i].ChildNodes);
                    }
                }
            }
        }

        private void ChooseActive(XmlNodeList list)
        {
            foreach (XmlNode moduleNode in list)
            {
                string moduleName = moduleNode.Attributes["moduleName"].Value;
                string assemblyName = moduleNode.Attributes["assemblyName"].Value;
                bool status;
                if (moduleNode.InnerText == "true") status = true;
                else status = false;

                bool isContinue = false;
                IModulable module = repository.GetCollection<IMembershipFunction>().FirstOrDefault(t => t.GetType().Name == moduleName && assemblyName == t.GetType().Assembly.FullName);
                if (module != null) { 
                    module.Active = status;
                    continue;
                }
                module = repository.GetCollection<IObjectSet>().FirstOrDefault(t => t.GetType().Name == moduleName && assemblyName == t.GetType().Assembly.FullName);
                if (module != null)
                {
                    module.Active = status;
                    continue;
                }
                module = repository.GetCollection<ISimulator>().FirstOrDefault(t => t.GetType().Name == moduleName && assemblyName == t.GetType().Assembly.FullName);
                if (module != null)
                {
                    module.Active = status;
                    continue;
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
                loaderService.UnloadAllAssemblies();
                repository.ClearAll();
                CurrentProjectName = path.Split('\\')[^1];
                AddAssemblies(path); // подключение сборок
                LoadAll(); // загрузка сохранения
            }
            else
            {
                throw new InvalidOperationException("Проекта по данному пути не существует");
            }
        }
        public void CopyProject(string name, string path)
        {
            string lastName = CurrentProjectName;
            SaveAll("\\SaveCopy.xml");
            AddProject(name, path);
            DirectoryInfo source = new DirectoryInfo(GivePath(lastName, true));
            DirectoryInfo destin = new DirectoryInfo(GivePath(name, true));
            foreach (var item in source.GetFiles()) { item.CopyTo(destin + "\\" +  item.Name, true); }
            File.Delete(GivePath(lastName, true) + "\\SaveCopy.xml");
            File.Delete(GivePath(name, true) + "\\Save.xml");
            File.Move(GivePath(name, true) + "\\SaveCopy.xml", GivePath(name, true) + "\\Save.xml");
            OpenProjectfromName(name);
        }
        public void DeleteProject(string name)
        {
            if (IsContainsName(name))
            {
                DirectoryInfo directory = new DirectoryInfo(GivePath(name, true));
                loaderService.UnloadAllAssemblies();
                foreach (FileInfo file1 in directory.GetFiles()) { file1.Delete(); }
                Directory.Delete(GivePath(name, true), true);
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

        public void SaveAll(string name = "\\Save.xml")
        {
            // открытие xml файла
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("saves");
            doc.AppendChild(root);
            XmlElement activeModules = doc.CreateElement("activeModules");
            root.AppendChild(activeModules);
            // методы сохранения
            SaveActiveModulesXML(activeModules);
            // сохранение xml файла
            doc.Save(GivePath(CurrentProjectName, true) + name);
        }

        private void SaveActiveModulesXML(XmlElement activeModules)
        {
            var s = repository.GetCollection<IMembershipFunction>().Cast<IModulable>().
                Concat(repository.GetCollection<IObjectSet>().Cast<IModulable>()).
                Concat(repository.GetCollection<ISimulator>().Cast<IModulable>());
            foreach (IModulable element in s)
            {
                XmlElement module = activeModules.OwnerDocument.CreateElement("module");
                activeModules.AppendChild(module);
                string moduleName = element.GetType().Name;
                string assemblyName = element.GetType().Assembly.FullName;
                string active;
                if (element.Active) active = "true";
                else active = "false";

                XmlAttribute moduleNameXML = activeModules.OwnerDocument.CreateAttribute("moduleName");
                moduleNameXML.Value = moduleName;
                module.Attributes.Append(moduleNameXML);

                XmlAttribute assemblyNameXML = activeModules.OwnerDocument.CreateAttribute("assemblyName");
                assemblyNameXML.Value = assemblyName;
                module.Attributes.Append(assemblyNameXML);

                module.InnerText = active;
            }
        }
        public List<LinguisticVariable> LoadLinguisticVariable(XmlNode xmlParent)
        {
            var ListofLinguisticVariable = new List<LinguisticVariable>();
            foreach (XmlNode xmlLinguistic in xmlParent.ChildNodes)
            {
                string namefromNode = xmlLinguistic["name"].InnerText;
                bool redactfromNode = bool.Parse(xmlLinguistic["isRedact"].InnerText);
                IObjectSet? newSet = null;
                foreach (var objectSet in repository.GetCollection<IObjectSet>())
                {
                    if (objectSet.GetType().FullName + " " + objectSet.GetType().Assembly.FullName == xmlLinguistic["baseSet"].InnerText)
                    {
                        newSet = objectSet;
                        break;
                    }
                }
                var membershipFunctions = new List<(IMembershipFunction, Color)>();
                foreach (var function in repository.GetCollection<IMembershipFunction>())
                {
                    foreach (XmlNode childnode in xmlLinguistic["func"].ChildNodes)
                    {
                        if (function.GetType().FullName + " " + function.GetType().Assembly.FullName == childnode.InnerText)
                        {
                            string r = childnode.Attributes["R"].Value;
                            string g = childnode.Attributes["G"].Value;
                            string b = childnode.Attributes["B"].Value;
                            if (r != null && g != null && b != null)
                                membershipFunctions.Add((function, Color.FromArgb(int.Parse(r), int.Parse(g), int.Parse(b))));
                            else
                                membershipFunctions.Add((function, Color.Black));
                        }
                    }
                }
                ListofLinguisticVariable.Add(new LinguisticVariable(namefromNode, redactfromNode, newSet, membershipFunctions));
            }
            return ListofLinguisticVariable;
        }
    }
}