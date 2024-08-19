using SimpleFuzzy.Abstract;

namespace SimpleFuzzy.Model
{
    public class LinguisticVariable
    {
        public string name; // Имя лингвистической переменной
        public bool isInput; // входная или выходная переменная
        public IObjectSet baseSet; // Базовое множество
        public List<IMembershipFunction> func = new List<IMembershipFunction>(); // Список термов
        public readonly bool isRedact; // Возможность редактирования
        public double? height; // Высота нечеткого множества
        public string type; // Тип нечеткого множества
        public List<object> areaOfInfluence; // Область влияния
        public object core; // Ядро нечеткого множества
        public List<object> section; // Сечение нечеткого множества
        private Dictionary<IMembershipFunction, double> heightCache = new Dictionary<IMembershipFunction, double>();
        private Dictionary<IMembershipFunction, string> typeCache = new Dictionary<IMembershipFunction, string>();
        private Dictionary<IMembershipFunction, List<object>> areaOfInfluenceCache = new Dictionary<IMembershipFunction, List<object>>();
        private Dictionary<IMembershipFunction, object> coreCache = new Dictionary<IMembershipFunction, object>();

        public LinguisticVariable(bool isRedact)
        {
            this.isRedact = isRedact;
        }

        public string Name
        {
            get { return name; }
            set { if (isRedact == true) { name = value; } }
        }

        public bool IsInput
        {
            get { return isInput; }
            set { if (isRedact == true) { isInput = value; } }
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
                ("Почти точно", new double[2] { 0.99, 0.9 }),
                ("Скорее", new double[2] { 0.89, 0.8 }),
                ("Не совсем", new double[2] { 0.79, 0.6 }),
                ("Наполовину", new double[2] { 0.59, 0.4 }),
                ("Немного", new double[2] { 0.39, 0.2 }),
                ("Совсем немного", new double[2] { 0.19, 0.1 }),
                ("Едва ли", new double[2] { 0.09, 0.01 })
            };
            int countTerms = 0;
            foreach (var range in listofRange)
            {
                foreach (var pair in toStringList)
                {
                    if (range.Item2[0] >= pair.Item2 && pair.Item2 >= range.Item2[1])
                    {
                        result += $"{range.Item1} {pair.Item1}, ";
                        countTerms++;
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
        public void CalculationFuzzySetProperties(IMembershipFunction term,IObjectSet set, double sectionHeight) {

            if (!heightCache.ContainsKey(term))
            {
                heightCache[term] = CalculateHeight(term, set);
            }
            height = heightCache[term];

            if (!typeCache.ContainsKey(term))
            {
                typeCache[term] = CalculateType(term, set);
            }
            type = typeCache[term];

            if (!areaOfInfluenceCache.ContainsKey(term))
            {
                areaOfInfluenceCache[term] = CalculateAreaOfInfluence(term, set);
            }
            areaOfInfluence = areaOfInfluenceCache[term];

            if (!coreCache.ContainsKey(term))
            {
                coreCache[term] = CalculateCore(term, set);
            }
            core = coreCache[term];


            section = CalculateSection(term, sectionHeight, set);
        }
        private double CalculateHeight(IMembershipFunction term, IObjectSet set) {
            double maxHeight = 0;
            set.ToFirst();
            while (!set.IsEnd())
            {
                double membershipValue = term.MembershipFunction(set.Extraction());
                if (membershipValue > maxHeight)
                {
                    maxHeight = membershipValue;
                }
                set.MoveNext();
            }
            return maxHeight;
        }

        private string CalculateType(IMembershipFunction term, IObjectSet set)
        {
            if (height == 1)
            {
                return "Нормальное";
            }
            else
            {
                bool allZero = true;
                bool allOne = true;
                set.ToFirst();
                while (!set.IsEnd())
                {
                    double membershipValue = term.MembershipFunction(set.Extraction());
                    if (membershipValue != 0)
                    {
                        allZero = false;
                    }
                    if (membershipValue != 1)
                    {
                        allOne = false;
                    }
                    set.MoveNext();
                }
                if (allZero)
                {
                    return "Пустое";
                }
                else if (allOne)
                {
                    return "Универсальное";
                }
                else
                {
                    return "Субнормальное";
                }
            }
        }

        private List<object> CalculateAreaOfInfluence(IMembershipFunction term, IObjectSet set)
        {
            var areaOfInfluence = new List<object>();
            set.ToFirst();
            while (!set.IsEnd())
            {
                double membershipValue = term.MembershipFunction(set.Extraction());
                if (membershipValue > 0)
                {
                    areaOfInfluence.Add(set.Extraction());
                }
                set.MoveNext();
            }
            return areaOfInfluence;
        }

        private object CalculateCore(IMembershipFunction term, IObjectSet set)
        {
            set.ToFirst();
            while (!set.IsEnd())
            {
                double membershipValue = term.MembershipFunction(set.Extraction());
                if (membershipValue == 1)
                {
                    return set.Extraction();
                }
                set.MoveNext();
            }
            return null; // Отсутствие ядра
        }
        private List<object> CalculateSection(IMembershipFunction term, double sectionHeight, IObjectSet set)
        {
            var section = new List<object>();
            set.ToFirst();
            while (!set.IsEnd())
            {
                double membershipValue = term.MembershipFunction(set.Extraction());
                if (membershipValue > sectionHeight)
                {
                    section.Add(set.Extraction());
                }
                set.MoveNext();
            }
            return section;
        }
    }
}

