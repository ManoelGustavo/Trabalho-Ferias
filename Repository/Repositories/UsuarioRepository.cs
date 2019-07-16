using Model;
using Repository.DataBase;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public SistemaContext context;

        public UsuarioRepository()
        {
            context = new SistemaContext();
        }

        public bool Alterar(Usuario usuario)
        {
            Usuario usuarioOriginal = (from x in context.Usuarios where x.Id == usuario.Id select x).FirstOrDefault();
            if (usuarioOriginal == null)
            {
                return false;
            }
            usuarioOriginal.Nome = usuario.Nome;
            usuarioOriginal.Login = usuario.Login;
            usuarioOriginal.Senha = usuario.Senha;
            return true;
        }

        public bool Apagar(int id)
        {
            Usuario usuario = (from usuarios in context.Usuarios where usuarios.Id == id select usuarios).FirstOrDefault();

            if (usuario == null)
            {
                return false;
            }
            usuario.RegistroAtivo = false;
            context.SaveChanges();
            return true;
        }

        public int Inserir(Usuario usuario)
        {
            context.Usuarios.Add(usuario);
            context.SaveChanges();
            return usuario.Id;
        }

        public Usuario ObterPeloId(int id)
        {
            return (from usuario in context.Usuarios where usuario.Id == id select usuario).FirstOrDefault();
        }

        public List<Usuario> ObterTodos(string busca)
        {
            busca = ($"%{busca}%");
            return (from usuario
                    in context.Usuarios
                    where usuario.Senha.Contains(busca) || usuario.Login.Contains(busca) || usuario.Nome.Contains(busca)
                    orderby usuario.Login
                    select usuario).ToList();

        }
    }
}
