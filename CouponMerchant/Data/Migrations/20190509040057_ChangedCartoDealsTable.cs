using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CouponMerchant.Data.Migrations
{
    public partial class ChangedCartoDealsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "Make",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "Miles",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Car");

            migrationBuilder.RenameColumn(
                name: "VIN",
                table: "Car",
                newName: "DealName");

            migrationBuilder.RenameColumn(
                name: "Style",
                table: "Car",
                newName: "Url");

            migrationBuilder.AddColumn<decimal>(
                name: "DollarValue",
                table: "Car",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Car",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Car",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DollarValue",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Car");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Car",
                newName: "Style");

            migrationBuilder.RenameColumn(
                name: "DealName",
                table: "Car",
                newName: "VIN");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Car",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Make",
                table: "Car",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Miles",
                table: "Car",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Car",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Car",
                nullable: false,
                defaultValue: 0);
        }
    }
}
