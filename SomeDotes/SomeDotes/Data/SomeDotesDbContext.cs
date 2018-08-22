namespace SomeDotes.Data
{
    using Microsoft.EntityFrameworkCore;
    using SomeDotes.Data.Entities;

    public class SomeDotesDbContext : DbContext
    {
        public DbSet<Result> Results { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Ability> Abilities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Result>()
                .HasMany(r => r.Players)
                .WithOne(p => p.Result)
                .HasForeignKey(p => p.ResultId);
            
            builder
                .Entity<Player>()
                .HasMany(p => p.Abilities)
                .WithOne(a => a.Player)
                .HasForeignKey(a => a.PlayerId);

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder
                .UseSqlServer("Server=.;Database=SomeDotes;Trusted_Connection=true");

            base.OnConfiguring(builder);
        }
    }
}
