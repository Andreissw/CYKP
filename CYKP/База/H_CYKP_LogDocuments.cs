using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYKP
{
    class H_CYKP_LogDocuments
    {

        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int UserId { get; set; }
       
        public int? ClientId { get; set; }

        public int? OrderId { get; set; }

        public int? ModuleID { get; set; }

        [Required]
        public int TypeModeid { get; set; }
        
        [Required]
        public int Documentid { get; set; }

        public virtual H_CYKP_Users User{ get; set; }

        public virtual H_CYKP_Name_Client Client { get; set; }

        public virtual H_CYKP_Name_Project Order { get; set; }

        public virtual H_CYKP_NameModule Module { get; set; }

        public virtual H_CYKP_TypeMode TypeMode { get; set; }

        public virtual H_CYKP_Document Document { get; set; }







    }
}
