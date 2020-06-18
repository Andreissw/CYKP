using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYKP
{
    class H_CYKP_Document
    {
        public int Id { get; set; }

        public string NamePath { get; set; }

        public virtual ICollection<H_CYKP_LogDocuments> LogDocument { get; set; }

    }
}
