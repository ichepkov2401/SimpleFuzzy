using SimpleFuzzy.Abstract;

namespace SimpleFuzzy.Model
{
    public class LinguisticVariable
    {
        public string name; // Имя лингвистической переменной
        public IObjectSet baseSet; // Базовое множество
        public List<IMembershipFunction> func = new List<IMembershipFunction>(); // Список термов
        public readonly bool isRedact; // Возможность редактирования
        private Dictionary<IMembershipFunction, double> heightCache = new Dictionary<IMembershipFunction, double>();
        private Dictionary<IMembershipFunction, string> typeCache = new Dictionary<IMembershipFunction, string>();
        private Dictionary<IMembershipFunction, List<object>> areaOfInfluenceCache = new Dictionary<IMembershipFunction, List<object>>();
        private Dictionary<IMembershipFunction, List<object>> coreCache = new Dictionary<IMembershipFunction, List<object>>();

        public LinguisticVariable(bool isRedact)
        {
            this.isRedact = isRedact;
        }

        public string Name
        {
            get { return name; }
            set { if (isRedact == true) { name = value; } }
        }

        public IObjectSet BaseSet
        {
            get { return baseSet; }
            set { if (isRedact == true) { baseSet = value; } }
        }

        public void AddTerm(IMembershipFunction term)
        {
            Type Type1 = baseSet.Extraction().GetType(), Type2 = func[0].GetType(); // Проверка типов данных
            if (Type1 != Type2)
            {
                throw new InvalidOperationException("Выводимый и запрашиваемый тип данных не совпадают");
            }
            else
            {
                func.Add(term);
            }
        }

        public void DeleteTerm(IMembershipFunction term) => func.Remove(term);

        public Dictionary<object, List<double>> Graphic()  // Создание массива списков для графика
        {
            var graphicList = new Dictionary<object, List<double>>();
            baseSet.ToFirst();
            while (!baseSet.IsEnd())
            {
                graphicList.Add(baseSet.Extraction(), Fazzification(baseSet.Extraction()));
                baseSet.MoveNext();
            }
            return graphicList;
        }

        public List<double> Fazzification(object elementBaseSet)
        {
            var list = new List<double>();
            foreach (var function in func)
            {
                list.Add(function.MembershipFunction(elementBaseSet));
            }
            return list;
        }

        public string GetResultofFuzzy(List<double> list)
        {
            string result = "";
            var toStringList = new (string, double)[func.Count];
            for (int i = 0; i < list.Count; i++)
            {
                toStringList[i] = (func[i].Name, list[i]);
            }
            toStringList = toStringList.OrderByDescending(x => x.Item2).ToArray();
            double sum = 0;
            foreach (var zeroValue in toStringList)
            {
                sum += zeroValue.Item2;
            }
            if (sum == 0)
            {
                return "Нет соответствия";
            }
            var listofRange = new (string, double[])[8]
            {
                ("Точно", new double[2]{1.01, 1}),
                ("Почти точно", new double[2] { 1, 0.9 }),
                ("Скорее", new double[2] { 0.9, 0.8 }),
                ("Не совсем", new double[2] { 0.8, 0.6 }),
                ("Наполовину", new double[2] { 0.6, 0.4 }),
                ("Немного", new double[2] { 0.4, 0.2 }),
                ("Совсем немного", new double[2] { 0.2, 0.1 }),
                ("Едва ли", new double[2] { 0.1, 0.01 })
            };
            int countTerms = 0;
            foreach (var pair in toStringList)
            {
                foreach (var range in listofRange)
                {
                    if (range.Item2[0] > pair.Item2 && pair.Item2 >= range.Item2[1])
                    {
                        result += $"{range.Item1} {pair.Item1}, ";
                        countTerms++;
                        break;
                    }
                }
            }
            result = result.Remove(result.Length - 2);
            if (countTerms > 1)
            {
                string and = " и ";
                int lastIndex = result.LastIndexOf(',');
                result = result.Remove(lastIndex, 2);
                result = result.Insert(lastIndex, and);
            }
            return result;
        }

        //Расчет свойств нечеткого множества
        public Tuple<double,string,List<object>,List<object>,List<object>> CalculationFuzzySetProperties(IMembershipFunction term, double sectionHeight) {

            if (!heightCache.ContainsKey(term))
            {
                heightCache[term] = CalculateHeight(term);
            }

            if (!typeCache.ContainsKey(term))
            {
                typeCache[term] = CalculateType(term);
            }
          
            if (!areaOfInfluenceCache.ContainsKey(term))
            {
                areaOfInfluenceCache[term] = CalculateAreaOfInfluence(term);
            }
            
            if (!coreCache.ContainsKey(term))
            {
                coreCache[term] = CalculateCore(term);
            }

            List<object> section = CalculateSection(term, sectionHeight);

            return Tuple.Create( heightCache[term], typeCache[term], areaOfInfluenceCache[term], coreCache[term], section);
        }
        private double CalculateHeight(IMembershipFunction term) {
            double maxHeight = 0;
            baseSet.ToFirst();
            while (!baseSet.IsEnd())
            {
                double membershipValue = term.MembershipFunction(baseSet.Extraction());
                if (membershipValue > maxHeight)
                {
                    maxHeight = membershipValue;
                }
                baseSet.MoveNext();
            }
            return maxHeight;
        }

        private string CalculateType(IMembershipFunction term)
        {
            bool allZero = true;
            bool allOne = true;
            baseSet.ToFirst();
            while (!baseSet.IsEnd())
            {
                double membershipValue = term.MembershipFunction(baseSet.Extraction());
                if (membershipValue != 0)
                {
                    allZero = false;
                }
                if (membershipValue != 1)
                {
                    allOne = false;
                }
                baseSet.MoveNext();
            }
            if (allZero)
            {
                return "Пустое";
            }
            else if (allOne)
            {
                return "Универсальное";
            }
            else if (heightCache[term] == 1)
            {
                return "Нормальное";
            }
            else
            {
                return "Субнормальное";
            }
        }

        private List<object> CalculateAreaOfInfluence(IMembershipFunction term)
        {
            var areaOfInfluence = new List<object>();
            baseSet.ToFirst();
            while (!baseSet.IsEnd())
            {
                double membershipValue = term.MembershipFunction(baseSet.Extraction());
                if (membershipValue > 0)
                {
                    areaOfInfluence.Add(baseSet.Extraction());
                }
                baseSet.MoveNext();
            }
            return areaOfInfluence;
        }

        private List<object> CalculateCore(IMembershipFunction term)
        {
            List<object> result = new List<object>();
            baseSet.ToFirst();
            while (!baseSet.IsEnd())
            {
                double membershipValue = term.MembershipFunction(baseSet.Extraction());
                if (membershipValue == 1)
                {
                    result.Add(baseSet.Extraction());
                }
                baseSet.MoveNext();
            }
            return result;
        }
        private List<object> CalculateSection(IMembershipFunction term, double sectionHeight)
        {
            var section = new List<object>();
            baseSet.ToFirst();
            while (!baseSet.IsEnd())
            {
                double membershipValue = term.MembershipFunction(baseSet.Extraction());
                if (membershipValue > sectionHeight)
                {
                    section.Add(baseSet.Extraction());
                }
                baseSet.MoveNext();
            }
            return section;
        }
    }
}

