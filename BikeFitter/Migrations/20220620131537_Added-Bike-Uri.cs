using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeFitter.Migrations
{
    public partial class AddedBikeUri : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Uri",
                table: "Bike",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Uri",
                table: "Bike");
        }
    }
}
