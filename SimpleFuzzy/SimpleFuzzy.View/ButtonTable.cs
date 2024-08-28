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
    public partial class ButtonTable : DataGridView
    {
        List<Button> buttons = new List<Button>();
        public ButtonTable()
        {
            ColumnHeadersHeightChanged += Handler;
            ColumnWidthChanged += Handler;
        }

        public void AddColumn(DataGridViewComboBoxColumn column)
        {
            Columns.Insert(1, column);
            buttons.Insert(0, new Button());
            Controls.Add(buttons[0]);
            buttons[0].Text = "X";
            buttons[0].Click += DeleteColumn;
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Size = new Size(Columns[i + 1].HeaderCell.Size.Width / 4, Columns[i + 1].HeaderCell.Size.Height);
                buttons[i].Location = new Point(GetCellDisplayRectangle(i + 1, 0, false).X, 0);
            }
        }

        private void DeleteColumn(object sender, EventArgs e)
        {
            for (int i = 0; i < buttons.Count; i++ ) 
            {
                if (buttons[i] == sender)
                {
                    Columns.RemoveAt(i + 1);
                    Controls.Remove(buttons[i]);
                    buttons.RemoveAt(i);
                }
            }
        }

        private void Handler(object sender, EventArgs e)
        {
            for (int i = 0; i < buttons.Count; i++) 
            {
                buttons[i].Size = new Size(Columns[i + 1].HeaderCell.Size.Width / 4, Columns[i + 1].HeaderCell.Size.Height);
                buttons[i].Location = new Point(GetCellDisplayRectangle(i + 1, 0, false).X, 0);
            }
        }
    }
}