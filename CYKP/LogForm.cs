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
    interface Iorder
    {

    }
    public partial class LogForm : Form
    {
        public LogForm(string name)
        {
            InitializeComponent();
            Name = name;
            
        }

        public int id { get; set; }
        QUERY qu { get; set; }
        delegate void Meth();

        private void LogForm_Load(object sender, EventArgs e)
        {
            LogMethod();
        }


        private void LogMethod()
        {
            //var qu = new QUERY();
            qu = new QUERY();
            qu.Grid = GridLog;
            var list = new List<Meth>() { ClientLog, OrderLog,ModuleLog};
            list[id]();


        }

        void ClientLog()
        {
            qu.NameClient = Name;
            qu.FindCleintID();
            qu.getLogClient();
        }

        void OrderLog()
        {          
            qu.NameOrder = Name;
            qu.FindOrderID();
            qu.getLogOrder();
        }

        void ModuleLog()
        {
            
            qu.NameModule = Name;
            qu.FindModuleID();
           qu.getLogModule();


        }        

        private void button5_Click(object sender, EventArgs e)
        {
         this.Close();
        }
    }
}
