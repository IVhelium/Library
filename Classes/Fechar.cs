using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca.Classes
{
    public class Fechar
    {
        public static void Fechar_Form(Form mainForm, Form newForm)
        {
            newForm.FormClosed += (sender, args) => mainForm.Close();
            newForm.Show();
            mainForm.Hide();
        }
    }
}
