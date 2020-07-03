using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYKP
{
    //Сущность таблицы типов меню
    class H_CYKP_GridMenuName
    {

        public int Id { get; set; }
        [Required]
        public string Name { get;set;}

        public virtual ICollection<H_CYKP_GridMenu> GridMenus { get; set; }

    }
}
