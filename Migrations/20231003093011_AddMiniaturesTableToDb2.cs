using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonCatalogueProduit.Migrations
{
    /// <inheritdoc />
    public partial class AddMiniaturesTableToDb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "PRODUITS",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "PRODUITS");
        }
    }
}
