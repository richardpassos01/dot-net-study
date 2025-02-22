﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using src.Infrastructure.Database;

#nullable disable

namespace LoanManagement.src.Infrastructure.Database.Migrations
{
    [DbContext(typeof(RelationalDbContext))]
    partial class RelationalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("src.Domain.FeatureFlags", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("FeatureName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("FeatureFlags");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2937df8f-adab-412f-92c0-a5109d65286c"),
                            FeatureName = "Feature1",
                            IsEnabled = true
                        },
                        new
                        {
                            Id = new Guid("3856007a-dbd3-47e2-9510-788af89e37ad"),
                            FeatureName = "Feature2",
                            IsEnabled = false
                        });
                });

            modelBuilder.Entity("src.Domain.LoanApplication", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("OfferId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OfferId");

                    b.ToTable("Applications");

                    b.HasData(
                        new
                        {
                            Id = new Guid("733d8ef9-da50-4bbc-9d0e-3cc307780117"),
                            OfferId = new Guid("6a025144-cdca-4268-8be5-0f2bea86e9aa"),
                            UserId = new Guid("760ecc0e-2332-46de-8ce5-fdd10ce27bc8")
                        });
                });

            modelBuilder.Entity("src.Domain.Offer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("PaybackAmount")
                        .HasColumnType("TEXT");

                    b.Property<int>("PaymentTerms")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Offers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6a025144-cdca-4268-8be5-0f2bea86e9aa"),
                            PaybackAmount = 1000m,
                            PaymentTerms = 12
                        });
                });

            modelBuilder.Entity("src.Domain.LoanApplication", b =>
                {
                    b.HasOne("src.Domain.Offer", "Offer")
                        .WithMany()
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Offer");
                });
#pragma warning restore 612, 618
        }
    }
}
