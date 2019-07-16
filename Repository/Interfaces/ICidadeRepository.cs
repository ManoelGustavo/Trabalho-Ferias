using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Desenvolvido por Matheus Donato

namespace Repository.Interfaces
{
    interface ICidadeRepository
    {
        List<Cidade> ObterTodos(string busca);
        int Inserir(Cidade cidade);
        bool Alterar(Cidade cidade);
        Cidade ObterPeloId(int id);
        bool Apagar(int id);
    }
}
