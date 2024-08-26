using SimpleFuzzy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFuzzy.Service
{
    public class DefizificationService : IDefazificationService
    {
        public object Defazification(LinguisticVariable output, List<object> input, IDefazificationService.Methods method, Rule.Inference inference)
        {
            return MaxMethod(output, input, inference);
        }

        private object MaxMethod(LinguisticVariable output, List<object> input, Rule.Inference inference)
        {
            double max = 0;
            Rule maxRule = null;
            foreach(var rule in output.ListRules.rules)
            {
                (LinguisticVariable, object)[] values = new (LinguisticVariable, object)[input.Count];
                for (int i = 0; i < output.ListRules.inputVariables.Count; i++)
                    values[i] = (output.ListRules.inputVariables[i], input[i]);
                double res = rule.CalcRule(values, inference);
                if (max < res)
                {
                    max = res;
                    maxRule = rule;
                }
            }
            if (maxRule != null)
            {
                object result = output.BaseSet[0];
                max = 0;
                for (int i = 0 ; i < output.BaseSet.Count; i++)
                {
                    object now = output.BaseSet[i];
                    double value = maxRule[0].MembershipFunction(now);
                    if (value > max)
                    {
                        result = now;
                        max = value;
                    }
                }
                return result;
            }
            else
            {
                return output.BaseSet[output.BaseSet.Count / 2];
            }
        }
    }
}
