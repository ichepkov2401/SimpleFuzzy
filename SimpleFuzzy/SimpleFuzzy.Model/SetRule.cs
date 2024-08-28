﻿using SimpleFuzzy.Abstract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
            foreach (var rule in rules) { rule.AddNullTerm(); }
            inputVariables.Add(inputVar);
        }

        public void DeleteRule(int position)
        {
            rules.RemoveAt(position);
        }

        public void DeleteInputVar(string name, int position)
        {
            int index = 0;
            for (int i = 1; i < inputVariables.Count; i++)
            {
                if (inputVariables[i].Name == name)
                {
                    inputVariables.RemoveAt(i);
                    index = i;
                    break;
                }
            }
            foreach (var rule in rules) { rule.DeleteTerm(position); }
        }

        private bool IsSameRules(Rule rule1, Rule rule2)
        {
            List<IMembershipFunction> list1 = rule1.GiveList();
            List<IMembershipFunction> list2 = rule2.GiveList();
            for (int i = 0; i < list1.Count; i++) { if (list1[i] != list2[i]) return false; }
            return true;
        }

        private bool IsSameRules(List<IMembershipFunction> list1, Rule rule)
        {
            List<IMembershipFunction> list2 = rule.GiveList();
            for (int i = 0; i < list1.Count; i++) { if (list1[i] != list2[i]) return false; }
            return true;
        }

        private bool WasSameRules(Rule rule1, Rule rule2, int column, string lastValue)
        {
            int count = 0;
            List<IMembershipFunction> list1 = rule1.GiveList();
            List<IMembershipFunction> list2 = rule2.GiveList();
            bool isInputChanged = false;
            for (int i = 1; i < list1.Count; i++) 
            {
                if (i != column)
                {
                    if (list1[i] != list2[i]) return false;
                }
                else
                {
                    if (list2[i] == null) return false;
                    if (list2[i].Name != lastValue) return false;
                    isInputChanged = true;
                }
            }
            if (isInputChanged)
            {
                if (list1[0] != list2[0]) return false;
                else return true;
            }
            else
            {
                if (list2[0] == null) return false;
                if (list2[0].Name == lastValue) return true;
                else return false;
            }
        }

        public int OpenOtherRule(int row, int column, string lastValue, bool wasActive) 
        {
            for (int i = row + 1; i < rules.Count - 1; i++)
            {
                if (WasSameRules(rules[row], rules[i], column, lastValue) && wasActive) return i;
            }
            return -1; 
        }
        public int OpenThisRule(int position) 
        {
            for (int i = position - 1; i >= 0; i--)
            {
                if (IsSameRules(rules[position], rules[i])) return -1;
            }
            if (position == 0) return -1;
            rules[position].IsDublicate = false;
            return position;
        }
        public int BlockedSameRules(int position) 
        {
            for (int i = position - 1; i >= 0; i--) 
            {
                if (IsSameRules(rules[position], rules[i]))
                {
                    rules[position].IsDublicate = true;
                    return position;
                }
            }
            for (int i = position + 1; i < rules.Count - 1; i++)
            {
                if (IsSameRules(rules[position], rules[i]))
                {
                    rules[i].IsDublicate = true;
                    return i;
                }
            }
            return -1; 
        }
        public int CheckAfterDelete(List<IMembershipFunction> list) // после удаления правила
        {
            for (int i = 0; i < rules.Count - 1; i++)
            {
                if (IsSameRules(list, rules[i]))
                {
                    rules[i].IsDublicate = false;
                    return i;
                }
            }
            return -1;
        }
        public int CheckAfterDeleteColumn(int position)
        {
            for (int i = position - 1; i >= 0; i--)
            {
                if (IsSameRules(rules[position], rules[i]))
                {
                    rules[position].IsDublicate = true;
                    return position;
                }
            }
            return -1;
        }
    }
}
