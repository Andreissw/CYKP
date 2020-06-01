using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CYKP.Код
{
    class Controls<T>
    {
        //Control control { get; set; }
        public List<T> list { get; set; }

        public Controls(Control control)
        {
           list = controlMethod<T>(control);
        }

        public List<T> controlMethod<T>(Control control)
        {
            return control.Controls.OfType<T>().ToList();
        }        

    }
}
