using Microsoft.EntityFrameworkCore;
using WebAtrioTest.DataBaseCommunication.Model;

namespace WebAtrioTest.DataBaseCommunication
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
           : base(options)
        {
        }
        public DbSet<Personne> Personnes { get; set; }
        public DbSet<Emploi> Emplois { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personne>()
                .HasMany(p => p.Emplois)
                .WithOne(e => e.Personne)
                .HasForeignKey(e => e.PersonneId);
        }


    }
}
