using Microsoft.EntityFrameworkCore;
using src.Domain;
using System;

namespace src.Infrastructure.Database.Seeds;
public static class OfferSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var offerId = Guid.NewGuid();

        modelBuilder.Entity<Offer>().HasData(
            new Offer { Id = offerId, PaybackAmount = 1000, PaymentTerms = 12 }
        );

        modelBuilder.Entity<LoanApplication>().HasData(
            new LoanApplication { Id = Guid.NewGuid(), UserId = Guid.NewGuid(), OfferId = offerId }
        );
    }
}
