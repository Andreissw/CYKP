using CYKP.Код;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CYKP
{
    public partial class LogForm : Form
    {
        public LogForm(string name)
        {
            InitializeComponent();
            Name = name;
        }

        string Name { get; set; }
        

        private void LogForm_Load(object sender, EventArgs e)
        {
            var qu = new QUERY();
            qu.Grid = GridLog;
            qu.NameOrder = Name;
            qu.FindOrderID();
            qu.getLogOrder();
        }

        private void button5_Click(object sender, EventArgs e)
        {
         this.Close();
        }
    }
}
