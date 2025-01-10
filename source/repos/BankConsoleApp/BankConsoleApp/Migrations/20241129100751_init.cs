using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankConsoleApp.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HolderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balance = table.Column<float>(type: "real", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TryToEnterTimes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceCardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DestinationCardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isSuccessful = table.Column<bool>(type: "bit", nullable: false),
                    forCardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_Cards_forCardId",
                        column: x => x.forCardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "Balance", "CardNumber", "HolderName", "IsActive", "Password", "TryToEnterTimes" },
                values: new object[,]
                {
                    { 1, 1000f, "1234567812345678", "علی احمدی", true, "password123", 0 },
                    { 2, 1500f, "2345678923456789", "مریم محمدی", true, "password456", 0 },
                    { 3, 2000f, "3456789034567890", "رضا حسینی", true, "password789", 0 },
                    { 4, 2500f, "4567890145678901", "سارا کریمی", true, "password101", 0 },
                    { 5, 3000f, "5678901256789012", "حسین سلطانی", true, "password202", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_forCardId",
                table: "Transactions",
                column: "forCardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Cards");
        }
    }
}
