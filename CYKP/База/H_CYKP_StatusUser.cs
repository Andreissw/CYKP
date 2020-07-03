using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYKP
{
    //Статусы пользователей
    class H_CYKP_StatusUser
    {
        public int Id { get; set; }
        [Required]
        public string Status { get; set; }
  
        public virtual ICollection<H_CYKP_Users> User { get; set; }

        public virtual ICollection<H_CYKP_GridMenu> GridMenus { get; set; }

    }
}
