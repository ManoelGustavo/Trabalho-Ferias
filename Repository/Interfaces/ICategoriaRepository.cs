using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    interface ICategoriaRepository
    {
        List<Categoria> ObterTodos(string busca);

        int Inserir(Categoria estado);

        bool Alterar(Categoria estado);

        Categoria ObterPeloId(int id);

        bool Apagar(int id);
    }
}
