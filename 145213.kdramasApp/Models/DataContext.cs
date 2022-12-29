using Microsoft.EntityFrameworkCore;

namespace _145213.kdramasApp.Models
{
    public class DataContext : DbContext
    {

        private IConfiguration _configuration;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_configuration.GetConnectionString("SqliteConnectionString"));

        }

        public DbSet<Status> Statuses { get; set; }
        public DbSet<KDrama> KDramas { get; set; }
        public DbSet<Actor> Actors { get; set; }

    }
}
