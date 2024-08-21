using SimpleFuzzy.Abstract;

namespace InvertedPendelum
{
    public class InvertedPendelumSimulator : ISimulator
    {
        public bool Active { get ; set; }

        public string Name { get; }

        public object GetVisualObject()
        {
            throw new NotImplementedException();
        }
    }
}
