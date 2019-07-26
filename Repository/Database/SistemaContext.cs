using Model;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
//Desenvolvido por Gustavo Manoel
namespace Repository.DataBase
{
    public class SistemaContext : DbContext
    {
        public static SqlCommand AbrirConexao()
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            return comando;
        }

        public SistemaContext() : base("DefaultConnection")
        {
        }
        public DbSet<Estado> Estados { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Cidade> Cidades { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Projeto> Projetos { get; set; }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}

