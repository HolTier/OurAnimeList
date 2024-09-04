using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OurAM_Api.Migrations
{
    /// <inheritdoc />
    public partial class AnimeRefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Anime",
                newName: "TitleJP");

            migrationBuilder.AddColumn<string>(
                name: "Studio",
                table: "Anime",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TitleEN",
                table: "Anime",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Studio",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "TitleEN",
                table: "Anime");

            migrationBuilder.RenameColumn(
                name: "TitleJP",
                table: "Anime",
                newName: "Title");
        }
    }
}
