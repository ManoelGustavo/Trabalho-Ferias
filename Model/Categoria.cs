using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Desenvolvido por Gustavo Manoel
namespace Model
{
    [Table("categorias")]
    public class Categoria : Base
    {
        public Categoria()
        {
            Tarefas = new HashSet<Tarefa>();
        }
        public virtual ICollection<Tarefa> Tarefas { get; set; }

        [Column("nome")]
        public string Nome { get; set; }
    }
}
