using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    interface IClienteRepository
    {
        List<Cliente> ObterTodos(string busca);
        int Inserir(Cliente cliente);
        bool Alterar(Cliente cliente);
        Cliente ObterPeloId(int id);
        bool Apagar(int id);
    }
}
