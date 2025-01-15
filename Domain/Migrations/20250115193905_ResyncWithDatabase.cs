using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class ResyncWithDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Facturi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PretTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataFacturarii = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produse",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Denumire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pret = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cantitate = table.Column<int>(type: "int", nullable: false),
                    FacturaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produse_Facturi_Id",
                        column: x => x.Id,
                        principalTable: "Facturi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produse");

            migrationBuilder.DropTable(
                name: "Facturi");
        }
    }
}
