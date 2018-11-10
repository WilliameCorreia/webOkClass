using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webOkClass.Models
{
    public class Usuario: Login
    {
     
        public int UsuarioId { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "A matricula deve ter entre 6 e 15 caracteres")]
        public string Matricula { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "A nome deve ter entre 6 e 15 caracteres")]
        public string Nome { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "A sobrenome deve ter entre 6 e 15 caracteres")]
        public string Sobrenome { get; set; }

        [Required]
        public int Campus { get; set; }

        [Required]
        public int TipoFuncionario { get; set; }
       
        
    }

    
}
