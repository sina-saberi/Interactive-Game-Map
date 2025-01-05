using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Interactive_Map.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastSynced",
                table: "Games",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Synced",
                table: "Games",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SpecialGameLinks",
                table: "Config",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecialMapLinks",
                table: "Config",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastSynced",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Synced",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "SpecialGameLinks",
                table: "Config");

            migrationBuilder.DropColumn(
                name: "SpecialMapLinks",
                table: "Config");
        }
    }
}
