using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("054fefe2-aab3-4ed2-93a2-df3491be349e"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("0e122a87-8020-4761-99a3-24da88a4eede"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("1fba347d-d47a-4b1d-811a-f3074a238d7a"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("3e988992-a16c-41bf-9cc5-f9e48ce60918"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("9432b9cb-b23f-4809-8c68-aff8d71c45d3"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("bc1bd1ee-cb75-48e3-b4eb-e3507092de26"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("c537a849-4bff-4de7-9d55-38da6e677d7d"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("caefe546-1d73-48ac-a648-7054d886219c"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("ddbdf787-5c2c-4699-b2c7-ae9c398b5a3c"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("de303a78-5f0d-4ceb-8b72-4cc1826d5e53"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("ff5d2ace-7351-48f2-b809-3926b8fed5ba"));

            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    ActorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.ActorId);
                });

            migrationBuilder.CreateTable(
                name: "ActorAdress",
                columns: table => new
                {
                    ActorAdressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Adress1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adress2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorAdress", x => x.ActorAdressId);
                    table.ForeignKey(
                        name: "FK_ActorAdress_Actors_ActorAdressId",
                        column: x => x.ActorAdressId,
                        principalTable: "Actors",
                        principalColumn: "ActorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActorMovie",
                columns: table => new
                {
                    ActorsActorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MoviesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorMovie", x => new { x.ActorsActorId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_ActorMovie_Actors_ActorsActorId",
                        column: x => x.ActorsActorId,
                        principalTable: "Actors",
                        principalColumn: "ActorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorMovie_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ActorMovie_MoviesId",
                table: "ActorMovie",
                column: "MoviesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorAdress");

            migrationBuilder.DropTable(
                name: "ActorMovie");

            migrationBuilder.DropTable(
                name: "Actors");

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
                table: "Movies",
                columns: new[] { "Id", "IdRefGenre", "RealeseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("054fefe2-aab3-4ed2-93a2-df3491be349e"), new Guid("2b44ee54-2d50-437c-996d-40525e268186"), new DateTime(2007, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "The horses" },
                    { new Guid("0e122a87-8020-4761-99a3-24da88a4eede"), new Guid("7c6abc48-36c0-4cec-aed7-0a5161c22b0f"), new DateTime(2012, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Wick 1" },
                    { new Guid("1fba347d-d47a-4b1d-811a-f3074a238d7a"), new Guid("7c6abc48-36c0-4cec-aed7-0a5161c22b0f"), new DateTime(207, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Wick 2" },
                    { new Guid("3e988992-a16c-41bf-9cc5-f9e48ce60918"), new Guid("917c3492-f531-44de-a321-b9b17a7a90e4"), new DateTime(2008, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avatar 1" },
                    { new Guid("9432b9cb-b23f-4809-8c68-aff8d71c45d3"), new Guid("917c3492-f531-44de-a321-b9b17a7a90e4"), new DateTime(2022, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avatar 2" },
                    { new Guid("bc1bd1ee-cb75-48e3-b4eb-e3507092de26"), new Guid("1ce57ea2-8b3b-4074-9264-60a92872dd98"), new DateTime(2010, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Film Example3" },
                    { new Guid("c537a849-4bff-4de7-9d55-38da6e677d7d"), new Guid("7c6abc48-36c0-4cec-aed7-0a5161c22b0f"), new DateTime(1934, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Film Example6" },
                    { new Guid("caefe546-1d73-48ac-a648-7054d886219c"), new Guid("7252f1ba-4885-411e-9ae2-5b8b801be464"), new DateTime(2008, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mr. Bean" },
                    { new Guid("ddbdf787-5c2c-4699-b2c7-ae9c398b5a3c"), new Guid("d3dbc108-f55a-4acb-28d7-08daa4ff6e55"), new DateTime(2008, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Western P2" },
                    { new Guid("de303a78-5f0d-4ceb-8b72-4cc1826d5e53"), new Guid("133d337e-5a77-4107-89de-210783900c1d"), new DateTime(2000, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mascatul" },
                    { new Guid("ff5d2ace-7351-48f2-b809-3926b8fed5ba"), new Guid("133d337e-5a77-4107-89de-210783900c1d"), new DateTime(1995, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mascatul P2" }
                });
        }
    }
}
