using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrestCouriers_Career.Migrations
{
    public partial class BillsFilename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Place_PlaceId",
                table: "Address");

            migrationBuilder.DropTable(
                name: "Place");

            migrationBuilder.DropIndex(
                name: "IX_Address_PlaceId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "Address");

            migrationBuilder.AlterColumn<string>(
                name: "Confirmation",
                table: "Bill",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "filename",
                table: "Bill",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Address",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Recipient = table.Column<string>(maxLength: 20, nullable: true),
                    Company = table.Column<string>(maxLength: 20, nullable: true),
                    Town = table.Column<string>(maxLength: 20, nullable: false),
                    Postcode = table.Column<string>(maxLength: 20, nullable: false),
                    LocationType = table.Column<string>(maxLength: 20, nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_Location_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_LocationId",
                table: "Address",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_OrderId",
                table: "Location",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Location_LocationId",
                table: "Address",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Location_LocationId",
                table: "Address");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Address_LocationId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "filename",
                table: "Bill");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Address");

            migrationBuilder.AlterColumn<string>(
                name: "Confirmation",
                table: "Bill",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlaceId",
                table: "Address",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Place",
                columns: table => new
                {
                    PlaceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Company = table.Column<string>(maxLength: 20, nullable: true),
                    LocationType = table.Column<string>(maxLength: 20, nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    Postcode = table.Column<string>(maxLength: 20, nullable: false),
                    Recipient = table.Column<string>(maxLength: 20, nullable: true),
                    Town = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Place", x => x.PlaceId);
                    table.ForeignKey(
                        name: "FK_Place_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_PlaceId",
                table: "Address",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Place_OrderId",
                table: "Place",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Place_PlaceId",
                table: "Address",
                column: "PlaceId",
                principalTable: "Place",
                principalColumn: "PlaceId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
