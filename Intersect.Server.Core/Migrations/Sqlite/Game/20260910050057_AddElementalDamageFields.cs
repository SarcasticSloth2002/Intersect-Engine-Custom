using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Intersect.Server.Migrations.Sqlite.Game
{
    /// <inheritdoc />
    public partial class AddElementalDamageFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Combat_Element",
                table: "Spells",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Element",
                table: "Npcs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Element",
                table: "Items",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ElementalResistance",
                table: "Items",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PercentageElementalResistance",
                table: "Items",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Combat_Element",
                table: "Spells");

            migrationBuilder.DropColumn(
                name: "Element",
                table: "Npcs");

            migrationBuilder.DropColumn(
                name: "Element",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ElementalResistance",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "PercentageElementalResistance",
                table: "Items");
        }
    }
}
