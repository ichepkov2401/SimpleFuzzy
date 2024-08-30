using SimpleFuzzy.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SimpleFuzzy.Model
{
    public class Rule
    {

        public enum Inference
        {
            Min,
            Prod
        }

        public double CalcRule((LinguisticVariable, object)[] input, Inference inference)
        {
            double res = relevance;
            foreach (var variable in input)
            {
                int index = setRule.inputVariables.IndexOf(variable.Item1);
                double fazizfication = terms[index + 1].MembershipFunction(variable.Item2);
                if (Inference.Min == inference)
                    res = Math.Min(res, fazizfication);
                else
                    res *= fazizfication;
            }
            return res;
        }

        public IMembershipFunction this[int index] => terms[index];

        // НА НУЛЕВОЙ ПОЗИЦИИ ВСЕГДА ТЕРМ ВЫХОДНОЙ ПЕРЕМЕННОЙ
        private List<IMembershipFunction> terms = new List<IMembershipFunction>(); // Список термов 
        public double relevance = 1; // Степень заполняемости
        public bool IsActive { get; set; } // Автосвойство активности
        public bool IsDublicate { get; set; } // Автосвойство дубликатности
        private SetRule setRule;

        public Rule(int count, SetRule setRule) 
        {
            this.setRule = setRule;
            IsActive = true;
            IsDublicate = false;
            for (int i = 0; i < count; i++) { AddNullTerm(); }
        }
        public List<IMembershipFunction> GiveList()
        {
            return terms;
        }
        public void AddNullTerm()
        {
            terms.Add(null);
            IsActive = false;
        }
        public void DeleteTerm(int position)
        {
            terms.RemoveAt(position);
        }
        public void RedactTerm(IMembershipFunction func, int position)
        {
            terms[position] = func;
            foreach (IMembershipFunction term in terms) 
            {
                if (term == null)
                {
                    IsActive = false;
                    return;
                }
            }
            IsActive = true;
        }
        public bool isEmpty()
        {
            return terms.Count == 0;
        }
    }
}
