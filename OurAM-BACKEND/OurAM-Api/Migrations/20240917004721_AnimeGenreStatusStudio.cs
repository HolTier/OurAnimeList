using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OurAM_Api.Migrations
{
    /// <inheritdoc />
    public partial class AnimeGenreStatusStudio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Studio",
                table: "Anime");

            migrationBuilder.RenameColumn(
                name: "Genre",
                table: "Anime",
                newName: "RatingRank");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "Anime",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "AiredEnd",
                table: "Anime",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AiredStart",
                table: "Anime",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AnimeStatusID",
                table: "Anime",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AnimeTypeID",
                table: "Anime",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GenreID",
                table: "Anime",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudioID",
                table: "Anime",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AnimeStatuses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeStatuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AnimeType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Studios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studios", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anime_AnimeStatusID",
                table: "Anime",
                column: "AnimeStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Anime_AnimeTypeID",
                table: "Anime",
                column: "AnimeTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Anime_GenreID",
                table: "Anime",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_Anime_StudioID",
                table: "Anime",
                column: "StudioID");

            migrationBuilder.AddForeignKey(
                name: "FK_Anime_AnimeStatuses_AnimeStatusID",
                table: "Anime",
                column: "AnimeStatusID",
                principalTable: "AnimeStatuses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Anime_AnimeType_AnimeTypeID",
                table: "Anime",
                column: "AnimeTypeID",
                principalTable: "AnimeType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Anime_Genres_GenreID",
                table: "Anime",
                column: "GenreID",
                principalTable: "Genres",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Anime_Studios_StudioID",
                table: "Anime",
                column: "StudioID",
                principalTable: "Studios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anime_AnimeStatuses_AnimeStatusID",
                table: "Anime");

            migrationBuilder.DropForeignKey(
                name: "FK_Anime_AnimeType_AnimeTypeID",
                table: "Anime");

            migrationBuilder.DropForeignKey(
                name: "FK_Anime_Genres_GenreID",
                table: "Anime");

            migrationBuilder.DropForeignKey(
                name: "FK_Anime_Studios_StudioID",
                table: "Anime");

            migrationBuilder.DropTable(
                name: "AnimeStatuses");

            migrationBuilder.DropTable(
                name: "AnimeType");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Studios");

            migrationBuilder.DropIndex(
                name: "IX_Anime_AnimeStatusID",
                table: "Anime");

            migrationBuilder.DropIndex(
                name: "IX_Anime_AnimeTypeID",
                table: "Anime");

            migrationBuilder.DropIndex(
                name: "IX_Anime_GenreID",
                table: "Anime");

            migrationBuilder.DropIndex(
                name: "IX_Anime_StudioID",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "AiredEnd",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "AiredStart",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "AnimeStatusID",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "AnimeTypeID",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "GenreID",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "StudioID",
                table: "Anime");

            migrationBuilder.RenameColumn(
                name: "RatingRank",
                table: "Anime",
                newName: "Genre");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "Anime",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Studio",
                table: "Anime",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
