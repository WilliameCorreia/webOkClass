using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webOkClass.Models
{
    public class SalaDeAula
    {
        public SalaDeAula()
        {
            this.Reserva = new List<ReservaSala>();
            this.Usuario = new List<Usuario>();
            this.SalaOcupada = new List<SalaOcupada>();
        }

        public int SalaDeAulaId { get; set; }
        public int NumeroDaSala { get; set; }
        public int TipoDeSala { get; set; }
        public int StatusDaSala { get; set; }       
      
        public virtual ICollection<ReservaSala> Reserva { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
        public virtual ICollection<SalaOcupada> SalaOcupada { get; set; }
    }
}
