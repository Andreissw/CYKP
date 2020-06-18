using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYKP.База
{
    //Сущность таблицы с меню
    class H_CYKP_GridMenu
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public byte row { get; set; }

        [Required]
        public int MenuNameId { get; set; }

        public virtual H_CYKP_GridMenuName MenuName { get; set; }

    }
}
