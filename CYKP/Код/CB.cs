using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CYKP.Код
{
    interface IComboItemid
    {       
        void ComboBoxItemOrder(ComboBox CB);
        void ComboBoxItemModule(ComboBox CB);
    }

    interface IComboItem
    {
        void ComboBoxItemOrder(ComboBox CB);
        void ComboBoxItemModule(ComboBox CB);
    }

    class CB : QUERY, IComboItemid, IComboItem
    {
        public GroupBox groupbox;

        int X { get; set; } = 411;
        int Y { get; set; } = 12;

        public CB()
        { }

        public CB(int x, int y)
        {
            X = x;
            Y = y;
        }

      public  void GB(GroupBox GB) //Появление группБокса
        {          
            Clear(GB);
            GB.Visible = true;
            GB.Location = new Point(X, Y);

        }

      
        public void GRGet( int x, int y) //Получение интерфейса
        {
            Clear(groupbox);
            groupbox.Visible = true;
            groupbox.Location = new Point(x, y);
        }

        public void CloseCombo(GroupBox GB, string name ="")
        {
            foreach (Control c in GB.Controls)
            {
                if (c.GetType() == typeof(GroupBox) && c.Name != name)
                {
                    c.Visible = false;

                    foreach (Control b in c.Controls)
                    {
                        if (b.GetType() == typeof(Label)) { }
                        else if (b.GetType() == typeof(Button)) { }
                        else b.Text = "";                             
                        
                    }
                }
            }
        }

        public void CloseCombo(Control parent, string name = "") // Обновление форм и очистка элементов управлений
        {
            foreach (Control item in parent.Controls)
            {     
                if (item.GetType() == typeof(GroupBox) && item.Name != name)
                  item.Visible = false;

                    if (item.GetType() == typeof(GroupBox) && item.Name != name)
                    {
                        foreach (Control c in item.Controls)
                        {
                            if (c.GetType() == typeof(Label)) { }
                            else if (c.GetType() == typeof(Button)) { }
                            else c.Text = "";                           
                        }
                    }
            }

        }
     

      public void Clear(Control GB)
        {
            foreach (Control c in GB.Controls) //Чистит поля в группбоксе
            {
                if (c.GetType() == typeof(Label)) { }
                else if (c.GetType() == typeof(Button)) { }
                else              
                    c.Text = "";           
            }
        }     

        public void ComboBoxItem(int modeId, ComboBox CB) //Выгрузка статусов 
        {
            using (var Connect = new Connect())
            {
                var list = from c in Connect.StatusProducts.Where(c => c.ModeId == modeId) orderby c.Name
                           select new { c.Name };

                CB.DataSource = list.ToList();
                CB.DisplayMember = "Name";
                CB.Text = "";               
            }
           
        }

        public void ComboBoxItemClient(ComboBox CB) //Выгрузка список заказчиков в комббокс
        {
            using (var Connect = new Connect())
            {
                var list = from c in Connect.NameClients.OrderByDescending(c => c.Id)
                           select new { c.Name };

                CB.DataSource = list.ToList();
                CB.DisplayMember = "Name";
                CB.Text = "";
            }
        }
          void IComboItemid.ComboBoxItemOrder(ComboBox CB) //Выгрузка список Заказов в комббокс
        {
            using (var Connect = new Connect())
            {
                var list = from c in Connect.NameProjects.Where(b => b.ClientId == idClient).OrderByDescending(c => c.Id)
                           select new { c.NameProject };

                CB.DataSource = list.ToList();
               
                CB.DisplayMember = "NameProject";
                CB.Text = "";                            
            }
        }

        void IComboItem.ComboBoxItemOrder(ComboBox CB) //Выгрузка список Заказов в комббокс
        {
            using (var Connect = new Connect())
            {
                var list = from c in Connect.NameProjects.OrderByDescending(c => c.Id)
                           select new { c.NameProject };

                CB.DataSource = list.ToList();

                CB.DisplayMember = "NameProject";
                CB.Text = "";
            }
        }

        void IComboItemid.ComboBoxItemModule(ComboBox CB) //Выгрузка список Заказов в комббокс
        {
            using (var Connect = new Connect())
            {
                var list = from c in Connect.NameModules.Where(b => b.ProjectId == idOrder).OrderByDescending(c => c.Id)
                           select new { c.NameModule };
                CB.DataSource = list.ToList();
                CB.DisplayMember = "NameModule";
                CB.Text = "";
            }
        }
         void IComboItem.ComboBoxItemModule(ComboBox CB) //Выгрузка список Заказов в комббокс
        {            
            using (var Connect = new Connect())
            {
                var list = from c in Connect.NameModules.OrderByDescending(c => c.Id)
                           select new { c.NameModule };
                CB.DataSource = list.ToList();
                CB.DisplayMember = "NameModule";
                CB.Text = "";
            }
        }
    }
}
