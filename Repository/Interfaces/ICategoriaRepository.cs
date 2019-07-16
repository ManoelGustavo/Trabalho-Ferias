using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Desenvolvido por Gustavo Manoel

namespace Repository.Interfaces
{
    interface ICategoriaRepository
    {
        List<Categoria> ObterTodos(string busca);

        int Inserir(Categoria categoria);

        bool Alterar(Categoria categoria);

        Categoria ObterPeloId(int id);

        bool Apagar(int id);
    }
}
