using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYKP
{
    //Сущность таблицы Лога
    class H_CYKP_Log
    {
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
                     
        [Required]
        public int UserId { get; set; }
        [Required]
        public int StatusProductId { get; set; }
        [Required]
        public int TypeModeid { get; set; }
        [Required]
        public int ClientId { get; set; }
                 
        public int ?ProjectId { get; set; }
       
        public int ?ModuleID { get; set; }

        public int ?DateTypeID { get; set; }
       
        public int LogInfoID { get; set; }

        public virtual H_CYKP_LogInfo LogInfo { get; set; }

        public virtual H_CYKP_Users User { get; set; }
    
        public virtual H_CYKP_StatusProduct StatusProduct { get; set; }
      
        public virtual H_CYKP_TypeMode TypeMode { get; set; }

        public virtual H_CYKP_DateTypes DateType { get; set; }

        public virtual H_CYKP_Name_Client Client { get; set; }
       
        public virtual H_CYKP_Name_Project  Project { get; set; }
   
        public virtual H_CYKP_NameModule Module { get; set; }





    }
}
