using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmaguciaiInfrastructure.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("07e2e974-4cd2-46dc-bf11-a3cda762b8bd"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("1645fe7c-d405-4523-a4c0-3e9d99e06cd8"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("1b859571-f8fb-43ae-ba63-40ccc8925974"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("31f9f9d2-4392-4704-9102-b316c242f5f5"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("4731e42d-813a-4f45-92f4-ecf85ec9b2ad"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("6df58bf0-10d5-45f4-b0e4-eb89fdc2f86c"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("7cf34690-1b62-4bb7-9b14-c458b9ae2184"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("859b3bd9-617b-49be-9cb1-33df35f226a7"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("85cb5ee7-1dd2-4ede-8d49-27130b3922ae"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("8c478326-a017-4aee-913b-110425fdc467"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("a0d8117e-74eb-43a3-8be0-00db445594f2"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("a6e632cf-1097-4ec3-b66b-ba47e727ee14"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("acb6a1c7-7338-4ccb-a50f-24f454dc7550"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("cf74494a-65cf-4904-a6ea-1d7f3bd1165b"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("e17b3bf9-63ff-4cc4-90f9-6c3d7c3ca7af"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("04edd7dc-4556-4575-b310-18f2f3115d11"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2a317413-9179-4ab2-81a1-5054d546d5c5"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("38925b32-0803-489d-9855-84e331b44869"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("424a898b-ee13-441d-84de-ccb71343cf0d"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("556ff386-0e57-424d-b129-93dbf80cdbdd"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("57aca3fb-72f5-439d-82f6-16efc4183b9a"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a7e70005-f39f-4b32-9878-49d9747c1214"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b98affcb-6a17-4ec4-a372-fa52102192b7"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d48d6d74-0bbb-4905-8d0c-b8ffa96571d5"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f17d4f5f-2918-41b3-be09-29b7e293f824"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "GenderName" },
                values: new object[,]
                {
                    { new Guid("07e2e974-4cd2-46dc-bf11-a3cda762b8bd"), "Women" },
                    { new Guid("1645fe7c-d405-4523-a4c0-3e9d99e06cd8"), "Unisex" },
                    { new Guid("1b859571-f8fb-43ae-ba63-40ccc8925974"), "Man" },
                    { new Guid("31f9f9d2-4392-4704-9102-b316c242f5f5"), "Man" },
                    { new Guid("4731e42d-813a-4f45-92f4-ecf85ec9b2ad"), "Unisex" },
                    { new Guid("6df58bf0-10d5-45f4-b0e4-eb89fdc2f86c"), "Man" },
                    { new Guid("7cf34690-1b62-4bb7-9b14-c458b9ae2184"), "Women" },
                    { new Guid("859b3bd9-617b-49be-9cb1-33df35f226a7"), "Women" },
                    { new Guid("85cb5ee7-1dd2-4ede-8d49-27130b3922ae"), "Unisex" },
                    { new Guid("8c478326-a017-4aee-913b-110425fdc467"), "Man" },
                    { new Guid("a0d8117e-74eb-43a3-8be0-00db445594f2"), "Man" },
                    { new Guid("a6e632cf-1097-4ec3-b66b-ba47e727ee14"), "Women" },
                    { new Guid("acb6a1c7-7338-4ccb-a50f-24f454dc7550"), "Unisex" },
                    { new Guid("cf74494a-65cf-4904-a6ea-1d7f3bd1165b"), "Unisex" },
                    { new Guid("e17b3bf9-63ff-4cc4-90f9-6c3d7c3ca7af"), "Women" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { new Guid("04edd7dc-4556-4575-b310-18f2f3115d11"), "Admin" },
                    { new Guid("2a317413-9179-4ab2-81a1-5054d546d5c5"), "User" },
                    { new Guid("38925b32-0803-489d-9855-84e331b44869"), "User" },
                    { new Guid("424a898b-ee13-441d-84de-ccb71343cf0d"), "Admin" },
                    { new Guid("556ff386-0e57-424d-b129-93dbf80cdbdd"), "Admin" },
                    { new Guid("57aca3fb-72f5-439d-82f6-16efc4183b9a"), "User" },
                    { new Guid("a7e70005-f39f-4b32-9878-49d9747c1214"), "Admin" },
                    { new Guid("b98affcb-6a17-4ec4-a372-fa52102192b7"), "User" },
                    { new Guid("d48d6d74-0bbb-4905-8d0c-b8ffa96571d5"), "Admin" },
                    { new Guid("f17d4f5f-2918-41b3-be09-29b7e293f824"), "User" }
                });
        }
    }
}
