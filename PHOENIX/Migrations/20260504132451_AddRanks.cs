using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PHOENIX.Migrations
{
    /// <inheritdoc />
    public partial class AddRanks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SportsRank",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SportsRank",
                table: "Users");
        }
    }
}
