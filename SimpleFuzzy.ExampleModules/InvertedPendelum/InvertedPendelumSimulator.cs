using SimpleFuzzy.Abstract;

namespace InvertedPendelum
{
    public class InvertedPendelumSimulator : ISimulator
    {
        public bool Active { get ; set; }

        public string Name { get; } = "Inverted Pendelum";

        public List<LinguisticVariableDto> GetLinguisticVariables()
        {
            throw new NotImplementedException();
        }

        public object GetVisualObject()
        {
            throw new NotImplementedException();
        }

        public void SetController(Func<List<object>, List<object>> controller)
        {
            throw new NotImplementedException();
        }
    }
}
