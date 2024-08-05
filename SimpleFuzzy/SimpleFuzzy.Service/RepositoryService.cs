using SimpleFuzzy.Abstract;
using SimpleFuzzy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFuzzy.Service
{
    public class RepositoryService : IRepositoryService
    {
        // Коллекции для хранения различных типов объектов
        private readonly List<AssemblyLoadContext> loadContexts;
        private readonly List<IMembershipFunction> _membershipFunctions;
        private readonly List<IObjectSet> _objectSets;
        private readonly List<ISimulator> _simulators;

        public RepositoryService()
        {
            loadContexts = new List<AssemblyLoadContext>();
            _objectSets = new List<IObjectSet>();
            _membershipFunctions = new List<IMembershipFunction>();
            _simulators = new List<ISimulator>();
        }
        // Метод добавления элементов в коллекции
        public void AddAssemblyElements(AssemblyLoadContext context) 
        {
            loadContexts.Add(context);
            for (int i = 0; i < context.Assemblies.Count(); i++)
            {
                Type[] array = context.Assemblies.ElementAt(i).GetTypes();
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[j].IsAbstract || array[j].IsInterface) { continue; }

                    if (array[j] is IMembershipFunction)
                    {
                        try { _membershipFunctions.Add(array[j].GetConstructor(null).Invoke(null) as IMembershipFunction); }
                        catch { }
                    }
                    else if (array[j] is IObjectSet)
                    {
                        try { _objectSets.Add(array[j].GetConstructor(null).Invoke(null) as IObjectSet); }
                        catch { }
                    }
                    else if (array[j] is ISimulator)
                    {
                        try { _simulators.Add(array[j].GetConstructor(null).Invoke(null) as ISimulator); }
                        catch { }
                    }
                }
            }
        }

        // Универсальный метод для получения коллекций
        public List<T> GetCollection<T>()
        {
            if (typeof(T) == typeof(IObjectSet))
            {
                return (List<T>)(object)_objectSets;
            }
            if (typeof(T) == typeof(IMembershipFunction))
            {
                return (List<T>)(object)_membershipFunctions;
            }
            if (typeof(T) == typeof(ISimulator))
            {
                return (List<T>)(object)_simulators;
            }

            throw new InvalidOperationException($"Collection for type {typeof(T).Name} is not supported.");
        }
    }
}
