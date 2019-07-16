using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> ObterTodos(string busca);

        int Inserir(Usuario usuario);

        bool Alterar(Usuario usuario);

        Usuario ObterPeloId(int id);

        bool Apagar(int id);
    }
}
