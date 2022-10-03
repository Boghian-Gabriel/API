using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class Add_New_Info_To_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("5000da5a-1502-498e-b0e9-fdefbb68e78b"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("5e1a8f55-7445-46fb-b737-2d1828717863"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("7814e35d-f242-4bc2-b340-db0a24078085"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("8b1c571b-ee1b-4513-a12a-65055517c6ce"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("8bd701ff-0814-48bd-90d5-a78754eb5def"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("a1c3a9cd-d926-499a-b098-38d6b3be1120"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("bde22f26-dd6f-46da-b0e0-bb9d2a2b91c9"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("c14c45b6-fbd7-4737-bab8-1c7a503a5b7d"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("ce67744b-4645-4616-be7c-ecdaaba14e8f"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("d47fc23e-ad3c-4c54-aaa5-a6bbce527c2a"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("fba72dac-37b7-424d-be82-82bf1d2de7e5"));

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "ActorId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("08992976-e714-4c2c-9f07-902cd74d62ab"), "Keanu", "Charles Reeves" },
                    { new Guid("17885e02-8e62-4e12-8819-064eb88732c3"), "Vin", "Vin Diesel" },
                    { new Guid("2771a534-6ddf-440c-aa65-06363ee53892"), "Johnny", "Depp" },
                    { new Guid("53217a0c-d050-4ad6-a70b-a0b8552da9c8"), "Dwayne", "Johnson" },
                    { new Guid("7e7ada24-4c7a-4127-bcb7-f3a47907bfe2"), "Van Damme", "Jean-Claude" },
                    { new Guid("82107bd1-c4c2-4eaf-b0f6-b4b9d0d354a4"), "Jackie", "Chan" },
                    { new Guid("ae83328f-b078-4ed0-8fc4-769a29a99e77"), "Schwarzenegger", "Arnold" },
                    { new Guid("c1e8c4b6-1ba4-4753-b4ce-4e3745d686a8"), "Murphy", "Eddie" },
                    { new Guid("e742be86-5178-484c-82f5-84def99225ec"), "Cage", "Nicolas" },
                    { new Guid("f41a8a8c-8a55-4f19-8fb3-885cd898aceb"), "Statham", "Jason Statham" }
                });

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

            migrationBuilder.InsertData(
                table: "ActorAdress",
                columns: new[] { "ActorAdressId", "Adress1", "Adress2", "City", "Country", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("08992976-e714-4c2c-9f07-902cd74d62ab"), "Chichester", "Bristol", "Lancashire 23", "United Kingdom", 267397 },
                    { new Guid("17885e02-8e62-4e12-8819-064eb88732c3"), "London", "Lewisham", "Doncaster", "United Kingdom", 193256 },
                    { new Guid("2771a534-6ddf-440c-aa65-06363ee53892"), "Florida str.Florida", "Miami str Miami", "New York", "Country2", 254758 },
                    { new Guid("53217a0c-d050-4ad6-a70b-a0b8552da9c8"), "York", "Sandown", "Lancashire13", "United Kingdom", 254758 },
                    { new Guid("7e7ada24-4c7a-4127-bcb7-f3a47907bfe2"), "Hove", "Wigan", "Lancashire 2", "United Kingdom", 657234 },
                    { new Guid("82107bd1-c4c2-4eaf-b0f6-b4b9d0d354a4"), "Scunthorpe", "Birmingham", "Lancashire", "United Kingdom", 876123 },
                    { new Guid("ae83328f-b078-4ed0-8fc4-769a29a99e77"), "Birmingham", "Birmingham 2", "Lancashire", "United Kingdom", 189345 },
                    { new Guid("c1e8c4b6-1ba4-4753-b4ce-4e3745d686a8"), "Torquay 1", "Torquay 2", "Torquay", "United Kingdom", 462896 },
                    { new Guid("e742be86-5178-484c-82f5-84def99225ec"), "Colchester", "Leeds 2", "Lancashire1", "United Kingdom", 192675 },
                    { new Guid("f41a8a8c-8a55-4f19-8fb3-885cd898aceb"), "Canterbury", "Benfleet 1", "Lancashire 12", "United Kingdom", 715289 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ActorAdress",
                keyColumn: "ActorAdressId",
                keyValue: new Guid("08992976-e714-4c2c-9f07-902cd74d62ab"));

            migrationBuilder.DeleteData(
                table: "ActorAdress",
                keyColumn: "ActorAdressId",
                keyValue: new Guid("17885e02-8e62-4e12-8819-064eb88732c3"));

            migrationBuilder.DeleteData(
                table: "ActorAdress",
                keyColumn: "ActorAdressId",
                keyValue: new Guid("2771a534-6ddf-440c-aa65-06363ee53892"));

            migrationBuilder.DeleteData(
                table: "ActorAdress",
                keyColumn: "ActorAdressId",
                keyValue: new Guid("53217a0c-d050-4ad6-a70b-a0b8552da9c8"));

            migrationBuilder.DeleteData(
                table: "ActorAdress",
                keyColumn: "ActorAdressId",
                keyValue: new Guid("7e7ada24-4c7a-4127-bcb7-f3a47907bfe2"));

            migrationBuilder.DeleteData(
                table: "ActorAdress",
                keyColumn: "ActorAdressId",
                keyValue: new Guid("82107bd1-c4c2-4eaf-b0f6-b4b9d0d354a4"));

            migrationBuilder.DeleteData(
                table: "ActorAdress",
                keyColumn: "ActorAdressId",
                keyValue: new Guid("ae83328f-b078-4ed0-8fc4-769a29a99e77"));

            migrationBuilder.DeleteData(
                table: "ActorAdress",
                keyColumn: "ActorAdressId",
                keyValue: new Guid("c1e8c4b6-1ba4-4753-b4ce-4e3745d686a8"));

            migrationBuilder.DeleteData(
                table: "ActorAdress",
                keyColumn: "ActorAdressId",
                keyValue: new Guid("e742be86-5178-484c-82f5-84def99225ec"));

            migrationBuilder.DeleteData(
                table: "ActorAdress",
                keyColumn: "ActorAdressId",
                keyValue: new Guid("f41a8a8c-8a55-4f19-8fb3-885cd898aceb"));

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

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: new Guid("08992976-e714-4c2c-9f07-902cd74d62ab"));

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: new Guid("17885e02-8e62-4e12-8819-064eb88732c3"));

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: new Guid("2771a534-6ddf-440c-aa65-06363ee53892"));

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: new Guid("53217a0c-d050-4ad6-a70b-a0b8552da9c8"));

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: new Guid("7e7ada24-4c7a-4127-bcb7-f3a47907bfe2"));

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: new Guid("82107bd1-c4c2-4eaf-b0f6-b4b9d0d354a4"));

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: new Guid("ae83328f-b078-4ed0-8fc4-769a29a99e77"));

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: new Guid("c1e8c4b6-1ba4-4753-b4ce-4e3745d686a8"));

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: new Guid("e742be86-5178-484c-82f5-84def99225ec"));

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: new Guid("f41a8a8c-8a55-4f19-8fb3-885cd898aceb"));

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "IdRefGenre", "RealeseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("5000da5a-1502-498e-b0e9-fdefbb68e78b"), new Guid("7c6abc48-36c0-4cec-aed7-0a5161c22b0f"), new DateTime(207, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Wick 2" },
                    { new Guid("5e1a8f55-7445-46fb-b737-2d1828717863"), new Guid("133d337e-5a77-4107-89de-210783900c1d"), new DateTime(1995, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mascatul P2" },
                    { new Guid("7814e35d-f242-4bc2-b340-db0a24078085"), new Guid("917c3492-f531-44de-a321-b9b17a7a90e4"), new DateTime(2008, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avatar 1" },
                    { new Guid("8b1c571b-ee1b-4513-a12a-65055517c6ce"), new Guid("917c3492-f531-44de-a321-b9b17a7a90e4"), new DateTime(2022, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avatar 2" },
                    { new Guid("8bd701ff-0814-48bd-90d5-a78754eb5def"), new Guid("1ce57ea2-8b3b-4074-9264-60a92872dd98"), new DateTime(2010, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Film Example3" },
                    { new Guid("a1c3a9cd-d926-499a-b098-38d6b3be1120"), new Guid("2b44ee54-2d50-437c-996d-40525e268186"), new DateTime(2007, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "The horses" },
                    { new Guid("bde22f26-dd6f-46da-b0e0-bb9d2a2b91c9"), new Guid("d3dbc108-f55a-4acb-28d7-08daa4ff6e55"), new DateTime(2008, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Western P2" },
                    { new Guid("c14c45b6-fbd7-4737-bab8-1c7a503a5b7d"), new Guid("133d337e-5a77-4107-89de-210783900c1d"), new DateTime(2000, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mascatul" },
                    { new Guid("ce67744b-4645-4616-be7c-ecdaaba14e8f"), new Guid("7c6abc48-36c0-4cec-aed7-0a5161c22b0f"), new DateTime(2012, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Wick 1" },
                    { new Guid("d47fc23e-ad3c-4c54-aaa5-a6bbce527c2a"), new Guid("7c6abc48-36c0-4cec-aed7-0a5161c22b0f"), new DateTime(1934, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Film Example6" },
                    { new Guid("fba72dac-37b7-424d-be82-82bf1d2de7e5"), new Guid("7252f1ba-4885-411e-9ae2-5b8b801be464"), new DateTime(2008, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mr. Bean" }
                });
        }
    }
}
