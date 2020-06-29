using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CYKP.Код
{

    class StartMenu: Menu
    {
        delegate void Method();

        public StartMenu()
        {
            
        }        

        public override void RowIndex()
        {
            var list = new List<Method> { Entry, Report,Exit};
            list[IndexGrid]();
        }

        void Entry()
        {

        }
       

        void Exit()
        {
            Application.Exit();
        }
            

    }
}
