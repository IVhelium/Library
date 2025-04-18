using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca.Classes
{
    internal class Verificar
    {
        public bool verifica(string titulo, string autor, string editora, string jenero, string nPaginas, string data)
        {
            bool nPaginasT, result = true;     
            string s = "";

            try
            {
                if (titulo == "") throw new ArgumentException("O livro/revista não pode estar sem titulo");   
                if (nPaginas == "") throw new ArgumentException("O livro/revista não pode estar sem paginas");
                nPaginasT = int.TryParse(nPaginas, out int numPaginas);
                if (!nPaginasT) throw new ArgumentException("So validos valores numericos");
                if (data == "") throw new ArgumentException("O livro/revista não pode estar sem data");

                switch (s)
                {
                    case "Livro":
                        if (autor == "") throw new ArgumentException("O livro não pode estar sem autor");
                        if (jenero == "") throw new ArgumentException("O livro não pode estar sem jenero");
                        break;

                    case "Revista":
                        if (editora == "") throw new ArgumentException("A revista não pode estar sem editora");
                        break;

                    default:
                        break;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO");

                result = false;
            }

            return result;
        }
    }
}
