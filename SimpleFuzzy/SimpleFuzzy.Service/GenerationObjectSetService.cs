using SimpleFuzzy.Abstract;

namespace SimpleFuzzy.Service
{
    public class GenerationObjectSetService : IGenerationObjectSetService
    {
        public string ReturnObjectSet(double first, double stepik, double last, string name)
        {
            int digits = 0;
            for (var values = (first, stepik, last);
                (int)values.first != values.first ||
                (int)values.stepik != values.stepik ||
                (int)values.last != values.last;
                values = (values.first * 10, values.stepik * 10, values.last * 10))
                digits++;

            if (Math.Sign(last - first) != Math.Sign(stepik) || stepik == 0)
            {
                throw new InvalidOperationException("Создание множества с такими параметрами невозможно");
            }
            else
            {
                string classTemplate = $@"
using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using SimpleFuzzy.Abstract;
namespace SimpleFuzzy.GenerateModule
{{
    public class ObjectSet : IObjectSet
    {{
        private double initalvalue = {first.ToString().Replace(',', '.')};
        private double currentvalue = {first.ToString().Replace(',', '.')};
        private double limitvalue = {last.ToString().Replace(',', '.')};
        private double step = {stepik.ToString().Replace(',', '.')};

        public bool Active {{ get; set; }}

        public string Name {{ get; set; }} = ""{name}"";

        public object Extraction()
        {{
            return currentvalue;
        }}

        public void MoveNext()
        {{
            currentvalue = Math.Round(currentvalue + step, {digits});
        }}

        public void ToFirst() => currentvalue = initalvalue;

        public bool IsEnd() => currentvalue > limitvalue;
    }}
}}
";
                return classTemplate;
            }
        }
    }
}
