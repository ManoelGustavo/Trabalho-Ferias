using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    interface IProjetoRepository
    {
        List<Projeto> ObterTodos(string busca);
        int Inserir(Projeto projeto);
        bool Alterar(Projeto projeto);
        Projeto ObterPeloId(int id);
        bool Apagar(int id);
    }
}
