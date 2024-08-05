﻿using SimpleFuzzy.Abstract;
using SimpleFuzzy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFuzzy.Service
{
    public class RepositoryService : IRepositoryService
    {
        // Коллекции для хранения различных типов объектов
        private readonly List<IObjectSet> _objectSets;
        private readonly List<IMembershipFunction> _membershipFunctions;
        private readonly List<ISimulator> _simulators;

        public RepositoryService()
        {
            _objectSets = new List<IObjectSet>();
            _membershipFunctions = new List<IMembershipFunction>();
            _simulators = new List<ISimulator>();
        }
        // Метод добавления элементов в коллекции
        public void AddAssemblyElements(AssemblyLoaderService assembly) 
        {

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
