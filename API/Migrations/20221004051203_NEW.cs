using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class NEW : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("196ffc06-84f5-4fa8-abcf-5bb94c291eb2"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("2dd885f5-782e-4b74-a542-fc1945148877"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("42c1542a-a00a-4d93-b25d-556667ce94ab"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("778a6870-5ea1-4d1e-aec7-d377161bd53d"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("77c819c9-0662-4136-a0ed-24a33b49d700"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("9b898df3-83cc-4b00-8fb9-dacac4d2b479"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("9cd5ff99-8c45-49c1-b4a2-8b78bc88aa8f"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("a56f6141-dcfc-4c91-bc8a-9e95a9da18c3"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("af405835-2859-46a1-aeb8-83f90e2b55a6"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("c8e3d0c8-64b3-4c89-b85e-f21e2ed41db8"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("cd29fe7d-8083-4e80-93f6-09409b03d9e1"));

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "IdRefGenre", "RealeseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("1eceb362-4671-4391-96b5-fe3e354edd9e"), new Guid("133d337e-5a77-4107-89de-210783900c1d"), new DateTime(1995, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mascatul P2" },
                    { new Guid("31ed0093-23e5-414c-a7c1-286f0c4a5eed"), new Guid("133d337e-5a77-4107-89de-210783900c1d"), new DateTime(2000, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mascatul" },
                    { new Guid("49fec475-50f5-489b-a583-f7fbd50ffcab"), new Guid("7252f1ba-4885-411e-9ae2-5b8b801be464"), new DateTime(2008, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mr. Bean" },
                    { new Guid("61d95a04-0595-4833-ba0a-7691bff095ad"), new Guid("2b44ee54-2d50-437c-996d-40525e268186"), new DateTime(2007, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "The horses" },
                    { new Guid("62c92a35-aced-4cff-918c-704ff8202278"), new Guid("7c6abc48-36c0-4cec-aed7-0a5161c22b0f"), new DateTime(207, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Wick 2" },
                    { new Guid("72e6691b-bb3c-408a-8564-8ac043eadf65"), new Guid("917c3492-f531-44de-a321-b9b17a7a90e4"), new DateTime(2008, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avatar 1" },
                    { new Guid("82fedac9-39db-4da0-980a-7e0dceffb118"), new Guid("d3dbc108-f55a-4acb-28d7-08daa4ff6e55"), new DateTime(2008, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Western P2" },
                    { new Guid("8d389dd0-8ee7-463d-b0f9-76a73eb70318"), new Guid("7c6abc48-36c0-4cec-aed7-0a5161c22b0f"), new DateTime(2012, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Wick 1" },
                    { new Guid("b9ad210a-fed1-4aac-9820-f479a44598e7"), new Guid("1ce57ea2-8b3b-4074-9264-60a92872dd98"), new DateTime(2010, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Film Example3" },
                    { new Guid("bfd7688b-9ab2-45e0-bd97-a99e9500247a"), new Guid("7c6abc48-36c0-4cec-aed7-0a5161c22b0f"), new DateTime(1934, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Film Example6" },
                    { new Guid("efb2a6a1-10ac-4408-9fa0-72d491354b10"), new Guid("917c3492-f531-44de-a321-b9b17a7a90e4"), new DateTime(2022, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avatar 2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("1eceb362-4671-4391-96b5-fe3e354edd9e"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("31ed0093-23e5-414c-a7c1-286f0c4a5eed"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("49fec475-50f5-489b-a583-f7fbd50ffcab"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("61d95a04-0595-4833-ba0a-7691bff095ad"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("62c92a35-aced-4cff-918c-704ff8202278"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("72e6691b-bb3c-408a-8564-8ac043eadf65"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("82fedac9-39db-4da0-980a-7e0dceffb118"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("8d389dd0-8ee7-463d-b0f9-76a73eb70318"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("b9ad210a-fed1-4aac-9820-f479a44598e7"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("bfd7688b-9ab2-45e0-bd97-a99e9500247a"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("efb2a6a1-10ac-4408-9fa0-72d491354b10"));

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "IdRefGenre", "RealeseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("196ffc06-84f5-4fa8-abcf-5bb94c291eb2"), new Guid("7c6abc48-36c0-4cec-aed7-0a5161c22b0f"), new DateTime(207, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Wick 2" },
                    { new Guid("2dd885f5-782e-4b74-a542-fc1945148877"), new Guid("2b44ee54-2d50-437c-996d-40525e268186"), new DateTime(2007, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "The horses" },
                    { new Guid("42c1542a-a00a-4d93-b25d-556667ce94ab"), new Guid("133d337e-5a77-4107-89de-210783900c1d"), new DateTime(2000, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mascatul" },
                    { new Guid("778a6870-5ea1-4d1e-aec7-d377161bd53d"), new Guid("917c3492-f531-44de-a321-b9b17a7a90e4"), new DateTime(2008, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avatar 1" },
                    { new Guid("77c819c9-0662-4136-a0ed-24a33b49d700"), new Guid("7252f1ba-4885-411e-9ae2-5b8b801be464"), new DateTime(2008, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mr. Bean" },
                    { new Guid("9b898df3-83cc-4b00-8fb9-dacac4d2b479"), new Guid("d3dbc108-f55a-4acb-28d7-08daa4ff6e55"), new DateTime(2008, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Western P2" },
                    { new Guid("9cd5ff99-8c45-49c1-b4a2-8b78bc88aa8f"), new Guid("133d337e-5a77-4107-89de-210783900c1d"), new DateTime(1995, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mascatul P2" },
                    { new Guid("a56f6141-dcfc-4c91-bc8a-9e95a9da18c3"), new Guid("7c6abc48-36c0-4cec-aed7-0a5161c22b0f"), new DateTime(2012, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Wick 1" },
                    { new Guid("af405835-2859-46a1-aeb8-83f90e2b55a6"), new Guid("917c3492-f531-44de-a321-b9b17a7a90e4"), new DateTime(2022, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avatar 2" },
                    { new Guid("c8e3d0c8-64b3-4c89-b85e-f21e2ed41db8"), new Guid("7c6abc48-36c0-4cec-aed7-0a5161c22b0f"), new DateTime(1934, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Film Example6" },
                    { new Guid("cd29fe7d-8083-4e80-93f6-09409b03d9e1"), new Guid("1ce57ea2-8b3b-4074-9264-60a92872dd98"), new DateTime(2010, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Film Example3" }
                });
        }
    }
}
