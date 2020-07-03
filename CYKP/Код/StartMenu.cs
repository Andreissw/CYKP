using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CYKP
{

   public class StartMenu: Menu
    {
        delegate void Method();

        public int _RowIndex { get; set; }

        public StartMenu() : base()
        {
            
        }

        //Определение функции
        public override void RowIndex()
        {
            var list = new List<Method> { Entry, Report, Exit };
            list[Form1.IndexGrid]();
        }

        //Войти в учетную запись
        void Entry()
        {
            var Grid = FindElement("MenuGrid");
            Grid.Visible = false;
            GetElement("GRlogin", 10, 10, 344, 164);
            var TB = FindElement("TBLogin");
            TB.Select();
        }
       
        //Выход
        void Exit()
        {
            Application.Exit();
        }
            

    }
}
