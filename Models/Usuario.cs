using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Decola.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome do usuário é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "É obrigatório digitar uma habilidade")]
        public string Skill { get; set; }
        [Range(1, 3, ErrorMessage = "O nível da habilidade vai até 3")]
        public int NivelId { get; set; }

        public Tecnologia Tecnologia { get; set; }
    }
}
