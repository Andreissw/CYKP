using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CYKP
{
    public class AdminMenu : Menu
    {
        delegate void Method();

        public int _RowIndex { get; set; }

        public AdminMenu() : base()
        {

        }

        public override void RowIndex()
        {
            var list = new List<Method> { AddClient, AddOrder, AddModule, Edit, Report, Document, Back };
            list[Form1.IndexGrid]();
        }

        //Добавить нового заказчика
        void AddClient()
        {
            GetElement("GRAddClient",413, 11, 688, 283);
            StatusGet(1,(ComboBox)FindElement("StatusCBADDContract"));
        }

        //Добавить новый заказ
        void AddOrder()
        {
            GetElement("GRAddOrder", 413, 11, 688, 283);
            //StatusGet(2, (ComboBox)FindElement("StatusCBADDprj"));
        }

        //Добавить новый модуль
        void AddModule()
        {
            GetElement("AddModule", 413, 11, 688, 283);
            //StatusGet(3, (ComboBox)FindElement("StatusCBADDModule"));
        }

        //Редактирование
        void Edit()
        {
            GetElement("EdditingGB", 413, 11, 1100, 465);            
            GetObjListGrid((DataGridView)FindElement("GRIDList1"), (ComboBox)FindElement("CBSearch1"), 1);
        }

        //Документ
        void Document()
        {
            GetElement("GBDoc", 413, 11, 619, 566);
        }
        //Назад
        void Back()
        {
            GetElement("MenuGrid", 14, 11, 393, 350);  Form1.StatusID = 3;
            ((DataGridView)FindElement("MenuGrid")).DataSource = ListMenu();
        }
        
            

    }
}
