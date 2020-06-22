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
            qu = new QUERY(Name);
            qu.Grid = GridLog;
            qu.FindClientID();
            var list = new List<Meth>() { ClientLog, OrderLog,ModuleLog};
            list[id]();

        }

        void ClientLog()
        {
            
            qu.getLogClient();
        }

        void OrderLog()
        {          
           
            qu.getLogOrder();
        }

        void ModuleLog()
        {
                       
           qu.getLogModule();


        }        

        private void button5_Click(object sender, EventArgs e)
        {
         this.Close();
        }
    }
}
