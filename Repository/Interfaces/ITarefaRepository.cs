using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Desnvolvido por Nathan Micael
namespace Repository.Interfaces
{
    interface ITarefaRepository
    {
        List<Tarefa> ObterTodos(string busca);

        int Inserir(Tarefa tarefa);

        bool Alterar(Tarefa tarefa);

        Tarefa ObterPeloId(int id);

        bool Apagar(int id);
    }
}
