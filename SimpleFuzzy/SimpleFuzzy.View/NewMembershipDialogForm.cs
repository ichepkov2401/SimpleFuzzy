using SimpleFuzzy.Abstract;
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
    public partial class NewMembershipDialogForm : Form
    {
        IObjectSet ObjectSet { get; set; }
        FuzzyOperation FuzzyOperation { get; set; }
        public NewMembershipDialogForm()
        {
            InitializeComponent();
            GenerationMembershipUI generationMembershipUI = new GenerationMembershipUI();
            generationMembershipUI.Location = new Point(0, 20);
            Controls.Add(generationMembershipUI);
        }

        public NewMembershipDialogForm(IObjectSet objectSet) : this()
        {
            ObjectSet = objectSet;
        }

        public NewMembershipDialogForm(FuzzyOperation fuzzyOperation, IObjectSet objectSet) : this()
        {
            ObjectSet = objectSet;
            FuzzyOperation = fuzzyOperation;
            metroRadioButton2.Checked = true;
        }

        private void metroRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Controls.RemoveAt(Controls.Count - 1);
            if (metroRadioButton1.Checked)
            {
                GenerationMembershipUI generationMembershipUI = new GenerationMembershipUI();
                generationMembershipUI.Location = new Point(15, 40);
                Controls.Add(generationMembershipUI);
            }
            else
            {
                FuzzyOperationUI fuzzy = new FuzzyOperationUI(FuzzyOperation != null ? FuzzyOperation : new Model.FuzzyOperation(), ObjectSet, () => Close() );
                fuzzy.Location = new Point(15, 40);
                Controls.Add(fuzzy);
            }
        }
    }
}
