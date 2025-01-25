using Microsoft.EntityFrameworkCore;
using src.Domain;
using System;

namespace src.Infrastructure.Database.Seeds;

public static class FeatureFlagsSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FeatureFlags>().HasData(
            new FeatureFlags { Id = Guid.NewGuid(), FeatureName = "Feature1", IsEnabled = true },
            new FeatureFlags { Id = Guid.NewGuid(), FeatureName = "Feature2", IsEnabled = false }
        );
    }
}
