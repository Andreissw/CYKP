using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYKP
{
    //Таблица с Модулями
    class H_CYKP_NameModule
    {
        public int Id { get; set; }
        [Required]
        public string NameModule { get; set; }
        [MaxLength(6)]
        public string CountModule { get; set; }
        [Required]
        public int ProjectId { get; set; }

        public  virtual H_CYKP_Name_Project Project {get;set;}

        public virtual ICollection<H_CYKP_Log> Log { get; set; }

        public virtual ICollection<H_CYKP_LogDocuments> LogDocument { get; set; }





    }

}
