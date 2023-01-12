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

        //our tables
        public DbSet<KDrama> KDramas { get; set; }
        public DbSet<Actor> Actors { get; set; }

        public DbSet<Network> Networks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Actor>()
                .HasKey(kda => new {kda.Id});
            modelbuilder.Entity<Actor>()
                .HasOne(kd => kd.KDrama)
                .WithMany(u => u.Actors)
                .HasForeignKey(kd => kd.KDramaId);

            modelbuilder.Entity<KDrama>()
                .HasKey(kda => new { kda.Id });
            modelbuilder.Entity<KDrama>()
                .HasOne(kd => kd.Network)
                .WithMany(u => u.KDramas)
                .HasForeignKey(kd => kd.NetworkId);

        }
    }
}
