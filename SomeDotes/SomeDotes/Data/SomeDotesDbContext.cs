namespace SomeDotes.Data
{
    using Microsoft.EntityFrameworkCore;

    public class SomeDotesDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {


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
