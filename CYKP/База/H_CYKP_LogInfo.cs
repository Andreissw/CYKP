using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYKP
{
   //Сущность таблицы, дополнительная таблица к Логу
    class H_CYKP_LogInfo
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(300)]
        public string Name { get;set;}

        [MaxLength(50)]
        public string srtName { get; set; }

        [MaxLength(6)]
        public string Count { get; set; }

        public int StatusID { get; set; }

        public DateTime FactDate { get; set; }

        public virtual ICollection<H_CYKP_Log> Logs { get; set; }

    }
}
