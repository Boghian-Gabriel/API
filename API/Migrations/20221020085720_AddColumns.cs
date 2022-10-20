using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class AddColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("1b56122e-444d-4e72-a13c-15ad977b850e"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("30decd5c-a3c5-4eb3-98e6-6f11423a39a7"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("37a42452-dc47-403f-896c-d32ccb1faf0d"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("5484aa56-4860-42d9-8d0b-2a9edd29d296"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("7cf7242b-cc66-44df-83a3-4a47eebc1918"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("7fe0df80-1027-464b-a724-eef6d7959b3a"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("a59d3595-f56e-4485-a0db-73333b77f1e7"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("b8040589-f515-439d-8173-5d6e68a17b19"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("bde74fc4-2685-4584-a82a-464d38c72039"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("c3be9488-3c62-494e-9385-45b23ee67b8e"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("dfc44ca6-6df2-4aff-beca-e0b5b4eab856"));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Users",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "IdGenre",
                keyValue: new Guid("7252f1ba-4885-411e-9ae2-5b8b801be464"),
                column: "GenreName",
                value: "Comedy");

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "IdRefGenre", "RealeseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("154d8cd8-d573-4388-b7b7-2ba9e23c4c0a"), new Guid("133d337e-5a77-4107-89de-210783900c1d"), new DateTime(2000, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mascatul" },
                    { new Guid("19701638-7a3b-4794-bb3b-e6b5fc138394"), new Guid("917c3492-f531-44de-a321-b9b17a7a90e4"), new DateTime(2022, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avatar 2" },
                    { new Guid("33a82281-f0af-4c41-8e80-9f34337979a8"), new Guid("917c3492-f531-44de-a321-b9b17a7a90e4"), new DateTime(2008, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avatar 1" },
                    { new Guid("4836375b-07e2-46bf-908b-9b6850fd882e"), new Guid("d3dbc108-f55a-4acb-28d7-08daa4ff6e55"), new DateTime(2008, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Western P2" },
                    { new Guid("74aba1f4-2078-41a1-a356-6a03d55ad9e8"), new Guid("1ce57ea2-8b3b-4074-9264-60a92872dd98"), new DateTime(2010, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Film Example3" },
                    { new Guid("988f0614-5571-4b90-8cc0-59fd4f6f328a"), new Guid("7c6abc48-36c0-4cec-aed7-0a5161c22b0f"), new DateTime(2012, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Wick 1" },
                    { new Guid("c3cfb5c4-1fe9-4256-90da-ae566797513c"), new Guid("7252f1ba-4885-411e-9ae2-5b8b801be464"), new DateTime(2008, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mr. Bean" },
                    { new Guid("cfd5bf58-93ab-48e7-ac9a-a6b79118ea78"), new Guid("133d337e-5a77-4107-89de-210783900c1d"), new DateTime(1995, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mascatul P2" },
                    { new Guid("d5b0fc67-7d93-4183-aaa1-bf86e76e2634"), new Guid("7c6abc48-36c0-4cec-aed7-0a5161c22b0f"), new DateTime(1934, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Film Example6" },
                    { new Guid("f1f9b624-86f9-4e51-aa30-3ec49e07a59e"), new Guid("2b44ee54-2d50-437c-996d-40525e268186"), new DateTime(2007, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "The horses" },
                    { new Guid("fe63b190-998c-4744-8663-90d3398a10d4"), new Guid("7c6abc48-36c0-4cec-aed7-0a5161c22b0f"), new DateTime(207, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Wick 2" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "isActive",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("154d8cd8-d573-4388-b7b7-2ba9e23c4c0a"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("19701638-7a3b-4794-bb3b-e6b5fc138394"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("33a82281-f0af-4c41-8e80-9f34337979a8"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("4836375b-07e2-46bf-908b-9b6850fd882e"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("74aba1f4-2078-41a1-a356-6a03d55ad9e8"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("988f0614-5571-4b90-8cc0-59fd4f6f328a"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("c3cfb5c4-1fe9-4256-90da-ae566797513c"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("cfd5bf58-93ab-48e7-ac9a-a6b79118ea78"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("d5b0fc67-7d93-4183-aaa1-bf86e76e2634"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("f1f9b624-86f9-4e51-aa30-3ec49e07a59e"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("fe63b190-998c-4744-8663-90d3398a10d4"));

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "IdGenre",
                keyValue: new Guid("7252f1ba-4885-411e-9ae2-5b8b801be464"),
                column: "GenreName",
                value: "Commedy");

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "IdRefGenre", "RealeseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("1b56122e-444d-4e72-a13c-15ad977b850e"), new Guid("7c6abc48-36c0-4cec-aed7-0a5161c22b0f"), new DateTime(207, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Wick 2" },
                    { new Guid("30decd5c-a3c5-4eb3-98e6-6f11423a39a7"), new Guid("2b44ee54-2d50-437c-996d-40525e268186"), new DateTime(2007, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "The horses" },
                    { new Guid("37a42452-dc47-403f-896c-d32ccb1faf0d"), new Guid("133d337e-5a77-4107-89de-210783900c1d"), new DateTime(1995, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mascatul P2" },
                    { new Guid("5484aa56-4860-42d9-8d0b-2a9edd29d296"), new Guid("1ce57ea2-8b3b-4074-9264-60a92872dd98"), new DateTime(2010, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Film Example3" },
                    { new Guid("7cf7242b-cc66-44df-83a3-4a47eebc1918"), new Guid("7c6abc48-36c0-4cec-aed7-0a5161c22b0f"), new DateTime(1934, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Film Example6" },
                    { new Guid("7fe0df80-1027-464b-a724-eef6d7959b3a"), new Guid("917c3492-f531-44de-a321-b9b17a7a90e4"), new DateTime(2008, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avatar 1" },
                    { new Guid("a59d3595-f56e-4485-a0db-73333b77f1e7"), new Guid("d3dbc108-f55a-4acb-28d7-08daa4ff6e55"), new DateTime(2008, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Western P2" },
                    { new Guid("b8040589-f515-439d-8173-5d6e68a17b19"), new Guid("133d337e-5a77-4107-89de-210783900c1d"), new DateTime(2000, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mascatul" },
                    { new Guid("bde74fc4-2685-4584-a82a-464d38c72039"), new Guid("917c3492-f531-44de-a321-b9b17a7a90e4"), new DateTime(2022, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avatar 2" },
                    { new Guid("c3be9488-3c62-494e-9385-45b23ee67b8e"), new Guid("7252f1ba-4885-411e-9ae2-5b8b801be464"), new DateTime(2008, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mr. Bean" },
                    { new Guid("dfc44ca6-6df2-4aff-beca-e0b5b4eab856"), new Guid("7c6abc48-36c0-4cec-aed7-0a5161c22b0f"), new DateTime(2012, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Wick 1" }
                });
        }
    }
}
