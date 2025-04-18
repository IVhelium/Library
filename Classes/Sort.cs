using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca.Classes
{
    public class Sort
    {
        public List<Livro> sortLivro(List<Livro> livro, string s)
        {
            try
            {
                if (livro == null || !livro.Any())
                {
                    throw new ArgumentException("Список книг пуст или равен null");
                }
            }
            catch (ArgumentException erro)
            {
                MessageBox.Show(erro.Message, "ERRO");
            }

            var sorliv = livro.AsQueryable();

            switch (s)
            {
                case "A: A - Z":
                    sorliv = sorliv.OrderBy(b => b.Autor);
                    break;

                case "A: Z - A":
                    sorliv = sorliv.OrderByDescending(b => b.Autor);
                    break;

                case "T: A - Z": 
                    sorliv = sorliv.OrderBy(b => b.Titulo);
                    break;

                case "T: Z - A":
                    sorliv = sorliv.OrderByDescending(b => b.Titulo);
                    break;

                case "G: A - Z":
                    sorliv = sorliv.OrderBy(b => b.Genero);
                    break;

                case "G: Z - A":
                    sorliv = sorliv.OrderByDescending(b => b.Genero);
                    break;

                case "P: 1 - 10":
                    sorliv = sorliv.OrderBy(b => b.Paginas);
                    break;

                case "P: 10 - 1":
                    sorliv = sorliv.OrderByDescending(b => b.Paginas);
                    break;

                case "D: 1 - 10":
                    sorliv = sorliv.OrderBy(b => b.Data);
                    break;

                case "D: 10 - 1":
                    sorliv = sorliv.OrderByDescending(b => b.Data);
                    break;

                case "ID: 1 - 10":
                    sorliv = sorliv.OrderBy(b => b.Id);
                    break;

                case "ID: 10 - 1":
                    sorliv = sorliv.OrderByDescending(b => b.Id);
                    break;

                case "Pr: 1 - 10":
                    sorliv = sorliv.OrderBy(b => b.Preco);
                    break;

                case "Pr: 10 - 1":
                    sorliv = sorliv.OrderByDescending(b => b.Preco);
                    break;
            }

            return sorliv.ToList();
        }

        public List<Revista> sortRevista(List<Revista> revista, string s)
        {
            try
            {
                if (revista == null || !revista.Any())
                {
                    throw new ArgumentException("Список книг пуст или равен null");
                }
            }
            catch (ArgumentException erro)
            {
                MessageBox.Show(erro.Message, "ERRO");
            }

            var sorrev = revista.AsQueryable();

            switch (s)
            {
                case "E: A - Z":
                    sorrev = sorrev.OrderBy(b => b.Editora);
                    break;

                case "E: Z - A":
                    sorrev = sorrev.OrderByDescending(b => b.Editora);
                    break;

                case "T: A - Z":
                    sorrev = sorrev.OrderBy(b => b.Titulo);
                    break;

                case "T: Z - A":
                    sorrev = sorrev.OrderByDescending(b => b.Titulo);
                    break;

                case "P: 1 - 10":
                    sorrev = sorrev.OrderBy(b => b.Paginas);
                    break;

                case "P: 10 - 1":
                    sorrev = sorrev.OrderByDescending(b => b.Paginas);
                    break;

                case "D: 1 - 10":
                    sorrev = sorrev.OrderBy(b => b.Data);
                    break;

                case "D: 10 - 1":
                    sorrev = sorrev.OrderByDescending(b => b.Data);
                    break;

                case "ID: 1 - 10":
                    sorrev = sorrev.OrderBy(b => b.Id);
                    break;

                case "ID: 10 - 1":
                    sorrev = sorrev.OrderByDescending(b => b.Id);
                    break;

                case "Pr: 1 - 10":
                    sorrev = sorrev.OrderBy(b => b.Preco);
                    break;

                case "Pr: 10 - 1":
                    sorrev = sorrev.OrderByDescending(b => b.Preco);
                    break;
            }

            return sorrev.ToList();
        }
    }
}

