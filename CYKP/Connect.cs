using CYKP.База;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYKP
{
    class Connect : DbContext
    {
        public Connect() : base("RealBase")
        {

        }

        public DbSet<H_CYKP_LogInfo> LogInfos { get; set; }

        public DbSet<H_CYKP_DateTypes> DateTypes { get; set; }

        public DbSet<H_CYKP_Log> Logs { get; set; }

        public DbSet<H_CYKP_NameModule> NameModules  { get; set; }

        public DbSet<H_CYKP_Name_Client> NameClients { get; set; }

        public DbSet<H_CYKP_Name_Project> NameProjects  { get; set; }

        public DbSet<H_CYKP_StatusProduct> StatusProducts  { get; set; }

        public DbSet<H_CYKP_StatusUser>  StatusUsers { get; set; }

        public DbSet<H_CYKP_TypeMode>  TypeModes { get; set; }

        public DbSet<H_CYKP_Users> Users { get; set; }

        public DbSet<H_CYKP_GridMenu> GridMenus { get; set; }

        public DbSet<H_CYKP_GridMenuName> GridMenuNames { get; set; }

      


    }
}
