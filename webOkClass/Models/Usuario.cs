using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webOkClass.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Matricula { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Endereço { get; set; }
        public string Campus { get; set; }
        public string TipoFuncionario { get; set; }
    }
}
