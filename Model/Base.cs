using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Desenvolvido por Gustavo Manoel

namespace Model
{
    public class Base
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("data_criacao")]
        public DateTime DataCriacao { get; set; }

        [Column("registro_ativo")]
        public bool RegistroAtivo { get; set; }

    }
}
