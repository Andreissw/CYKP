using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CYKP
{


    public abstract class Menu
    {
        //public int IndexGrid { get; set; }
        //public int MenuID { get; set; } = 1;

        //public int UserID { get; set; }
        //public string UserName { get; set; }
        //public int StatusID { get; set; } = 3;

        public DataGridView Grid = new DataGridView();
        public Control Control { get; set; }

        //IRowIndex RowIndex { get; set; }

        public Menu()
        {


        }
        public abstract void RowIndex(); //Абстрактный метод, определяет кнопку в меню


        //Вызывает интерфейс
        public object ListMenu()
        {
            using (var Connect = new Connect())
            {
                var _list = (from c in Connect.GridMenus.Where(c => c.StatusUserId == Form1.StatusID).OrderBy(b => b.row) select new { c.Name }).ToList();
                Form1.MenuID = Connect.GridMenus.Where(b => b.StatusUserId == Form1.StatusID).Select(c => c.MenuNameId).FirstOrDefault();
                return Grid.DataSource = _list;

            }
        }

        public void Report() //Просмотр Отчета
        {
            GetElement("GROtchet", 411, 12, 881, 489);
        }

        //Настройка интерфейса и вывод
        public void GetElement(string _name, int pointX, int pointY, int SizeX, int SizeY)
        {
            var _element = FindElement(_name);
            Refresh();
            _element.Location = new Point(pointX, pointY);
            _element.Size = new Size(SizeX, SizeY);
            _element.Visible = true;
        }

        //Поиск элемента управления
        public Control FindElement(string _name)
        {
            return Control.Controls.Find(_name, true).FirstOrDefault();
        }


        protected void Refresh() //Обновление
        {
            foreach (GroupBox T in Control.Controls.OfType<GroupBox>())
            {
                T.Visible = false;
                foreach (Control I in T.Controls)
                {
                    if (T.GetType() == typeof(Label)) { }
                    else if (T.GetType() == typeof(Button)) { }
                    else if (I.GetType() == typeof(ComboBox)) { ((ComboBox)I).DataSource = null; }
                    else T.Text = "";
                }

            }
        }

        //Получение данных о пользователе
        public void GetDateUser()
        {
            var RFID = FindElement("TBLogin");
            using (var con = new Connect())
            {
                var list = (from us in con.Users where (us.RFID == RFID.Text) select new { us.Id, us.UserName, us.StatusId }).ToList();
                if (list.ToList().Count == 0) { RFID.Text = ""; RFID.Select(); return; }
                Form1.UserID = list.Select(c => c.Id).FirstOrDefault();
                Form1.UserName = list.Select(c => c.UserName).FirstOrDefault();
                Form1.StatusID = list.Select(c => c.StatusId).FirstOrDefault();
            }
            GetMenu();
        }

        //Получение меню
        void GetMenu()
        {
            GetElement("MenuGrid", 14, 11, 393, 350);
            var _grid = (DataGridView)FindElement("MenuGrid");
            _grid.DataSource = ListMenu();

        }

        protected void StatusGet(int Type, ComboBox CB)
        {
            using (var Connect = new Connect())
            {
                var list = from c in Connect.StatusProducts.Where(c => c.ModeId == Type)
                           orderby c.Name
                           select new { c.Name };

                CB.DataSource = list.ToList();
                CB.DisplayMember = "Name";
                CB.Text = "";
            }
        }


        //Получение списка Заказчиков/Заказов/Модулей в Grid и ComboBox
        delegate object obj();
        public void GetObjListGrid(DataGridView grid, ComboBox CB, int Type)
        {
            using (var Connect = new Connect())
            {
                List<obj> List = new List<obj>() { Client, Order, Module };
                grid.DataSource = List[Type-1].Invoke();
                CB.DataSource = Grid.DataSource;
                CB.DisplayMember = "Имя";                
                CB.Text = "";

                object Client()
                {
                    var list = from a in Connect.NameClients.OrderByDescending(c=>c.Id) select new { Имя = a.Name };
                    return Grid.DataSource = list.ToList();
                }
                object Order()
                {
                    var list = from a in Connect.NameProjects.OrderByDescending(c => c.Id) select new { Имя = a.NameProject };
                    return Grid.DataSource = list.ToList();
                }
                object Module()
                {
                    var list = from a in Connect.NameModules.OrderByDescending(c => c.Id) select new { Имя = a.NameModule };
                    return Grid.DataSource = list.ToList();
                }
            }

        }

        public object GetObj(string _name, int Type)
        {

            using (var Connect = new Connect())
            {
                List<obj> List = new List<obj>() { Client, Order, Module };
                return List[Type - 1].Invoke();

                object Client()
                {
                    var list = from a in Connect.NameClients.OrderByDescending(c => c.Id) where a.Name == _name select new { Имя = a.Name };
                    return Grid.DataSource = list.ToList();
                }
                object Order()
                {
                    var list = from a in Connect.NameProjects.OrderByDescending(c => c.Id) where a.NameProject == _name select new { Имя = a.NameProject };
                    return Grid.DataSource = list.ToList();
                }
                object Module()
                {
                    var list = from a in Connect.NameModules.OrderByDescending(c => c.Id) where a.NameModule == _name select new { Имя = a.NameModule };
                    return Grid.DataSource = list.ToList();
                }
            }

        }
    }
}
