using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressV.Data.Migrations
{
    public partial class init_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventaires",
                columns: table => new
                {
                    CodeVin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Annee = table.Column<int>(type: "int", nullable: false),
                    Marque = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modele = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Finition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAchat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrixAchat = table.Column<float>(type: "real", nullable: false),
                    PrixVente = table.Column<float>(type: "real", nullable: false),
                    DateVente = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsVente = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventaires", x => x.CodeVin);
                });

            migrationBuilder.CreateTable(
                name: "Reparations",
                columns: table => new
                {
                    ReparationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventaireId = table.Column<int>(type: "int", nullable: false),
                    DateDisponibilite = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CoutReparation = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reparations", x => x.ReparationId);
                    table.ForeignKey(
                        name: "FK_Reparations_Inventaires_InventaireId",
                        column: x => x.InventaireId,
                        principalTable: "Inventaires",
                        principalColumn: "CodeVin",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reparations_InventaireId",
                table: "Reparations",
                column: "InventaireId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reparations");

            migrationBuilder.DropTable(
                name: "Inventaires");
        }
    }
}
