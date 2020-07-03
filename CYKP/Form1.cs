using CYKP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CYKP
{
    public partial class Form1 : Form
    {

        public static int IndexGrid { get; set; }
        public static int MenuID { get; set; } = 1;
        
        public static int UserID { get; set; }
        public static string UserName { get; set; }
        public static int StatusID { get; set; } = 3;

        Button _bt = new Button(); ComboBox _cb = new ComboBox(); DataGridView _grid = new DataGridView(); GroupBox _gb = new GroupBox();

        public Menu[] Menu = { new StartMenu(), new AdminMenu(), };

        public Form1()
        {
            InitializeComponent();

            //Событие загрузки формы
            this.Load += (a, e) => { MenuGrid.DataSource = Menu[0].ListMenu(); };

            //Передача параметров Control в классы
            foreach (Menu i in Menu)
                i.Control = this;

            ////Обработчик нажатие на строки в GridMenu
            MenuGrid.CellClick += (a, e) =>
            {
                IndexGrid = MenuGrid.CurrentRow.Index;
                Menu[MenuID - 1].RowIndex();
            };

            //Обработчик Логина
            Log();

            //Обработчик Интерфейса Редактирования
            Edit();        

            //Назад
            BTback.Click += (a, e) => { Menu[0].GetElement("MenuGrid", 14, 11, 393, 350); TBLogin.Clear(); };            
        }

        void Log()
        {
            //Обработчик Логина
            BTlogin.Click += (a, e) => { Menu[0].GetDateUser(); TBLogin.Clear(); };
            TBLogin.KeyDown += (a, e) => { if (e.KeyCode == Keys.Enter) { Menu[0].GetDateUser(); TBLogin.Clear(); } };
        }

        //Меню редактирования
        void Edit()
        {
            //Кнопка поиска объекта
            for (int i = 1; i < 4; i++)
            {               
                _bt = (Button)Menu[0].FindElement($"Searching{i}"); _cb = ((ComboBox)Menu[0].FindElement($"CBSearch{i}")); _grid = ((DataGridView)Menu[0].FindElement($"GRIDList{i}"));
                _bt.Click += (a, e) =>  {var lenght = _cb.Name.Length - 1; var k = Convert.ToInt32(_cb.Name.Substring(lenght,1));
                    if (_cb.Text == "") {  return;  } _grid.DataSource = Menu[0].GetObj(_cb.Text,k);};
            }

            //Нажатие на грид
            for (int i = 1; i < 3; i++)
            {
                _grid = ((DataGridView)Menu[0].FindElement($"GRIDList{i}")); _gb = ((GroupBox)Menu[0].FindElement($"GroupEddit{i}"));
                _grid.CellClick += (a, e) => { if (e.RowIndex == -1) { return; }

                };
            }



        }





    }
}
