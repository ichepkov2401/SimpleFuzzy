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
                if (terms[index + 1] == null) return 0;
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
        private SetRule setRule;

        public Rule(int count, SetRule setRule) 
        {
            this.setRule = setRule;
            for (int i = 0; i < count; i++) { AddNullTerm(); }
        }
        public void AddNullTerm()
        {
            terms.Add(null);
        }
        public void DeleteTerm(int position)
        {
            terms.RemoveAt(position);
        }
        public void RedactTerm(IMembershipFunction func, int position)
        {
            terms[position] = func;
        }
    }
}
