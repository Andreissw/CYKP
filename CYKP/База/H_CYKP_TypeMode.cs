using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYKP
{
    class H_CYKP_TypeMode
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

       
        public virtual ICollection<H_CYKP_StatusProduct> StatusProduct { get; set; }

        public virtual ICollection<H_CYKP_DateTypes> DateType { get; set; }
     
        public virtual ICollection<H_CYKP_Log> Log { get; set; }

    }
}
