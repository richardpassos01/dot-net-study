using Microsoft.EntityFrameworkCore;
using src.Domain;
using src.Infrastructure.Database.Seeds;

namespace src.Infrastructure.Database;
public class RelationalDbContext : DbContext
{
    public RelationalDbContext(DbContextOptions<RelationalDbContext> options) : base(options)
    {
    }

    public DbSet<Offer> Offers { get; set; }
    public DbSet<LoanApplication> Applications { get; set; }
    public DbSet<FeatureFlags> FeatureFlags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        OfferSeed.Seed(modelBuilder);
        FeatureFlagsSeed.Seed(modelBuilder);
    }
}
