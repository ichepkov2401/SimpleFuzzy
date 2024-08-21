using SimpleFuzzy.Abstract;

namespace SimpleFuzzy.SimpleModule
{
    public class MembershipFunc : IMembershipFunction
    {
        public bool Active { get; set; }
        public string Name { get; private set; }
        private readonly double a, b, c, d;
        public Type InputType => typeof(double);
        public MembershipFunc(string name, double a, double b, double c, double d)
        {
            Name = name;
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
        }

        public double MembershipFunction(object elem)
        {
            if (elem == null)
            {
                throw new ArgumentNullException(nameof(elem));
            }

            double doubleElem;
            try
            {
                doubleElem = Convert.ToDouble(elem);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Unable to convert input to double", nameof(elem), ex);
            }

            double result;
            if (doubleElem <= a || doubleElem >= d)
            {
                result = 0;
            }
            else if (doubleElem > a && doubleElem <= b)
            {
                result = (doubleElem - a) / (b - a);
            }
            else if (doubleElem > b && doubleElem < c)
            {
                result = 1;
            }
            else // doubleElem >= c && doubleElem < d
            {
                result = (d - doubleElem) / (d - c);
            }

            return Math.Max(0, Math.Min(1, result));

        }
    }
}