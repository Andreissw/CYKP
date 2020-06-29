using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CYKP.Код
{
    class GroupBoxcs
    {
        public GroupBox GroupBox { get; set; }
        private int X { get; set; }
        private int Y { get; set; }


        public GroupBoxcs()
        {

        }

        public GroupBoxcs(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Points(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void ClearALLGroupBox(Control controls)
        {
            var CONTROL = new Controls<GroupBox>(controls);
            foreach (var c in CONTROL.list)
                c.Visible = false;
        }

        public void ClearText(Control controls)
        {
            var CONTROL = new Controls<Control>(controls);
            foreach (var c in CONTROL.list)
                if (c.GetType() == typeof(Button))  {  }
                else if (c.GetType() == typeof(Label)) { }
                else  c.Text = "";
        }

        public void ClearGrid(Control controls)
        {
            var CONTROL = new Controls<DataGridView>(controls);
            foreach (DataGridView c in CONTROL.list)
                c.Rows.Clear();

        }

        public int CheckControls(Control control)
        {
            foreach (Control item in control.Controls)
                if (item.Text == "" & item.GetType() != typeof(Button))
                {
                    item.Select();
                    return 0;
                }
            return 1;

        }

     

        public void GetGB (Control GB)
        {            
            GB.Visible = true;
        }

        public void LocationGB(Control GB)
        {
            GB.Location = new Point(X, Y);
        }

        public void Size(Control GB)
        {
            GB.Size = new Size(694, 295);
        }

        public void RefreshGB(Control controls)
        {
            ClearALLGroupBox(controls);
            ClearText(GroupBox);
            GetGB(GroupBox);
            LocationGB(GroupBox);
            Size(GroupBox);

        }

        
    }
}
