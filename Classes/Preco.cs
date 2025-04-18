using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Classes
{
    internal class Preco : Info
    {
        float IVA = 0.23f;
        float precoLivPagina = 0.06f;
        float precoRevPagina = 0.45f;

        public Preco(int numPaginas, float preco) 
        { 
            Paginas = numPaginas;
            Preco = preco;
        }

        public float PrecoLivSemIVA()
        {
            return Paginas * precoLivPagina;
        }

        public float PrecoRevSemIVA()
        {
            return Paginas * precoRevPagina;
        }

        public float PrecoLivComIVA()
        {
            return PrecoLivSemIVA() * (1 + IVA);
        }

        public float PrecoRevComIVA()
        {
            return PrecoRevSemIVA() * (1 + IVA);
        }

        public override void infDoc()
        {
            throw new NotImplementedException();
        }
    }
}
