using Microsoft.EntityFrameworkCore.Migrations;

namespace CouponMerchant.Migrations
{
    public partial class AddedMerchantIdFKtoUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MerchantId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MerchantId",
                table: "AspNetUsers",
                column: "MerchantId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Merchant_MerchantId",
                table: "AspNetUsers",
                column: "MerchantId",
                principalTable: "Merchant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Merchant_MerchantId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MerchantId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MerchantId",
                table: "AspNetUsers");
        }
    }
}
