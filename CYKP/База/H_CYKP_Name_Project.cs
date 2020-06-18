using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYKP
{
    //Таблица с Заказами
    class H_CYKP_Name_Project
    {
        public H_CYKP_Name_Project()
        {
            this.NameModule = new HashSet<H_CYKP_NameModule>();
            this.Log = new HashSet<H_CYKP_Log>();
        }

        public int Id { get; set; }
        [Required]
        public string NameProject { get; set; }
        [MaxLength(6)]
        public string Count { get; set; }

        [Required]
        public int ClientId { get; set; }
        public virtual H_CYKP_Name_Client Client { get; set; }
  
        public virtual ICollection<H_CYKP_NameModule> NameModule { get; set; }
    
        public virtual ICollection<H_CYKP_Log> Log { get; set; }

        public virtual ICollection<H_CYKP_LogDocuments> LogDocument { get; set; }



    }
}
