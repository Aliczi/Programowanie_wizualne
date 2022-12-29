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
        public DbSet<Status> Statuses { get; set; }
        public DbSet<KDrama> KDramas { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<KDramaActor> KDramaActors { get; set; }   //joined table



        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<KDramaActor>()
                .HasKey(kda => new {kda.ActorId, kda.KDramaId});
            modelbuilder.Entity<KDramaActor>()
                .HasOne(kd => kd.KDrama)
                .WithMany(kda => kda.KDramaActors)
                .HasForeignKey(kd => kd.KDramaId);
            modelbuilder.Entity<KDramaActor>()
                .HasOne(kda => kda.Actor)
                .WithMany(a => a.KDramaActors)
                .HasForeignKey(kda => kda.ActorId);
        }

    }
}
