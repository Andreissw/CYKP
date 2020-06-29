using CYKP.Код;
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
        public Form1()
        {
            InitializeComponent();
            Menus[0].Control = this;

            MenuGrid.CellClick += (a, e) =>
            {
                Menus[0].IndexGrid = MenuGrid.CurrentCell.RowIndex;
                Menus[Menus[0].MenuId - 1].RowIndex();

            };
        }




        public static Menu[] Menus = { new StartMenu(), new AdminMenu(), };


        private void Form1_Load(object sender, EventArgs e)
        {
            MenuGrid.DataSource = Menus[0].ListMenu();
        }

        //private void MenuGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
           
        //}
    }
}
