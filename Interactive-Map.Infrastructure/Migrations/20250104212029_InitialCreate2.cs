using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Interactive_Map.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Media");

            migrationBuilder.AddColumn<Guid>(
                name: "RefrenceId",
                table: "Locations",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefrenceId",
                table: "Locations");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Media",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
