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
        // НА НУЛЕВОЙ ПОЗИЦИИ ВСЕГДА ТЕРМ ВЫХОДНОЙ ПЕРЕМЕННОЙ
        private Dictionary<int, string> terms = new Dictionary<int, string>(); // Список термов методы 
        public double relevance = 1.0; // Степень заполняемости
        public bool IsActive { get; set; } // Автосвойство активности

        public void AddTerm(string name, int position)
        {
            terms.Add(position, name);
        }

        public void RedactTerm(string lastName, string newName)
        {
            for (int i = 0; i < terms.Count; i++)
            {
                if (terms[i] == lastName)
                {
                    terms[i] = newName;
                    return;
                }
            }
        }
    }
}
