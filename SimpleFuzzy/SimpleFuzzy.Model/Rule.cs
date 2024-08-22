using SimpleFuzzy.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFuzzy.Model
{
    public class Rule
    {
        public List<IMembershipFunction> terms; // Список термов
        public double relevance; // Степень заполняемости
        public bool IsActive { get; set; } // Автосвойство активности
        public Rule(IMembershipFunction outVar, List<IMembershipFunction> inpitVar, double relevanse)
        {
            terms.Add(outVar);
            foreach(IMembershipFunction function in inpitVar) { terms.Add(function); }
            relevance = relevanse;
        }

    }
}
