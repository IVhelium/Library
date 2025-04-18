using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Classes
{
    public static class conf
    {
        public static string versao = "1.0";

        public static string User { get; set; }

        public static void configurar()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GestaoBiblioteca\";
            string pathReq = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GestaoBiblioteca\Requisicoes\";
            string pathComp = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GestaoBiblioteca\Compras\";
            string pathImp = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GestaoBiblioteca\Imprimir\";

            string file = "Livros.txt";
            string file2 = "Revistas.txt";
            string file3 = "reqLivros.txt";
            string file4 = "reqRevistas.txt";
            string file5 = "compLivros.txt";
            string file6 = "compRevistas.txt";
            string file7 = "impLivro.txt";
            string file8 = "impRevista.txt";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (!Directory.Exists(pathComp))
            {
                Directory.CreateDirectory(pathComp);
            }
            if (!Directory.Exists(pathImp))
            {
                Directory.CreateDirectory(pathImp);
            }
            if (!Directory.Exists(pathReq))
            {
                Directory.CreateDirectory(pathReq);
            }


            if (!File.Exists(path + file))
            {
                File.Create(path + file);
            }
            if (!File.Exists(path + file2))
            {
                File.Create(path + file2);
            }
            if (!File.Exists(path + file3))
            {
                File.Create(path + file3);
            }
            if (!File.Exists(path + file4))
            {
                File.Create(path + file4);
            }
            if (!File.Exists(path + file5))
            {
                File.Create(path + file5);
            }
            if (!File.Exists(path + file6))
            {
                File.Create(path + file6);
            }
            if (!File.Exists(pathImp + file7))
            {
                File.Create(pathImp + file7);
            }
            if (!File.Exists(pathImp + file8))
            {
                File.Create(pathImp + file8);
            }
        }
    }
}
