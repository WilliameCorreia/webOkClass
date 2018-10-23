﻿using System;
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
        [StringLength(10, MinimumLength = 6, ErrorMessage = "A matricula deve ter entre 6 e 10 caracteres")]
        public string Matricula { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "A nome deve ter entre 6 e 10 caracteres")]
        public string Nome { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "A sobrenome deve ter entre 6 e 10 caracteres")]
        public string Sobrenome { get; set; }

        
        public string Cpf { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }

        public string Endereço { get; set; }

        [Required]
        public int Campus { get; set; }

        [Required]
        public int TipoFuncionario { get; set; }
    }
}
