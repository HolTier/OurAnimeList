using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OurAM_Api.Migrations
{
    /// <inheritdoc />
    public partial class AnimeCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Anime",
                newName: "ShortDescription");

            migrationBuilder.AddColumn<int>(
                name: "Episodes",
                table: "Anime",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Anime",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Episodes",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Anime");

            migrationBuilder.RenameColumn(
                name: "ShortDescription",
                table: "Anime",
                newName: "Image");
        }
    }
}
