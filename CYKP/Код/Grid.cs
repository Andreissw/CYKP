using CYKP.База;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CYKP.Код
{
    

    interface IMenu
    {
        void CellClickGrid(Control control);
        
    }

    interface ISettingMenu
    {
       int  CellClickGrid(Control Parent);
    }

    class Grid : QUERY, IMenu, ISettingMenu
    {
        GroupBox VirtualCB { get; set; }
        Control controls { get; set; }
        QUERY qus { get; set; }
        List<string> list;        
        List<GroupBox> GRBlist { get; set; }
        //public List<T> list { get; set; }
        GroupBoxcs GB { get; set; }
        Controls<GroupBox> ctrl { get; set; }
        public string Stage { get; set; }
        public string Name { get; set; }

        public Grid()
        {

        }
      
        public Grid(DataGridView Grid, ref int Menuid, int id) //Определение грида
        {

            using (var Connect = new Connect())
            {
                var countries = from c in Connect.GridMenus.Where(c => c.MenuNameId == id).OrderBy(b=>b.row)
                                select new { c.Name };

                Grid.DataSource = countries.ToList();

                Menuid = id;
            }
            Grid.ClearSelection();

        }

       public void gridStart(ref int Menuid, Control control)
        {
            var ctrls = new Controls<DataGridView>(control);                      
            var grid = ctrls.list.Where(c => c.Name == "Menu").FirstOrDefault();


            grid.DataSource = null;

            using (var Connect = new Connect())
            {
                var countries = from c in Connect.GridMenus.Where(c => c.MenuNameId == 1)
                                select new { c.Name };
                grid.DataSource = countries.ToList();
            }
            Menuid = 1;

            GRSettings(grid, true, false, control);
        }

      
        //Нажатие на строки в SettingMenu
        int ISettingMenu.CellClickGrid(Control control)
        {
            var Cb = new CB();
            var qu = new QUERY();
            var ctrl = new Controls<DataGridView>(control);
            var ctrlGR = new Controls<GroupBox>(control);
            var ctrlCB = new Controls<ComboBox>(control);
            var GB = new GroupBoxcs(411,12);

            //var GRID = ПоискОбъекта<DataGridView>(control).Where(v => v.Name == "Menu").FirstOrDefault();
            var GRID = ctrl.list.Where(v => v.Name == "Menu").FirstOrDefault();
            var lists = ctrlGR.list;            

            switch (GRID.CurrentCell.RowIndex)
            {
               
                case 0://Добавить заказчика           
                    GB.GroupBox = lists.Where(c => c.Name == "GRAddClient").FirstOrDefault();
                    GB.RefreshGB(control);                   
                    break;

                case 1://Добавить новый заказ

                    GB.GroupBox = lists.Where(c => c.Name == "GRAddOrder").FirstOrDefault();
                    GB.RefreshGB(control);                    
                    var obJ2 = ctrl.controlMethod<ComboBox>(GB.GroupBox).ToList().Where(c => c.Name == "ADDCBClientInOrder").FirstOrDefault();                    
                    obJ2.Enabled = true;
                    Cb.ComboBoxItemClient(obJ2);
                    break;

                case 2://Добавить новый модуль

                    GB.GroupBox = lists.Where(c => c.Name == "AddModule").FirstOrDefault();
                    var CB = ctrlGR.controlMethod<ComboBox>(GB.GroupBox);
                    GB.RefreshGB(control);
                    //VisibleGroup(ref OBJ3, control, Cb);//Вывод меню                                         
                    //Поиск комбобокса в группбоксе                   
                    CB[1].Enabled = true;
                    CB[2].Enabled = true;
                    Cb.ComboBoxItemClient(CB[2]);
                    break;
             

                case 3://Редактировать                    
                    GB.GroupBox = ctrlGR.list.Where(c => c.Name == "EdditingGB").FirstOrDefault();
                    GB.RefreshGB(control);
                    GB.ClearALLGroupBox(GB.GroupBox);
                    var CBobj = ctrlCB.controlMethod<ComboBox>(GB.GroupBox);
                    var gridobj = ctrlCB.controlMethod<DataGridView>(GB.GroupBox);

                    Cb.ComboBoxItemClient(CBobj.Where(c => c.Name == "CBSearchClient").FirstOrDefault());
                    qu.ListClients(gridobj.Where(c => c.Name == "GRIDListClient").FirstOrDefault());
                    break;

                case 4://Посмотреть Отчет
                    Cb.CloseCombo(control);
                    GB.GroupBox = lists.Where(c => c.Name == "GROtchet").FirstOrDefault();
                    GB.ClearALLGroupBox(GB.GroupBox);
                    GB.RefreshGB(control);
                    GB.GroupBox.Size = new Size(881, 489);
                    
                    break;

                case 5://Документы

                    
                    break;

                case 6://Назад
                    gridStart(ref GridListDoc.MenuId, control);
                    GB.ClearALLGroupBox(control);
                    break;
            }

            return GRID.CurrentCell.RowIndex;

        }
        
        void IMenu.CellClickGrid(Control control)// Нажатие на строки Начального меню
        {
            var ctrl = new Controls<DataGridView>(control);
            var ctrlGB = new Controls<GroupBox>(control);
            var GRID = ctrl.list.Where(v => v.Name == "Menu").FirstOrDefault();
            var Cb = new CB();
            var GB = new GroupBoxcs(5,11);

            switch (GRID.CurrentCell.RowIndex) //Определяет какой метод выполнить 
            {
                case 0: //Логин
                    GRSettings(GRID, false, true, control);
                    GB.GroupBox = ctrlGB.list.Where(c => c.Name == "GRlogin").FirstOrDefault();
                    GB.ClearALLGroupBox(control);
                    GB.RefreshGB(GB.GroupBox);
                    
                    break;

                case 1://Посмотреть отчет
                    Cb.CloseCombo(control);
                    GB.GroupBox = ctrlGB.list.Where(c => c.Name == "GROtchet").FirstOrDefault();
                    GB.Points(411, 12);
                    GB.RefreshGB(control);
                    GB.ClearALLGroupBox(GB.GroupBox);
                    GB.GroupBox.Size = new Size(881, 489);
                    break;

                case 2://Выход
                    Application.Exit();
                    break;
            }

        }

        public void INFO(Control control)
        {
            GB = new GroupBoxcs(9,40);                              
            ctrl = new Controls<GroupBox>(control);

            GB.GroupBox = ctrl.list.Where(c => c.Name == "GROtchet").FirstOrDefault();
            GB.ClearALLGroupBox(GB.GroupBox);
            
            GRBlist = ctrl.controlMethod<GroupBox>(GB.GroupBox);                      
            
            switch (Stage)
            {
                case ("Заказчик"):
                    InClient();
                    break;
                case ("Заказ"):
                    InfOrder();
                    break;
                case ("Модуль"):
                    INFModule();
                    break;
            }
           
        }

         void InClient()
        {
            Definitions("GRINFOClient");
            NameClient = Name;
            FindCleintID();
            list = GetInfoClient();
            ListOrder(Definitions2("GridInfoClients", "INFGridOrders"));
        }

         void InfOrder()
        {
            Definitions("GRINFOorder");
            NameOrder = Name;
            FindOrderID();
            list = GetInfoOrder();
            ListModule(Definitions2("GridInfoOrders", "INFGridModules"));
        }

         void INFModule()
        {
            Definitions("GRINFOModule");
            NameModule = Name;
            FindModuleID();
            list = GetInfoModule();
            Definitions2("GridInfoModules", "INFGridModules");            
        }

       void Definitions(string nameGB)
        {
            GB.GroupBox = GRBlist.Where(c => c.Name == nameGB).FirstOrDefault();
            GB.RefreshGB(GB.GroupBox);
           
        }

        DataGridView Definitions2(string nameGR, string Name)
        {
            var gridlist = ctrl.controlMethod<DataGridView>(GB.GroupBox);
            var Grid = gridlist.Where(c => c.Name == nameGR).FirstOrDefault();
            for (int i = 0; i < list.Count(); i++)
                Grid.Rows[i].Cells[0].Value = list[i];
            var Gridord = gridlist.Where(c => c.Name == Name).FirstOrDefault();
            return Gridord;
        }


        //настройка меню и группбокса
        public void GRSettings(DataGridView Grid, bool bl1,bool bl2,Control control) 
        {
            var ctrlGB = new Controls<GroupBox>(control);
            var ctrlLB = new Controls<Label>(control);         


            var GR = ctrlGB.list.Where(c => c.Name == "GRlogin").FirstOrDefault();
            var ctrl = new Controls<TextBox>(GR);

            var TB = ctrl.list.Where(c => c.Name == "TBLogin").FirstOrDefault();
            var LB = ctrlLB.list.Where(c => c.Name == "LBName").FirstOrDefault();

            TB.Clear();
            Grid.Visible = bl1;
            GR.Visible = bl2;
            LB.Visible = false;
            LB.Text = "Unknown";
            TB.Select();

        }
        //настройка меню и группбокса
        public void GRSettings(DataGridView Grid, GroupBox GR,  bool bl1, bool bl2)
        {
            Grid.Visible = bl1;
            GR.Visible = bl2;         
         
        }
        //настройка меню и группбокса
        public void GRSettings(GroupBox GB, bool bl)
        {
            GB.Visible = bl;
         
        }
    }
}
