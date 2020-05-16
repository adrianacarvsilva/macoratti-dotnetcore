using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade_31.Models
{
    [Table("Paises")]
    public class PaisModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome do País")]
        public string Nome { get; set; }

        public string Codigo { get; set; }
    }
}
