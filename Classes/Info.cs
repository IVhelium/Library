using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca.Classes
{
    public abstract class Info
    {
        private string _titulo;
        private int _paginas;
        private string _autor;
        private string _editora;
        private string _genero;
        private string _id;
        private DateTime _data;
        private float _preco;

        public bool _emprestado;

        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }

        public int Paginas
        {
            get { return _paginas; }
            set { _paginas = value; }
        }

        public string Autor
        {
            get { return _autor; }
            set { _autor = value; }
        }

        public string Editora
        {
            get { return _editora; }
            set { _editora = value; }
        }

        public string Genero
        {
            get { return _genero; }
            set { _genero = value; }
        }

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public DateTime Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public float Preco
        {
            get { return _preco; }
            set { _preco = value; }
        }

        public abstract void infDoc();

        public void emprestado(string titulo)
        {
            if (_emprestado)
            {
                MessageBox.Show("O documento: " + titulo + "\nencontra-se requisitado");
            }
        }
    }
}
