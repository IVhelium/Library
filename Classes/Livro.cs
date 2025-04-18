using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca.Classes
{
    public class Livro : Info
    {
        public Livro(string aut, string titul, string gener, int nPag, DateTime dat, float prec)
        {
            Titulo = titul;
            Genero = gener;
            Autor = aut;
            Paginas = nPag;
            Data = dat;
            Id = Guid.NewGuid().ToString("N").Substring(0, 16);
            Preco = prec;
        }

        public void inserirLivro()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GestaoBiblioteca\";
            string file = "Livros.txt";

            StreamWriter inser = new StreamWriter(path + file, true, Encoding.UTF8);

            inser.WriteLine(Autor);
            inser.WriteLine(Titulo);
            inser.WriteLine(Genero);
            inser.WriteLine(Paginas);
            inser.WriteLine(Data);
            inser.WriteLine(Id);
            inser.WriteLine(Preco);
            inser.Close();
        }

        public void comprarLivro()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GestaoBiblioteca\";
            string file = "compLivros.txt";

            StreamWriter inser = new StreamWriter(path + file, true, Encoding.UTF8);

            inser.WriteLine(Autor);
            inser.WriteLine(Titulo);
            inser.WriteLine(Genero);
            inser.WriteLine(Paginas);
            inser.WriteLine(Data);
            inser.WriteLine(Id);
            inser.WriteLine(Preco);
            inser.Close();
        }

        public override void infDoc()
        {
            MessageBox.Show("Autor: " + Autor + "\nTitulo: " + Titulo + "\nGenero: " + Genero + "\nNº Paginas: " + Paginas + "\nData: " + Data + "\nID: " + Id + "\nPreço: " + Preco.ToString("F2") + " €");
        }
    }
}
