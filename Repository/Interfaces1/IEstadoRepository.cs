using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    interface IEstadoRepository
    {
        List<Estado> ObterTodos(string busca);

        int Inserir(Estado estado);

        bool Alterar(Estado estado);

        Estado ObterPeloId(int id);

        bool Apagar(int id);
    }
}
