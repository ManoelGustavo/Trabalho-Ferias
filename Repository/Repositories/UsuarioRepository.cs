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
            Usuario usuarioOriginal = context.Usuarios.FirstOrDefault(x => x.Id == usuario.Id);
            if (usuarioOriginal == null)
            {
                return false;
            }
            usuarioOriginal.Nome = usuario.Nome;
            usuarioOriginal.Login = usuario.Login;
            usuarioOriginal.Senha = usuario.Senha;
            context.SaveChanges();
            return true;
        }

        public bool Apagar(int id)
        {
            Usuario usuario = context.Usuarios.FirstOrDefault(x => x.Id == id);
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
            usuario.DataCriacao = DateTime.Now;
            context.Usuarios.Add(usuario);
            context.SaveChanges();
            return usuario.Id;
        }

        public Usuario ObterPeloId(int id)
        {
            return context.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public List<Usuario> ObterTodos(string busca)
        {
            return context.Usuarios.Where(x => x.RegistroAtivo && (string.IsNullOrEmpty(busca) ? true : (x.Login.Contains(busca) || x.Nome.Contains(busca)))).OrderBy(x => x.Login).ToList();
        }
    }
}
