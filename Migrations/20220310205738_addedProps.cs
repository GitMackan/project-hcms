using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project_hcms.Migrations
{
    public partial class addedProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Registered",
                table: "VineBeers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "VineBeers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Registered",
                table: "Starters",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Starters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Registered",
                table: "MainCoursesVeg",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "MainCoursesVeg",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Registered",
                table: "Drinks",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Drinks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Registered",
                table: "Desserts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Desserts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Registered",
                table: "Coffees",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Coffees",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Registered",
                table: "Appetizers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Appetizers",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Registered",
                table: "VineBeers");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "VineBeers");

            migrationBuilder.DropColumn(
                name: "Registered",
                table: "Starters");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Starters");

            migrationBuilder.DropColumn(
                name: "Registered",
                table: "MainCoursesVeg");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "MainCoursesVeg");

            migrationBuilder.DropColumn(
                name: "Registered",
                table: "Drinks");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Drinks");

            migrationBuilder.DropColumn(
                name: "Registered",
                table: "Desserts");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Desserts");

            migrationBuilder.DropColumn(
                name: "Registered",
                table: "Coffees");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Coffees");

            migrationBuilder.DropColumn(
                name: "Registered",
                table: "Appetizers");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Appetizers");
        }
    }
}
