using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webOkClass.Models
{
    public class ReservaSala
    {    
        public int ReservaSalaID { get; set; }
        public int StatusReserva { get; set; }

        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        public int SalaDeAulaId { get; set; }
        public virtual SalaDeAula SalaDeAula { get; set; }
    }
}
