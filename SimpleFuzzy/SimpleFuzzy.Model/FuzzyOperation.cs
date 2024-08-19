using SimpleFuzzy.Abstract;

namespace SimpleFuzzy.Model
{
    public class FuzzyOperation : IMembershipFunction
    {
        public IMembershipFunction Operand1 { get; set; }
        public IMembershipFunction Operand2 { get; set; }
        public string Func { get; set; }
        public static Dictionary<string, (bool, Func<IMembershipFunction, IMembershipFunction, object, double>)> operations = new Dictionary<string, (bool, Func<IMembershipFunction, IMembershipFunction, object, double>)>()
        {
            // Унарные операции
            {"Нечеткое дополнение", (true, (x, y, z) => 1 - x.MembershipFunction(z))},
            // Бинарные операции
            {"Нечеткое пересечение", (false, (x, y, z) => Math.Min(x.MembershipFunction(z), y.MembershipFunction(z)))}
        };

        public Type InputType => Operand1.InputType;

        public bool Active { get => true; set => throw new NotImplementedException(); }

        public string Name { get; set; } = "";

        public double MembershipFunction(object elem) => operations[Func].Item2(Operand1, Operand2, elem);
    }
}
