using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webOkClass.Models
{
    public class Login
    {
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Login deve estar no formato de Email válido")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 10 caracteres")]
        public string Senha { get; set; }

        //[DataType(DataType.Password)]
        //[Compare("Senha", ErrorMessage ="As senhas são diferentes")]
        //public string ConfirmarSenha { get; set; }
    }
}
