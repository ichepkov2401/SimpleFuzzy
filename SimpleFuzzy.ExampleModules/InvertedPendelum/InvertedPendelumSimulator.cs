﻿using SimpleFuzzy.Abstract;

namespace InvertedPendelum
{
    public class InvertedPendelumSimulator : ISimulator
    {
        public bool Active { get ; set; }

        public string Name { get; } = "Inverted Pendelum";

        public object GetVisualObject()
        {
            throw new NotImplementedException();
        }
    }
}
