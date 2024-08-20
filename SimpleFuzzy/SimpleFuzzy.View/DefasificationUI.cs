﻿using OxyPlot.Series;
using OxyPlot.WindowsForms;
using OxyPlot;
using SimpleFuzzy.Model;
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
    public partial class DefasificationUI : UserControl
    {
        private LinguisticVariable linguisticVariable;
        public DefasificationUI()
        {
            InitializeComponent();
        }
        public DefasificationUI(LinguisticVariable linguisticVariable)
        {
            this.linguisticVariable = linguisticVariable;
            InitializeComponent();
            Graphic.Text = linguisticVariable.Name + "    График будет тут!";
        }
    }
}
