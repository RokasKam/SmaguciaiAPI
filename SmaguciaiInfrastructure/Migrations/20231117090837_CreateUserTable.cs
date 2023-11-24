using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmaguciaiInfrastructure.Migrations
{
    public partial class CreateUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenderName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReviewCount = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "GenderName" },
                values: new object[,]
                {
                    { new Guid("252f7fbf-2234-4791-965f-8bf7338e78ce"), "Women" },
                    { new Guid("7d7519ee-4c6f-4fb2-8540-cc60a2f08eb3"), "Man" },
                    { new Guid("a9f5eeca-beaa-4c2b-982c-30b8eb330a1a"), "Women" },
                    { new Guid("b81d6893-6578-4499-bcfa-bf2f21da8022"), "Unisex" },
                    { new Guid("c726eaa8-0a41-413d-8e29-a904e0ffbc47"), "Man" },
                    { new Guid("edcfa76f-fe40-40c7-8548-d4f1fcd80cdd"), "Women" },
                    { new Guid("f6465369-14c0-4749-969b-e6f74f8e6824"), "Unisex" },
                    { new Guid("f980a88a-f203-4a71-bc93-2e3bd8e726eb"), "Man" },
                    { new Guid("fd91919f-b541-4d6e-adbc-0aa133afa70c"), "Unisex" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { new Guid("10f3984e-67e8-4645-bd67-37363b85c5f2"), "Admin" },
                    { new Guid("46c58d37-0df8-4ee1-8088-e2a59dca40c7"), "User" },
                    { new Guid("5edc5605-e40e-40bf-8a87-be929863ed5b"), "User" },
                    { new Guid("975a0140-9910-4bb8-81a9-ea9d525e62f2"), "Admin" },
                    { new Guid("cfb5ed38-27cd-4775-8614-9f79ae9485be"), "User" },
                    { new Guid("f4ad230a-9506-4324-81c4-86b0db74dbf8"), "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_GenderId",
                table: "Users",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
