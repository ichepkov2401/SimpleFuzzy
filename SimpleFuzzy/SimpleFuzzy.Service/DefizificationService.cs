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
            switch (method)
            {
                case IDefazificationService.Methods.Max:
                    return MaxMethod(output, input, inference);
                case IDefazificationService.Methods.AvgMax:
                    return AvgMaxMethod(output, input, inference);
                case IDefazificationService.Methods.LinarLeft:
                    return LeftMethod(output, input, inference);
                case IDefazificationService.Methods.LinarRight:
                    return RightMethod(output, input, inference);
                case IDefazificationService.Methods.CenterOfWight:
                    return CenterOfWightMethod(output, input, inference);
                default:
                    return 0;
            }
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

        private object AvgMaxMethod(LinguisticVariable output, List<object> input, Rule.Inference inference)
        {
            double max = 0;
            List<Rule> maxRules = new List<Rule>();
            foreach (var rule in output.ListRules.rules)
            {
                (LinguisticVariable, object)[] values = new (LinguisticVariable, object)[input.Count];
                for (int i = 0; i < output.ListRules.inputVariables.Count; i++)
                    values[i] = (output.ListRules.inputVariables[i], input[i]);
                double res = rule.CalcRule(values, inference);
                if (max < res)
                {
                    max = res;
                    maxRules.Clear();
                    maxRules.Add(rule);
                }
                else if (max == res)
                    maxRules.Add(rule);
            }
            if (maxRules.Count > 0)
            {
                return output.BaseSet[maxRules.ConvertAll(x =>
                {
                    int result = 0;
                    max = 0;
                    for (int i = 0; i < output.BaseSet.Count; i++)
                    {
                        object now = output.BaseSet[i];
                        double value = x[0].MembershipFunction(now);
                        if (value > max)
                        {
                            result = i;
                            max = value;
                        }
                    }
                    return result;
                }).Aggregate((x, y) => x + y) / maxRules.Count];
            }
            else
            {
                return output.BaseSet[output.BaseSet.Count / 2];
            }
        }

        private object LeftMethod(LinguisticVariable output, List<object> input, Rule.Inference inference)
        {
            double max = 0;
            Rule maxRule = null;
            foreach (var rule in output.ListRules.rules)
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
                double dist = 1;
                object result = output.BaseSet[0];
                for (int i = 0; i < output.BaseSet.Count; i++)
                {
                    object now = output.BaseSet[i];
                    double value = maxRule[0].MembershipFunction(now);
                    if (Math.Abs(value - max) < dist)
                    {
                        result = now;
                        dist = Math.Abs(value - max);
                    }
                }
                return result;
            }
            else
            {
                return output.BaseSet[output.BaseSet.Count / 2];
            }
        }

        private object RightMethod(LinguisticVariable output, List<object> input, Rule.Inference inference)
        {
            double max = 0;
            Rule maxRule = null;
            foreach (var rule in output.ListRules.rules)
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
                double dist = 1;
                object result = output.BaseSet[output.CountFunc - 1];
                for (int i = output.BaseSet.Count - 1; i >= 0; i--)
                {
                    object now = output.BaseSet[i];
                    double value = maxRule[0].MembershipFunction(now);
                    if (Math.Abs(value - max) < dist)
                    {
                        result = now;
                        dist = Math.Abs(value - max);
                    }
                }
                return result;
            }
            else
            {
                return output.BaseSet[output.BaseSet.Count / 2];
            }
        }

        private object CenterOfWightMethod(LinguisticVariable output, List<object> input, Rule.Inference inference)
        {
            double d;
            if (double.TryParse(output.BaseSet[0].ToString(), out d) && output.ListRules.rules.Count > 0)
            {
                double globalSum = 0;
                double count = 0;
                foreach (var rule in output.ListRules.rules)
                {
                    if (rule[0] != null)
                    {
                        (LinguisticVariable, object)[] values = new (LinguisticVariable, object)[input.Count];
                        for (int i = 0; i < output.ListRules.inputVariables.Count; i++)
                            values[i] = (output.ListRules.inputVariables[i], input[i]);
                        double res = rule.CalcRule(values, inference);
                        double sum = 0;
                        for (int i = 1; i < output.BaseSet.Count; i++)
                        {
                            double right = double.Parse(output.BaseSet[i].ToString());
                            double left = double.Parse(output.BaseSet[i - 1].ToString());
                            sum += rule[0].MembershipFunction(output.BaseSet[i]) * (right - left) * right * res;
                            if (rule[0].MembershipFunction(output.BaseSet[i]) * (right - left) * right * res != 0)
                                count += rule[0].MembershipFunction(output.BaseSet[i]) * res * (right - left);
                        }
                        globalSum += sum;
                    }
                }
                return globalSum / count;
            }
            else return output.BaseSet[output.BaseSet.Count / 2];
        }
    }
}
