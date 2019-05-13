using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CouponMerchant.Data.Migrations
{
    public partial class CreateMerchantTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_AspNetUsers_UserId",
                table: "Car");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceHeader_Car_CarId",
                table: "ServiceHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceShoppingCart_Car_CarId",
                table: "ServiceShoppingCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Car",
                table: "Car");

            migrationBuilder.RenameTable(
                name: "Car",
                newName: "Deal");

            migrationBuilder.RenameIndex(
                name: "IX_Car_UserId",
                table: "Deal",
                newName: "IX_Deal_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Deal",
                table: "Deal",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Merchant",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchant", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Deal_AspNetUsers_UserId",
                table: "Deal",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deal_AspNetUsers_UserId",
                table: "Deal");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceHeader_Deal_CarId",
                table: "ServiceHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceShoppingCart_Deal_CarId",
                table: "ServiceShoppingCart");

            migrationBuilder.DropTable(
                name: "Merchant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Deal",
                table: "Deal");

            migrationBuilder.RenameTable(
                name: "Deal",
                newName: "Car");

            migrationBuilder.RenameIndex(
                name: "IX_Deal_UserId",
                table: "Car",
                newName: "IX_Car_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Car",
                table: "Car",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_AspNetUsers_UserId",
                table: "Car",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceHeader_Car_CarId",
                table: "ServiceHeader",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceShoppingCart_Car_CarId",
                table: "ServiceShoppingCart",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
