using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYKP.Код
{
    class AdminMenu : Menu
    {
        delegate void Method();

        public AdminMenu()
        {

        }

        public override void RowIndex()
        {
            var list = new List<Method> { AddClient, AddOrder, AddModule, Edit, Report, Document, Back };
            list[IndexGrid]();
        }

        void AddClient()
        {

        }

        void AddOrder()
        {
            
        }

        void AddModule()
        {

        }

        void Edit()
        {

        }

        void Document()
        {

        }

        void Back()
        {

        }
        
            

    }
}
