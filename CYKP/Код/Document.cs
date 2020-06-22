using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CYKP.Код
{
    class Document
    {
        public string PathSave { get; } = @"\\gusev.int\fs\cts\ДСНТ\Отчеты\Служба качества\Отчеты по качеству\Отчет по качеству\CYKPDoc\";

        public int id { get;  set; }

        string PathOpen { get; set; }

        string NameDoc { get; set; }

        string Name { get; set; }

        

        public Document(string name)
        {
            this.Name = name;
        }

       public void OpenDialog()
        {
            using (var OF = new OpenFileDialog()) //Открывает проводник, идет выбор файла
            {
                OF.Filter = "All files (*.*)|*.*";

                OF.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);


                if (OF.ShowDialog() == DialogResult.Cancel)
                    return;
                else
                {
                    PathOpen = OF.FileName;
                    NameDoc = OF.SafeFileName;
                    Save();
                }

            };

        }

        void Save()
        {
            var line = PathSave + NameDoc;
            if (File.Exists(line))
            {
                var mes = MessageBox.Show($"Файл {NameDoc} уже существует, хотите его перезаписать?", "", MessageBoxButtons.YesNo);
                if (mes == DialogResult.No)
                    return;

            }
            File.Copy(PathOpen, line, true);

            if (File.Exists(line))
            {
                var qu = new QUERY(Name);
                //qu.UserID = Userid;
                qu.SaveFile(id, line);
            }
            else
                MessageBox.Show("Произошла ошабика, файл не сохранен");

        }




    }
}
