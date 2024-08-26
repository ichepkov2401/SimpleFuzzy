using SimpleFuzzy.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFuzzy.Model
{
    public class SetRule
    {
        // список словарей
        public List<Rule> rules; // список правил с одной и той же выходной переменной
        public List<LinguisticVariable> inputVariables; // список входных переменных
        public LinguisticVariable outVariable; // выходная переменная
        public SetRule(LinguisticVariable var)
        {
            outVariable = var;
            rules = new List<Rule>();
            inputVariables = new List<LinguisticVariable>();
        }

        public void AddInputVar(LinguisticVariable inputVar)
        {
            // Добавляем пустые термы
            foreach (var rule in rules) { rule.AddNullTerm(); }
            // Добавляем ЛП
            inputVariables.Add(inputVar);
        }
        // Потом ссылки добавятся
        public void DeleteRule(int position)
        {
            rules.RemoveAt(position);
        }
        // Потом ссылки добавятся
        public void DeleteInputVar(string name, int position)
        {
            int index = 0;
            // Удаляем ЛП из списка
            for (int i = 1; i < inputVariables.Count; i++)
            {
                if (inputVariables[i].Name == name)
                {
                    inputVariables.RemoveAt(i);
                    index = i;
                    break;
                }
            }
            // Удаляем термы из всех правил для удаляемой ЛП
            foreach (var rule in rules) { rule.DeleteTerm(position); }
        }

        private bool IsSameRules(Rule rule1, Rule rule2)
        {
            List<IMembershipFunction> list1 = rule1.GiveList();
            List<IMembershipFunction> list2 = rule2.GiveList();
            for (int i = 0; i < list1.Count; i++) { if (list1[i] != list2[i]) return false; }
            return true;
        }

        private bool WasSameRules(Rule rule1, Rule rule2)
        {
            int count = 0;
            List<IMembershipFunction> list1 = rule1.GiveList();
            List<IMembershipFunction> list2 = rule2.GiveList();
            for (int i = 0; i < list1.Count; i++) 
            {
                if (list1[i] != list2[i]) count++;
            }
            if (count == 1) return true;
            else return false;
        }

        public int OpenOtherRule(int position)
        {
            for (int i = position + 1; i < rules.Count - 1; i++)
            {
                if (WasSameRules(rules[position], rules[i]) && !rules[i].IsActive) return i;
            }
            return -1; 
        }
        public int OpenThisRule(int position)
        {
            for (int i = position - 1; i >= 0; i--)
            {
                if (IsSameRules(rules[position], rules[i])) return -1;
            }
            rules[position].IsActive = true;
            return position;
        }
        public int BlockedSameRules(int position)
        {
            for (int i = position - 1; i >= 0; i--) 
            {
                if (IsSameRules(rules[position], rules[i]))
                {
                    rules[position].IsActive = false;
                    return position;
                }
            }
            for (int i = position + 1; i < rules.Count - 1; i++)
            {
                if (IsSameRules(rules[position], rules[i]))
                {
                    rules[i].IsActive = false;
                    return i;
                }
            }
            return -1; // Сюда заходить не должен, надо чтоб возвращали все пути
        }
    }
}
