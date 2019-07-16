using Model;
using System.Data.Entity;

namespace Repository.DataBase
{
    public class SistemaContext : DbContext
    {
        public SistemaContext() : base("DefaultConnection")
        {

        }
        public DbSet<Estado> Estados { get; set; }
    }
}

