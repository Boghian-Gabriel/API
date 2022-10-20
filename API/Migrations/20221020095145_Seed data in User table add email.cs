using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class SeeddatainUsertableaddemail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "IdRefGenre", "RealeseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("250bba42-2d40-495a-914f-27d73e0a4967"), new Guid("2b44ee54-2d50-437c-996d-40525e268186"), new DateTime(2007, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "The horses" },
                    { new Guid("7cbea0bc-bf83-4985-97f1-bbb68d5cc32e"), new Guid("133d337e-5a77-4107-89de-210783900c1d"), new DateTime(1995, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mascatul P2" },
                    { new Guid("841aa486-a306-4053-bac6-36db7eb079b7"), new Guid("917c3492-f531-44de-a321-b9b17a7a90e4"), new DateTime(2008, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avatar 1" },
                    { new Guid("9b6aec3f-48ec-4a92-bf12-0598ff4a9d7c"), new Guid("917c3492-f531-44de-a321-b9b17a7a90e4"), new DateTime(2022, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avatar 2" },
                    { new Guid("b7fcf052-71b1-49d8-9dbd-e23dc66e3f23"), new Guid("7c6abc48-36c0-4cec-aed7-0a5161c22b0f"), new DateTime(1934, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Film Example6" },
                    { new Guid("ce17fa4f-7687-4a7b-8b86-1f268af474c4"), new Guid("7c6abc48-36c0-4cec-aed7-0a5161c22b0f"), new DateTime(2012, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Wick 1" },
                    { new Guid("db348d76-8666-4bd1-9a66-f8050ae93018"), new Guid("7252f1ba-4885-411e-9ae2-5b8b801be464"), new DateTime(2008, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mr. Bean" },
                    { new Guid("ddd44de0-0d4b-4861-9fe4-70e81ad2ba7f"), new Guid("133d337e-5a77-4107-89de-210783900c1d"), new DateTime(2000, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mascatul" },
                    { new Guid("e0c51a35-6324-44f4-a094-dd41f0deb249"), new Guid("d3dbc108-f55a-4acb-28d7-08daa4ff6e55"), new DateTime(2008, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Western P2" },
                    { new Guid("f4da5619-73a5-417c-8975-872d12c7da71"), new Guid("7c6abc48-36c0-4cec-aed7-0a5161c22b0f"), new DateTime(207, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Wick 2" },
                    { new Guid("fcd8e3e5-1b03-4416-8678-0405c63d5d0c"), new Guid("1ce57ea2-8b3b-4074-9264-60a92872dd98"), new DateTime(2010, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Film Example3" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Email",
                value: "admin@email.com");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Email",
                value: "admin123@gmail.com");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("250bba42-2d40-495a-914f-27d73e0a4967"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("7cbea0bc-bf83-4985-97f1-bbb68d5cc32e"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("841aa486-a306-4053-bac6-36db7eb079b7"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("9b6aec3f-48ec-4a92-bf12-0598ff4a9d7c"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("b7fcf052-71b1-49d8-9dbd-e23dc66e3f23"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("ce17fa4f-7687-4a7b-8b86-1f268af474c4"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("db348d76-8666-4bd1-9a66-f8050ae93018"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("ddd44de0-0d4b-4861-9fe4-70e81ad2ba7f"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("e0c51a35-6324-44f4-a094-dd41f0deb249"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("f4da5619-73a5-417c-8975-872d12c7da71"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("fcd8e3e5-1b03-4416-8678-0405c63d5d0c"));

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
                column: "Email",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Email",
                value: null);
        }
    }
}
