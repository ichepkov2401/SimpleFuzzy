﻿using SimpleFuzzy.SimpleModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleFuzzy.View
{
    public partial class VisualCrane : UserControl
    {
        public CraneSimulator craneSimulator;
        public VisualCrane()
        {
            InitializeComponent();
        }
    }
}
