using Microsoft.EntityFrameworkCore.Migrations;

namespace CrestCouriers_Career.Migrations
{
    public partial class AddPrimaryToImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Primary",
                table: "Image",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
