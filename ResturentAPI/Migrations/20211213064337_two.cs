using Microsoft.EntityFrameworkCore.Migrations;

namespace ResturentAPI.Migrations
{
    public partial class two : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
