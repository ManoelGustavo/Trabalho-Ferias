using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Desenvolvido por Gustavo Manoel
namespace Model
{
    [Table("estados")]
    public class Estado : Base
    {
        public Estado()
        {
            Cidades = new HashSet<Cidade>();
        }
        public virtual ICollection<Cidade> Cidades { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("sigla")]
        public string Sigla { get; set; }
    }
}
