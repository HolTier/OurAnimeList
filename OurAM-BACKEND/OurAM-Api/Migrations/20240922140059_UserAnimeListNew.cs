using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OurAM_Api.Migrations
{
    /// <inheritdoc />
    public partial class UserAnimeListNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "UserAnimeLists",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EpisodeWatched",
                table: "UserAnimeLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishWatching",
                table: "UserAnimeLists",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartWatching",
                table: "UserAnimeLists",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "UserAnimeLists");

            migrationBuilder.DropColumn(
                name: "EpisodeWatched",
                table: "UserAnimeLists");

            migrationBuilder.DropColumn(
                name: "FinishWatching",
                table: "UserAnimeLists");

            migrationBuilder.DropColumn(
                name: "StartWatching",
                table: "UserAnimeLists");
        }
    }
}
