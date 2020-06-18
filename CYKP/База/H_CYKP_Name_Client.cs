using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYKP
{
    //Таблица с Заказчиками
    class H_CYKP_Name_Client
    {
        public int Id { get; set; }
        [Required]
      
        public string Name { get; set; }

        public string ShortName { get; set; }

        public string Contract_Num { get; set; }

        public virtual ICollection<H_CYKP_Log> Log { get; set; }

        public virtual ICollection<H_CYKP_LogDocuments> LogDocument { get; set; }

        public virtual ICollection<H_CYKP_Name_Project> NameProject { get; set; }    

    }
}
