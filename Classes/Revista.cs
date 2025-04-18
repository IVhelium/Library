using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca.Classes
{
    public class Revista : Info
    {
        public Revista(string edit, string titul, int nPag, DateTime dat, float prec) 
        {
            Titulo = titul;
            Editora = edit;
            Paginas = nPag;
            Data = dat;
            Id = Guid.NewGuid().ToString("N").Substring(0, 16);
            Preco = prec;
        }

        public void inserirRevista()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GestaoBiblioteca\";
            string file = "Revistas.txt";

            StreamWriter inser = new StreamWriter(path + file, true, Encoding.UTF8);

            inser.WriteLine(Editora);
            inser.WriteLine(Titulo);
            inser.WriteLine(Paginas);
            inser.WriteLine(Data);
            inser.WriteLine(Id);
            inser.WriteLine(Preco);
            inser.Close();
        }
        
        public void comprarRevista()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GestaoBiblioteca\";
            string file = "compRevistas.txt";

            StreamWriter inser = new StreamWriter(path + file, true, Encoding.UTF8);

            inser.WriteLine(Editora);
            inser.WriteLine(Titulo);
            inser.WriteLine(Paginas);
            inser.WriteLine(Data);
            inser.WriteLine(Id);
            inser.WriteLine(Preco);
            inser.Close();
        }

        public override void infDoc()
        {
            MessageBox.Show("Editora: " + Editora + "\nTitulo: " + Titulo + "\nNº Paginas: " + Paginas + "\nData: " + Data + "\nID: " + Id + "\nPreço: " + Preco.ToString("F2") + " €");
        }
    }
}
