using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Intersect.Server.Migrations.Sqlite.Game
{
    /// <inheritdoc />
    public partial class AddFactionsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FactionId",
                table: "Npcs",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Factions",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    LeaderPlayerId = table.Column<Guid>(type: "TEXT", nullable: true),
                    WarCooldownHours = table.Column<int>(type: "INTEGER", nullable: false),
                    LastWarDeclarationTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    AtWarWith = table.Column<string>(type: "TEXT", nullable: true),
                    Folder = table.Column<string>(type: "TEXT", nullable: true),
                    TimeCreated = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Factions");

            migrationBuilder.DropColumn(
                name: "FactionId",
                table: "Npcs");
        }
    }
}
