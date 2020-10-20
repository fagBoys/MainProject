using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrestCouriers_Career.Migrations
{
    public partial class FivthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "File",
                table: "Bill",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "File",
                table: "Bill",
                nullable: true,
                oldClrType: typeof(byte[]));
        }
    }
}
