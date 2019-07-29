using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Desenvolvido por Matheus Donato
namespace Model
{
    [Table("cidades")]
    public class Cidade : Base
    {
        public virtual ICollection<Cliente> Clientes { get; set; }

        [ForeignKey("IdEstado")]
        public virtual Estado Estado { get; set; }

        [NotMapped]
        public string NomeEstado
        {
            get
            {
                return Estado.Nome;
            }
        }

        [Column("id_estado")]
        public int IdEstado { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("numero_habitantes")]
        public string NumeroHabitantes { get; set; }
    }
}
