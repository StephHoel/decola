using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Decola.Models
{
    public class Tecnologia
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome da tecnologia é obrigatório")]
        public string Nome { get; set; }
        public List<Usuario> Usuarios { get; set; }
    }
}
