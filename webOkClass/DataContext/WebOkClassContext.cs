using Microsoft.EntityFrameworkCore;
using webOkClass.Models;

namespace webOkClass.DataContext
{
    public class WebOkClassContext: DbContext
    {
        public WebOkClassContext(DbContextOptions<WebOkClassContext> options): base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<SalaDeAula> Salas { get; set; }
        public DbSet<ReservaSala> reservas { get; set; }
        public DbSet<SalaOcupada> salaOcupadas { get; set; }

    }
}
