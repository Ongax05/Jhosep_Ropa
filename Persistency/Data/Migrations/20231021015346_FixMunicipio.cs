using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistency.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixMunicipio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Municipio",
                type: "varchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Talla_Descripcion",
                table: "Talla",
                column: "Descripcion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Talla_Descripcion",
                table: "Talla");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Municipio");
        }
    }
}
