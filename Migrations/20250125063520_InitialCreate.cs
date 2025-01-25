using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LoanManagement.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FeatureFlags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FeatureName = table.Column<string>(type: "TEXT", nullable: true),
                    IsEnabled = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureFlags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PaybackAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    PaymentTerms = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    OfferId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applications_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FeatureFlags",
                columns: new[] { "Id", "FeatureName", "IsEnabled" },
                values: new object[,]
                {
                    { new Guid("59bed3ea-1778-49d8-9219-fa86df345905"), "Feature1", true },
                    { new Guid("e7a31985-3161-4b2f-9e56-8f30a1bc35bc"), "Feature2", false }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "PaybackAmount", "PaymentTerms" },
                values: new object[] { new Guid("9f36ad48-65e5-41d1-9f37-03a57ae89161"), 1000m, 12 });

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "OfferId", "UserId" },
                values: new object[] { new Guid("2b62a7bb-a376-4dc0-b11f-c5a7e42673f2"), new Guid("9f36ad48-65e5-41d1-9f37-03a57ae89161"), new Guid("57f1f59e-f2c5-4fe2-b24d-e585f05a2248") });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_OfferId",
                table: "Applications",
                column: "OfferId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "FeatureFlags");

            migrationBuilder.DropTable(
                name: "Offers");
        }
    }
}
