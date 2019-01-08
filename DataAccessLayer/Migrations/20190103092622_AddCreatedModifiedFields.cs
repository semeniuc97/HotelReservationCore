using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class AddCreatedModifiedFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Rooms",
                newName: "Modified");

            migrationBuilder.RenameColumn(
                name: "AddDate",
                table: "Rooms",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Hotels",
                newName: "Modified");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Hotels",
                newName: "Created");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Bookings",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Bookings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "Modified",
                table: "Rooms",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Rooms",
                newName: "AddDate");

            migrationBuilder.RenameColumn(
                name: "Modified",
                table: "Hotels",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Hotels",
                newName: "CreateDate");
        }
    }
}
