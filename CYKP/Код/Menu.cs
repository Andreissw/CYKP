using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CYKP
{
    public abstract class Menu
    {

        public int IndexGrid { get; set; }
        public int UserID { get; set; }
        public int MenuId { get; set; } = 1;
        public DataGridView Grid = new DataGridView();
        public Control Control { get; set; }

        public abstract void RowIndex(); //Абстрактный метод, определяет кнопку в меню

       
        public object ListMenu()
        {
            using (var Connect = new Connect())
            {
                var _list = (from c in Connect.GridMenus.Where(c => c.MenuNameId == MenuId).OrderBy(b => b.row) select new { c.Name }).ToList();
                return  Grid.DataSource = _list;                           

            }
        }

        public void Report() //Просмотр Отчета
        {
            GetElement("GROtchet", 411, 12, 881, 489);
        }


        protected void GetElement(string _name, int pointX, int pointY, int SizeX, int SizeY)
        {
            var _element = FindGB(_name);
            Refresh();           
            _element.Location = new Point(pointX,  pointY);
            _element.Size = new Size(SizeX , SizeY);
            _element.Visible = true;
        }

        Control FindGB(string _name)
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
                    else T.Text = "";
                }

            }
        }

        



       
  
        





    }
}
