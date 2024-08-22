using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFuzzy.Model
{
    public class SetRule
    {
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
            inputVariables.Add(inputVar);
        }

        public void DeleteInputVar(string name)
        {
            foreach(LinguisticVariable var in inputVariables)
            {
                if (var.Name == name)
                {
                    inputVariables.Remove(var);
                    break;
                }
            }
        }
    }
}
