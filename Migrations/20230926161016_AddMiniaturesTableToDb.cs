using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonCatalogueProduit.Migrations
{
    /// <inheritdoc />
    public partial class AddMiniaturesTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CATEGORIES",
                columns: table => new
                {
                    CategorieID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomCategorie = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIES", x => x.CategorieID);
                });

            migrationBuilder.CreateTable(
                name: "PRODUITS",
                columns: table => new
                {
                    ProduitID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Prix = table.Column<double>(type: "REAL", nullable: false),
                    Quantite = table.Column<int>(type: "INTEGER", nullable: false),
                    CategorieID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUITS", x => x.ProduitID);
                    table.ForeignKey(
                        name: "FK_PRODUITS_CATEGORIES_CategorieID",
                        column: x => x.CategorieID,
                        principalTable: "CATEGORIES",
                        principalColumn: "CategorieID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRODUITS_CategorieID",
                table: "PRODUITS",
                column: "CategorieID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODUITS");

            migrationBuilder.DropTable(
                name: "CATEGORIES");
        }
    }
}
