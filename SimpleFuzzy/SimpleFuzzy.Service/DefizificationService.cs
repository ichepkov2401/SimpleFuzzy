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
                output.BaseSet.ToFirst();
                object result = output.BaseSet.Extraction();
                max = 0;
                for (; !output.BaseSet.IsEnd(); output.BaseSet.MoveNext())
                {
                    object now = output.BaseSet.Extraction();
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
                int count = 0;
                for (output.BaseSet.ToFirst(); !output.BaseSet.IsEnd(); output.BaseSet.MoveNext())
                    count++;
                output.BaseSet.ToFirst();
                for (int i = 0; i < count / 2; i++) output.BaseSet.MoveNext();
                return output.BaseSet.Extraction();
            }
        }
    }
}
