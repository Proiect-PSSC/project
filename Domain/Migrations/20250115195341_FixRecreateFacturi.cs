using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class FixRecreateFacturi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produse_Facturi_Id",
                table: "Produse");

            migrationBuilder.AlterColumn<Guid>(
                name: "FacturaId",
                table: "Produse",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Produse_FacturaId",
                table: "Produse",
                column: "FacturaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produse_Facturi_FacturaId",
                table: "Produse",
                column: "FacturaId",
                principalTable: "Facturi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produse_Facturi_FacturaId",
                table: "Produse");

            migrationBuilder.DropIndex(
                name: "IX_Produse_FacturaId",
                table: "Produse");

            migrationBuilder.AlterColumn<Guid>(
                name: "FacturaId",
                table: "Produse",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Produse_Facturi_Id",
                table: "Produse",
                column: "Id",
                principalTable: "Facturi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
