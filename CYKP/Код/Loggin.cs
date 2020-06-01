using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace CYKP.Код
{
    class Loggin
    {
        public string Name { get; }
        public string RFID1 { get; }
        public int Status {get;}
        public int UserID { get; }


        public Loggin()
        {

        }
        public Loggin(string RFID)

        {
            using (var connect = new Connect())
            {
                this.Name = connect.Users.Where(c => c.RFID == RFID).Select(c => c.UserName).FirstOrDefault();
                this.RFID1 = connect.Users.Where(c => c.UserName == Name).Select(c => c.RFID).FirstOrDefault();
                this.Status = connect.Users.Where(c => c.RFID == RFID).Select(c => c.StatusId).FirstOrDefault();
                this.UserID = connect.Users.Where(c => c.RFID == RFID).Select(c => c.Id).FirstOrDefault();
            }


        }

        public void Identify_login(Label LB, DataGridView Grid,GroupBox GB)
        {
            switch (Status)
            {
                case 1: //Вход Администратора
                    var grid = new Grid(Grid, ref Form1.MenuId,2);
                    LB.Visible = true;
                    LB.Text = Name;
                    grid.GRSettings(Grid,GB,true,false);
                    
                    break;

            }
            Grid.ClearSelection();
        }

        // Проверка RFID, возвращает значение True или False
        public bool CheckRFID()
        {
            if (this.Name == null)
                return false;
            else
                return true;

        }

        public void Clear (TextBox TB)
        {
            TB.Clear();
            TB.Select();

        }

    }
}
