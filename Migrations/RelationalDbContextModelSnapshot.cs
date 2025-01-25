﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using src.Infrastructure.Database;

#nullable disable

namespace LoanManagement.Migrations
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
                            Id = new Guid("59bed3ea-1778-49d8-9219-fa86df345905"),
                            FeatureName = "Feature1",
                            IsEnabled = true
                        },
                        new
                        {
                            Id = new Guid("e7a31985-3161-4b2f-9e56-8f30a1bc35bc"),
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
                            Id = new Guid("2b62a7bb-a376-4dc0-b11f-c5a7e42673f2"),
                            OfferId = new Guid("9f36ad48-65e5-41d1-9f37-03a57ae89161"),
                            UserId = new Guid("57f1f59e-f2c5-4fe2-b24d-e585f05a2248")
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
                            Id = new Guid("9f36ad48-65e5-41d1-9f37-03a57ae89161"),
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
