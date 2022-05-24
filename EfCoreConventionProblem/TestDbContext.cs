using Microsoft.EntityFrameworkCore;

namespace EfCoreConventionProblem;

public class TestDbContext : DbContext
{
    public DbSet<MainEntity> MainEntities => Set<MainEntity>();
    public DbSet<OtherEntity> OtherEntities => Set<OtherEntity>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=127.0.0.1;Initial Catalog=Irrelevant;User Id=Irrelevant;Password=Irrelevant");
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<decimal>().HavePrecision(16, 2);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MainEntity>(mainEntityBuilder =>
        {
            mainEntityBuilder.OwnsOne(x => x.OwnedEntity, ownedEntityBuilder =>
            {
                ownedEntityBuilder.Property(x => x.Number).HasPrecision(16, 4);
            });
        });

        modelBuilder.Entity<OtherEntity>(otherEntityBuilder =>
        {
            otherEntityBuilder.OwnsMany(x => x.OwnedEntities, ownedEntitiesBuilder =>
            {
                ownedEntitiesBuilder.Property(x => x.Number).HasPrecision(16, 4);
            });
        });
    }
}