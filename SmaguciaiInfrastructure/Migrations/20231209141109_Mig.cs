using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmaguciaiInfrastructure.Migrations
{
    public partial class Mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DiscountCodes_DiscountcodeId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DiscountcodeId",
                table: "Orders");

            migrationBuilder.AlterColumn<Guid>(
                name: "DiscountcodeId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DiscountcodeId",
                table: "Orders",
                column: "DiscountcodeId",
                unique: true,
                filter: "[DiscountcodeId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DiscountCodes_DiscountcodeId",
                table: "Orders",
                column: "DiscountcodeId",
                principalTable: "DiscountCodes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DiscountCodes_DiscountcodeId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DiscountcodeId",
                table: "Orders");

            migrationBuilder.AlterColumn<Guid>(
                name: "DiscountcodeId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DiscountcodeId",
                table: "Orders",
                column: "DiscountcodeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DiscountCodes_DiscountcodeId",
                table: "Orders",
                column: "DiscountcodeId",
                principalTable: "DiscountCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
