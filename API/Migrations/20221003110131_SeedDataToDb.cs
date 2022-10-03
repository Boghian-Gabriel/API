using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class SeedDataToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "IdGenre",
                keyValue: new Guid("1b3d461c-9d9c-4772-a39b-f7453d91ca52"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "IdGenre",
                keyValue: new Guid("20f6829a-4e3f-412a-8b8f-7817c7d5aac7"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "IdGenre",
                keyValue: new Guid("26ba7c21-450e-496b-955b-e81cd690324f"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "IdGenre",
                keyValue: new Guid("858dd697-9f3c-40df-abc7-4872f53f1680"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "IdGenre",
                keyValue: new Guid("9cdefdb5-149e-427b-a02f-14be3916e144"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "IdGenre",
                keyValue: new Guid("a3bce2a9-19af-43ad-9f64-f86d633980e3"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "IdGenre",
                keyValue: new Guid("a668cefc-683a-4839-a118-122bfb728ccf"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "IdGenre",
                keyValue: new Guid("cda91bc2-2014-4eaf-b43f-2e3efe9e2846"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "IdGenre",
                keyValue: new Guid("d5e06ae8-2b4c-44f4-abdf-0903918daa40"));

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "IdGenre", "GenreName" },
                values: new object[,]
                {
                    { new Guid("133d337e-5a77-4107-89de-210783900c1d"), "Horror" },
                    { new Guid("1ce57ea2-8b3b-4074-9264-60a92872dd98"), "Crime" },
                    { new Guid("2b44ee54-2d50-437c-996d-40525e268186"), "Drama" },
                    { new Guid("7252f1ba-4885-411e-9ae2-5b8b801be464"), "Commedy" },
                    { new Guid("7c6abc48-36c0-4cec-aed7-0a5161c22b0f"), "Action" },
                    { new Guid("8650a45d-ee1d-46a4-8b7f-d8a8bae09f83"), "Science Fiction2 " },
                    { new Guid("917c3492-f531-44de-a321-b9b17a7a90e4"), "Science Fiction" },
                    { new Guid("d3dbc108-f55a-4acb-28d7-08daa4ff6e55"), "Western" },
                    { new Guid("d5581b46-80e8-4ba0-b357-824130f9a779"), "Historical" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "IdRefGenre", "RealeseDate", "Title" },
                values: new object[] { new Guid("db0e705c-1f7b-4a61-93d3-087799c35d3f"), new Guid("7c6abc48-36c0-4cec-aed7-0a5161c22b0f"), new DateTime(2012, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Wick 1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "IdGenre",
                keyValue: new Guid("133d337e-5a77-4107-89de-210783900c1d"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "IdGenre",
                keyValue: new Guid("1ce57ea2-8b3b-4074-9264-60a92872dd98"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "IdGenre",
                keyValue: new Guid("2b44ee54-2d50-437c-996d-40525e268186"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "IdGenre",
                keyValue: new Guid("7252f1ba-4885-411e-9ae2-5b8b801be464"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "IdGenre",
                keyValue: new Guid("8650a45d-ee1d-46a4-8b7f-d8a8bae09f83"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "IdGenre",
                keyValue: new Guid("917c3492-f531-44de-a321-b9b17a7a90e4"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "IdGenre",
                keyValue: new Guid("d3dbc108-f55a-4acb-28d7-08daa4ff6e55"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "IdGenre",
                keyValue: new Guid("d5581b46-80e8-4ba0-b357-824130f9a779"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("db0e705c-1f7b-4a61-93d3-087799c35d3f"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "IdGenre",
                keyValue: new Guid("7c6abc48-36c0-4cec-aed7-0a5161c22b0f"));

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "IdGenre", "GenreName" },
                values: new object[,]
                {
                    { new Guid("1b3d461c-9d9c-4772-a39b-f7453d91ca52"), "Historical" },
                    { new Guid("20f6829a-4e3f-412a-8b8f-7817c7d5aac7"), "Commedy" },
                    { new Guid("26ba7c21-450e-496b-955b-e81cd690324f"), "Crime" },
                    { new Guid("858dd697-9f3c-40df-abc7-4872f53f1680"), "Science Fiction2 " },
                    { new Guid("9cdefdb5-149e-427b-a02f-14be3916e144"), "Horror" },
                    { new Guid("a3bce2a9-19af-43ad-9f64-f86d633980e3"), "Science Fiction" },
                    { new Guid("a668cefc-683a-4839-a118-122bfb728ccf"), "Action" },
                    { new Guid("cda91bc2-2014-4eaf-b43f-2e3efe9e2846"), "Drama" },
                    { new Guid("d5e06ae8-2b4c-44f4-abdf-0903918daa40"), "Western" }
                });
        }
    }
}
