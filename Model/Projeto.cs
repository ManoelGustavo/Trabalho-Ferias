using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Desenvolvido por Matheus Donato
namespace Model
{
    [Table("projetos")]
    public class Projeto : Base
    {
        public Projeto()
        {
            Tarefas = new HashSet<Tarefa>();
        }
        public virtual ICollection<Tarefa> Tarefas { get; set; }

        [ForeignKey("IdCliente")]
        public virtual Cliente Cliente { get; set; } 

        [Column("id_cliente")]
        public int IdCliente { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("data_criacao")]
        public DateTime DataCriacaoProjeto { get; set; }

        [Column("data_finalizacao")]
        public DateTime DataFinalizacao { get; set; }
    }
}
