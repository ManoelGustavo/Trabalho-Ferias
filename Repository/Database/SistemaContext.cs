using Model;
using System.Data.Entity;
//Desenvolvido por Gustavo Manoel
namespace Repository.DataBase
{
    public class SistemaContext : DbContext
    {
        public SistemaContext() : base("DefaultConnection")
        {

        }
        public DbSet<Estado> Estados { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Cidade> Cidades { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Projeto> Projetos { get; set; }
    }
}

