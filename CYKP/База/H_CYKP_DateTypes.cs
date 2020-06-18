using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYKP
{

    //Сущность таблицы с видами даты
    class H_CYKP_DateTypes
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
   
        public int ModeId { get; set; }

        public virtual ICollection<H_CYKP_Log> Log { get; set; }

        public virtual H_CYKP_TypeMode Mode { get; set; }
              

    }
}
