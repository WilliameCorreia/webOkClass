using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webOkClass.Models
{
    public class SalaOcupada
    {
        public int SalaOcupadaID { get; set; }
        public int StatusSalaOcupada { get; set; }

        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        public int SalaDeAulaId { get; set; }
        public virtual SalaDeAula SalaDeAula { get; set; }
    }
}
