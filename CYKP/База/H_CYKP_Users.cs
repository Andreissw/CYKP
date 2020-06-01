using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYKP
{
    class H_CYKP_Users
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string RFID { get; set; }

        [Required]
        public string UserName { get; set; }
        [Required]
        public int StatusId { get; set; }
     
        public virtual H_CYKP_StatusUser Status { get; set; }

        public virtual ICollection<H_CYKP_Log> Log { get; set; }

      


    }
}
