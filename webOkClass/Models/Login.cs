using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webOkClass.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Informe um Email Válido")]
        [EmailAddress(ErrorMessage = "Informe uma Email Válido")]
        public string Email { get; set; }    
        
        public string Token { get; set; }

        [Required(ErrorMessage = "Informe uma Senha Válida")]
        [StringLength(15,MinimumLength = 6, ErrorMessage = "A senha deve ter no Mímimo 6 Caracteres")]
        public string Password { get; set; }

        public string PasswordHash { get; set; }

        public DateTime CreateDate { get; set; }
        
    }
}
