using System.Data.Entity;

namespace Cinema.Server.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DbConnection")
        {

        }

        public DbSet<FilmSession> FilmSessions { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}