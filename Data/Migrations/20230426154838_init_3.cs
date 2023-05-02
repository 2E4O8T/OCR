using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressV.Data.Migrations
{
    public partial class init_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reparations_Inventaires_InventaireId",
                table: "Reparations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inventaires",
                table: "Inventaires");

            migrationBuilder.RenameTable(
                name: "Inventaires",
                newName: "Inventaire");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inventaire",
                table: "Inventaire",
                column: "CodeVin");

            migrationBuilder.AddForeignKey(
                name: "FK_Reparations_Inventaire_InventaireId",
                table: "Reparations",
                column: "InventaireId",
                principalTable: "Inventaire",
                principalColumn: "CodeVin",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reparations_Inventaire_InventaireId",
                table: "Reparations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inventaire",
                table: "Inventaire");

            migrationBuilder.RenameTable(
                name: "Inventaire",
                newName: "Inventaires");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inventaires",
                table: "Inventaires",
                column: "CodeVin");

            migrationBuilder.AddForeignKey(
                name: "FK_Reparations_Inventaires_InventaireId",
                table: "Reparations",
                column: "InventaireId",
                principalTable: "Inventaires",
                principalColumn: "CodeVin",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
