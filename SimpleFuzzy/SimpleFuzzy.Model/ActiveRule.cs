﻿using SimpleFuzzy.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFuzzy.Model
{
    public struct ActiveRule
    {
        public IMembershipFunction function;
        public double values;
    }
}
