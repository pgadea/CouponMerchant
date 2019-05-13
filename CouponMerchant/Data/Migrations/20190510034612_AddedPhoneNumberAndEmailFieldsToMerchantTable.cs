using Microsoft.EntityFrameworkCore.Migrations;

namespace CouponMerchant.Data.Migrations
{
    public partial class AddedPhoneNumberAndEmailFieldsToMerchantTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Merchant",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Merchant",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Merchant");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Merchant");
        }
    }
}
