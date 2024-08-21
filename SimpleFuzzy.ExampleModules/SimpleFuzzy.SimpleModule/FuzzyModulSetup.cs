namespace SimpleFuzzy.SimpleModule
{
    public class FuzzyModuleSetup
    {
        public List<MembershipFunc> WeightMembershipFunctions { get; private set; }
        public List<MembershipFunc> CalorieMembershipFunctions { get; private set; }

        public ObjectSet WeightSet { get; private set; }
        public ObjectSet CalorieSet { get; private set; }

        public FuzzyModuleSetup()
        {
            // Инициализация базовых множеств
            WeightSet = new ObjectSet("Weight set", 40.0, 130.0, 0.1);
            CalorieSet = new ObjectSet("Calorie set", 500, 5000, 1);

            // Инициализация функций принадлежности для веса
            WeightMembershipFunctions = new List<MembershipFunc>
            {
                new MembershipFunc("Недостаточный вес", 40, 40, 45, 50),
                new MembershipFunc("Нормальный вес", 45, 50, 70, 75),
                new MembershipFunc("Избыточный вес", 70, 75, 85, 90),
                new MembershipFunc("Ожирение 1 степени", 85, 90, 95, 100),
                new MembershipFunc("Ожирение 2 степени", 95, 100, 110, 115),
                new MembershipFunc("Ожирение 3 степени", 110, 115, 130, 130)
            };

            // Инициализация функций принадлежности для потребления калорий
            CalorieMembershipFunctions = new List<MembershipFunc>
            {
                new MembershipFunc("Очень мало калорий", 500, 500, 800, 1000),
                new MembershipFunc("Мало калорий", 800, 1000, 1800, 2000),
                new MembershipFunc("Средне калорий", 1800, 2000, 2800, 3000),
                new MembershipFunc("Много калорий", 2800, 3000, 3800, 4000),
                new MembershipFunc("Очень много калорий", 3800, 4000, 5000, 5000)
            };
        }
    }
}