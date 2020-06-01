﻿using CYKP.Код;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        class DataItem
        {
            public string Name { get; set; }
        }

        static public int MenuId;
        private void Form1_Load(object sender, EventArgs e)
        {          
            GridInfoClients.Rows.Add(6);
            GridInfoOrders.Rows.Add(4);
            GridInfoModules.Rows.Add(5);
            var grid = new Grid(Menu, ref MenuId, 1);
           
        }
        int Userid;
        private void button1_Click(object sender, EventArgs e) //Логгин
        {
            var Login = new Loggin(TBLogin.Text);

            // Проверка логгина
            if (Login.CheckRFID() == false)
            {
                Login.Clear(TBLogin);
                return;

            } 

            else
            {
                Userid = Login.UserID;
                Login.Identify_login(LBName,Menu,GRlogin);
            }

        }

        //void ListComboBoxStatus(List<ComboBox> CB) //Добавление в массив компобоксы СТАТУСЫ
        //{
        //    CB.Add(ADDStatusContract);
        //    CB.Add(ADDprjStatus);
        //    CB.Add(ADDStatusModule);
        //}

        void ListComboBoxOrder(List<ComboBox> CB) //Добавление в массив компобоксы КЛИЕНТЫ/ЗАКАЗЧИКИ/МОДУЛИ
        {

            CB.Add(ADDCBClentInModule);
            CB.Add(ADDCBOrderinModule);
            CB.Add(ADDCBClientInOrder);
            CB.Add(CBSearchClient);
           
        }
        
        void ListGroupBox(List<GroupBox> GR) //Добавление в массив группбоксы - МЕНЮ
        {            
            GR.AddRange(this.Controls.OfType<GroupBox>());
        }

        int idClient;            
        private void GRIDListClient_CellClick(object sender, DataGridViewCellEventArgs e) //Меню редактирование проектов
        {
            if (e.RowIndex == -1)
                return;
            

            var CB = new CB();
            var QR = CB;
            IComboItemid IComb = QR;

            QR.NameClient = GRIDListClient.CurrentCell.Value.ToString();

            idClient = QR.FindCleintID(); // Поиск ID номера клиента
            var list = QR.GetInfoClient();
            if (list.Count == 0)
                return;


            QR.groupbox = GRAddClient;

            QR.CloseCombo(this, "EdditingGB");
            QR.GRGet(411, 510);// опредление интерфейса добавление/Изменение заказчика

            //ADDFullName.Text = list[0];
            //ADDShrtName.Text = list[1];
            //ADDNumberContract.Text = list[2];
            //ADDStatusContract.Text = list[3];
            //ADDDateStart.Value = Convert.ToDateTime(list[4]);
            //ADDDateContract.Value = Convert.ToDateTime(list[5]);
            //ADDDateContractEnd.Value = Convert.ToDateTime(list[6]);



            IComb.ComboBoxItemOrder(CBSearchOrder); //Добавляет список заказов в компобокс
            GRinEdditingOrder.Visible = true;
            GRinEdditingModule.Visible = false;
            QR.ListOrder(GRIDListOrder); // Добалвяет список заказов в грид 


        }

        int iDorder;
        private void GRIDListOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var CB = new CB();
            var QR = CB;
            var GB = new GroupBoxcs();
            IComboItemid IComb = QR;

           
            QR.NameOrder = GRIDListOrder.CurrentCell.Value.ToString();
            QR.idClient = idClient;

            QR.FindOrderID();
            iDorder = QR.idOrder;

            var list = QR.GetInfoOrder();
            if (list.Count == 0)
                return;
              
            GB.ClearALLGroupBox(this); //Скрывает и чистит все gropbox кроме одного      
            GB.GetGB(EdditingGB);
            GB.GetGB(GRinEdditingOrder);
            QR.groupbox = GRAddOrder;
            QR.GRGet(411, 510);// опредление интерфейса добавление/Изменение заказчика

            ADDCBClientInOrder.Enabled = false;
            ADDCBClientInOrder.Text = GRIDListClient.CurrentCell.Value.ToString();
            ADDTBNameProject.Text = QR.NameOrder;

            ADDTBОбъемЗаказа.Text = list[2];
            ADDDateProject.Value = Convert.ToDateTime(list[3]);
            ADDprjStatus.Text = list[4];
            IComb.ComboBoxItemModule(CBSearchModule);
            GRinEdditingModule.Visible = true;
            QR.ListModule(GRIDListModule);
        }

        private void GRIDListModule_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var CB = new CB();
            var QR = CB;  

            QR.NameModule = GRIDListModule.CurrentCell.Value.ToString();
            QR.idClient = idClient;
            var list = QR.GetInfoModule();
            if (list.Count == 0)
                return;

            QR.groupbox = AddModule;
            CB.CloseCombo(this, "EdditingGB"); //Скрывает и чистит все gropbox кроме одного 
            QR.GRGet(411, 510);// опредление интерфейса добавление/Изменение заказчика

            ADDCBClentInModule.Enabled = false;
            ADDCBOrderinModule.Enabled = false;

            ADDCBClentInModule.Text = GRIDListClient.CurrentCell.Value.ToString();
            ADDCBOrderinModule.Text = GRIDListOrder.CurrentCell.Value.ToString();
            ADDNameModule.Text= GRIDListModule.CurrentCell.Value.ToString();
            ADDCountModule.Text = list[3];
            ADDDateCreate.Value = Convert.ToDateTime(list[4]);
            ADDStatusModule.Text = list[5];




        }

        int rowIndex; //Определяет какой индекс грида был нажат
        private void Menu_CellClick(object sender, DataGridViewCellEventArgs e)
        {       

            switch (MenuId) //Определяет по нажатию на каком этапе меню по id номеру
            {
                case 1:

                    IMenu Menus = new Grid(); //начальное меню
                    Menus.CellClickGrid(this);
                  
                    break;

                case 2:      
                    ISettingMenu STMenu = new Grid(); //Меню редактирования для администратора
                    rowIndex = STMenu.CellClickGrid(this);
                    
                    break;

                case 3:
                    break;
            }
        }

       


        private void BTback_Click_1(object sender, EventArgs e) //Кнопка назать, выход в самое начальное меню
        {
            //var grid = new Grid();

        }
               
    
        
        public void CloseBT() //Метод Закрытие - интерфейс в меню настроек
        {
            var CB = new CB();
            CB.CloseCombo(this);
            CB.CloseCombo(EdditingGB);

        }

        private void button4_Click(object sender, EventArgs e) //Кнопка закрыть  - интерфейс в меню настроек (добавление заказчика)
        {
            CloseBT();
        }

        private void button5_Click(object sender, EventArgs e) //Кнопка закрыть  - интерфейс в меню настроек (добавление заказа)
        {
            CloseBT();
        }

        private void button1_Click_1(object sender, EventArgs e) //Кнопка закрыть  - интерфейс в меню настроек (добавление модуля)

        {
            CloseBT();
        }       
       

        private void button3_Click(object sender, EventArgs e) //Выбор заказчика - Меню редактирование
        {

            if (CBSearchClient.Text == "")
                return;

            var Qu = new QUERY();
            var CB = new CB();

            CB.CloseCombo(this, "EdditingGB"); //Скрывает и чистит все gropbox кроме одного 
            CB.CloseCombo(EdditingGB);

            Qu.ListClients(GRIDListClient, CBSearchClient.Text);// вывод клиентов

        }
              
        private void SerachingOrder_Click(object sender, EventArgs e)//Выбор заказа - Меню редактирование
        {
            if (SerachingOrder.Text == "")
                return;
           
            var CB = new CB();

            CB.idClient = idClient;
            CB.CloseCombo(this, "EdditingGB"); //Скрывает и чистит все gropbox кроме одного 
            CB.CloseCombo(EdditingGB, "GRinEdditingOrder"); //Внутри groupboxa чистит все кроме одного группбокса

            CB.ListOrder(GRIDListOrder, CBSearchOrder.Text);
            
        }

        private void SerachingModule_Click(object sender, EventArgs e)
        {
            if (SerachingOrder.Text == "")
                return;

       
            var CB = new CB();
            CB.idOrder = iDorder;
           
            CB.CloseCombo(this, "EdditingGB");
            CB.ListModule(GRIDListModule, CBSearchModule.Text);
        }

        private void AddClient_Click(object sender, EventArgs e)
        {
            var qu = new QUERY();

            switch (rowIndex)
            {
                case 3:
                    qu.UserID = Userid;
                    qu.NameClient = GRIDListClient.CurrentCell.Value.ToString();
                    qu.FindCleintID();
                    qu.updateClient(GRAddClient);
                    break;

                default:
                    
                    qu.UserID = Userid;
                    qu.addClient(GRAddClient); //функция Добавление в таблицу клиентов и таблицу LOG
                    break;
            }
         
        }
        private void AddOrder_Click(object sender, EventArgs e)
        {
            var qu = new QUERY();

            switch (rowIndex)
            {
                case 3:
                    qu.UserID = Userid;
                    qu.NameOrder = GRIDListOrder.CurrentCell.Value.ToString();
                    qu.FindOrderID();

                    qu.NameClient = GRIDListClient.CurrentCell.Value.ToString();
                    qu.FindCleintID();

                    qu.updateOrder(GRAddOrder);
                    break;

                default:
                    qu.UserID = Userid;
                    qu.addOrder(GRAddOrder);
                    break;
            }

        }

        private void AddBTModule_Click(object sender, EventArgs e)
        {
            var qu = new QUERY();
            switch (rowIndex)
            {
                case 3:
                    qu.UserID = Userid;
                    qu.NameOrder = GRIDListOrder.CurrentCell.Value.ToString();
                    qu.FindOrderID();

                    qu.NameClient = GRIDListClient.CurrentCell.Value.ToString();
                    qu.FindCleintID();

                    qu.NameModule = GRIDListModule.CurrentCell.Value.ToString();
                    qu.FindModuleID();

                    qu.UpdateModule(AddModule);
                    break;

                default:
                    qu.UserID = Userid;
                    qu.addModule(AddModule);
                    break;
            }                      
        }

        int statusid;

        private void StatusContract_DropDown(object sender, EventArgs e)
        {
            var qr = new QUERY();
            qr.FindStatus(ADDStatusContract.Text);
            statusid = qr.statusid;
        }

      
        private void ADDCBOrderinModule_TextChanged(object sender, EventArgs e)
        {
            //var qu = new QUERY();
            //var cb = new CB();
            //IComboItemid icomb = cb;

            //qu.NameClient = ADDCBClentInModule.Text;
            //qu.FindCleintID();

            //icomb.ComboBoxItemOrder(ADDCBOrderinModule);
        }
        

        private void CBFind_TextChanged(object sender, EventArgs e)
        {
            if (CBFind.Text == "")
                return;
            var cb = new CB();
            IComboItem icomb = cb;

            switch (CBFind.Text)
            {
                case ("Заказчик"):
                    cb.ComboBoxItemClient(CBFindName);
                    break;
                case ("Заказ"):
                    icomb.ComboBoxItemOrder(CBFindName);
                    break;
                case ("Модуль"):
                    icomb.ComboBoxItemModule(CBFindName);
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)//Кнопка - Запрос в базу на вывод информации
        {
            if (CBFindName.Text == "")
                return;

            var grid = new Grid();
            grid.Stage = CBFind.Text;
            grid.Name = CBFindName.Text;
            grid.INFO(this);
        }  

        private void ADDCBClentInModule_TextChanged(object sender, EventArgs e)
        {
            if (ADDCBClentInModule.Text == "")
                return;
            else
            {
                var CB = new CB();
                QUERY QU = CB; //upcast
                IComboItemid icomb = CB;
                QU.NameClient = ADDCBClentInModule.Text;
                QU.FindCleintID();//Определяет какие заказы какого заказчика ему открыть в списке                
                icomb.ComboBoxItemOrder(ADDCBOrderinModule);

            }
        }

        private void INFBTOrder_Click(object sender, EventArgs e)
        {           
            InfMethod(INFGridOrders, "Заказ");
        }

        private void INFBTModules_Click(object sender, EventArgs e)
        {
            InfMethod(INFGridModules, "Модуль");
        }

        private void InfMethod(DataGridView grid, string name)
        {
            if (grid.CurrentCell.Selected == false)
                return;
            MethodInfo(name, grid);
            grid.ClearSelection();
        }

        private void MethodInfo(string name, DataGridView Grids)
        {
            var Grid = new Grid();
            Grid.Stage = name;
            CBFindName.Text = "";
            Grid.Name = Grids.CurrentCell.Value.ToString();
            Grid.INFO(this);
        }

        private void INFBTLogorder_Click(object sender, EventArgs e)
        {
            OpenForm();
        }

        void OpenForm()
        {
            var log = new LogForm(GridInfoOrders.Rows[1].Cells[0].Value.ToString());           
            log.ShowDialog();
        }
    }
}