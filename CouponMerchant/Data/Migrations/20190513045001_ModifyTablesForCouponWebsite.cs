using Microsoft.EntityFrameworkCore.Migrations;

namespace CouponMerchant.Data.Migrations
{
    public partial class ModifyTablesForCouponWebsite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceHeader_Deal_CarId",
                table: "ServiceHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceShoppingCart_Deal_CarId",
                table: "ServiceShoppingCart");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "State",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "ServiceShoppingCart",
                newName: "DealId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceShoppingCart_CarId",
                table: "ServiceShoppingCart",
                newName: "IX_ServiceShoppingCart_DealId");

            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "ServiceHeader",
                newName: "DealId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceHeader_CarId",
                table: "ServiceHeader",
                newName: "IX_ServiceHeader_DealId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceHeader_Deal_DealId",
                table: "ServiceHeader",
                column: "DealId",
                principalTable: "Deal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceShoppingCart_Deal_DealId",
                table: "ServiceShoppingCart",
                column: "DealId",
                principalTable: "Deal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceHeader_Deal_DealId",
                table: "ServiceHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceShoppingCart_Deal_DealId",
                table: "ServiceShoppingCart");

            migrationBuilder.RenameColumn(
                name: "DealId",
                table: "ServiceShoppingCart",
                newName: "CarId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceShoppingCart_DealId",
                table: "ServiceShoppingCart",
                newName: "IX_ServiceShoppingCart_CarId");

            migrationBuilder.RenameColumn(
                name: "DealId",
                table: "ServiceHeader",
                newName: "CarId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceHeader_DealId",
                table: "ServiceHeader",
                newName: "IX_ServiceHeader_CarId");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceHeader_Deal_CarId",
                table: "ServiceHeader",
                column: "CarId",
                principalTable: "Deal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceShoppingCart_Deal_CarId",
                table: "ServiceShoppingCart",
                column: "CarId",
                principalTable: "Deal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
