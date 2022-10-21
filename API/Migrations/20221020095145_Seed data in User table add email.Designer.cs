﻿// <auto-generated />
using System;
using API.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(ContextDB))]
    [Migration("20221020095145_Seed data in User table add email")]
    partial class SeeddatainUsertableaddemail
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ActorMovie", b =>
                {
                    b.Property<Guid>("ActorsActorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MoviesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ActorsActorId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("ActorMovie");
                });

            modelBuilder.Entity("API.Model.Actor", b =>
                {
                    b.Property<Guid>("ActorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ActorId");

                    b.ToTable("Actors");

                    b.HasData(
                        new
                        {
                            ActorId = new Guid("2771a534-6ddf-440c-aa65-06363ee53892"),
                            FirstName = "Johnny",
                            LastName = "Depp"
                        },
                        new
                        {
                            ActorId = new Guid("17885e02-8e62-4e12-8819-064eb88732c3"),
                            FirstName = "Vin",
                            LastName = "Vin Diesel"
                        },
                        new
                        {
                            ActorId = new Guid("c1e8c4b6-1ba4-4753-b4ce-4e3745d686a8"),
                            FirstName = "Murphy",
                            LastName = "Eddie"
                        },
                        new
                        {
                            ActorId = new Guid("ae83328f-b078-4ed0-8fc4-769a29a99e77"),
                            FirstName = "Schwarzenegger",
                            LastName = "Arnold"
                        },
                        new
                        {
                            ActorId = new Guid("e742be86-5178-484c-82f5-84def99225ec"),
                            FirstName = "Cage",
                            LastName = "Nicolas"
                        },
                        new
                        {
                            ActorId = new Guid("f41a8a8c-8a55-4f19-8fb3-885cd898aceb"),
                            FirstName = "Statham",
                            LastName = "Jason Statham"
                        },
                        new
                        {
                            ActorId = new Guid("08992976-e714-4c2c-9f07-902cd74d62ab"),
                            FirstName = "Keanu",
                            LastName = "Charles Reeves"
                        },
                        new
                        {
                            ActorId = new Guid("53217a0c-d050-4ad6-a70b-a0b8552da9c8"),
                            FirstName = "Dwayne",
                            LastName = "Johnson"
                        },
                        new
                        {
                            ActorId = new Guid("82107bd1-c4c2-4eaf-b0f6-b4b9d0d354a4"),
                            FirstName = "Jackie",
                            LastName = "Chan"
                        },
                        new
                        {
                            ActorId = new Guid("7e7ada24-4c7a-4127-bcb7-f3a47907bfe2"),
                            FirstName = "Van Damme",
                            LastName = "Jean-Claude"
                        });
                });

            modelBuilder.Entity("API.Model.ActorAdress", b =>
                {
                    b.Property<Guid>("ActorAdressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Adress1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Adress2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("ActorAdressId");

                    b.ToTable("ActorAdress");

                    b.HasData(
                        new
                        {
                            ActorAdressId = new Guid("2771a534-6ddf-440c-aa65-06363ee53892"),
                            Adress1 = "Florida str.Florida",
                            Adress2 = "Miami str Miami",
                            City = "New York",
                            Country = "Country2",
                            ZipCode = 254758
                        },
                        new
                        {
                            ActorAdressId = new Guid("17885e02-8e62-4e12-8819-064eb88732c3"),
                            Adress1 = "London",
                            Adress2 = "Lewisham",
                            City = "Doncaster",
                            Country = "United Kingdom",
                            ZipCode = 193256
                        },
                        new
                        {
                            ActorAdressId = new Guid("c1e8c4b6-1ba4-4753-b4ce-4e3745d686a8"),
                            Adress1 = "Torquay 1",
                            Adress2 = "Torquay 2",
                            City = "Torquay",
                            Country = "United Kingdom",
                            ZipCode = 462896
                        },
                        new
                        {
                            ActorAdressId = new Guid("ae83328f-b078-4ed0-8fc4-769a29a99e77"),
                            Adress1 = "Birmingham",
                            Adress2 = "Birmingham 2",
                            City = "Lancashire",
                            Country = "United Kingdom",
                            ZipCode = 189345
                        },
                        new
                        {
                            ActorAdressId = new Guid("e742be86-5178-484c-82f5-84def99225ec"),
                            Adress1 = "Colchester",
                            Adress2 = "Leeds 2",
                            City = "Lancashire1",
                            Country = "United Kingdom",
                            ZipCode = 192675
                        },
                        new
                        {
                            ActorAdressId = new Guid("f41a8a8c-8a55-4f19-8fb3-885cd898aceb"),
                            Adress1 = "Canterbury",
                            Adress2 = "Benfleet 1",
                            City = "Lancashire 12",
                            Country = "United Kingdom",
                            ZipCode = 715289
                        },
                        new
                        {
                            ActorAdressId = new Guid("08992976-e714-4c2c-9f07-902cd74d62ab"),
                            Adress1 = "Chichester",
                            Adress2 = "Bristol",
                            City = "Lancashire 23",
                            Country = "United Kingdom",
                            ZipCode = 267397
                        },
                        new
                        {
                            ActorAdressId = new Guid("53217a0c-d050-4ad6-a70b-a0b8552da9c8"),
                            Adress1 = "York",
                            Adress2 = "Sandown",
                            City = "Lancashire13",
                            Country = "United Kingdom",
                            ZipCode = 254758
                        },
                        new
                        {
                            ActorAdressId = new Guid("82107bd1-c4c2-4eaf-b0f6-b4b9d0d354a4"),
                            Adress1 = "Scunthorpe",
                            Adress2 = "Birmingham",
                            City = "Lancashire",
                            Country = "United Kingdom",
                            ZipCode = 876123
                        },
                        new
                        {
                            ActorAdressId = new Guid("7e7ada24-4c7a-4127-bcb7-f3a47907bfe2"),
                            Adress1 = "Hove",
                            Adress2 = "Wigan",
                            City = "Lancashire 2",
                            Country = "United Kingdom",
                            ZipCode = 657234
                        });
                });

            modelBuilder.Entity("API.Model.Genre", b =>
                {
                    b.Property<Guid>("IdGenre")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdGenre");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            IdGenre = new Guid("d3dbc108-f55a-4acb-28d7-08daa4ff6e55"),
                            GenreName = "Western"
                        },
                        new
                        {
                            IdGenre = new Guid("7c6abc48-36c0-4cec-aed7-0a5161c22b0f"),
                            GenreName = "Action"
                        },
                        new
                        {
                            IdGenre = new Guid("133d337e-5a77-4107-89de-210783900c1d"),
                            GenreName = "Horror"
                        },
                        new
                        {
                            IdGenre = new Guid("2b44ee54-2d50-437c-996d-40525e268186"),
                            GenreName = "Drama"
                        },
                        new
                        {
                            IdGenre = new Guid("7252f1ba-4885-411e-9ae2-5b8b801be464"),
                            GenreName = "Comedy"
                        },
                        new
                        {
                            IdGenre = new Guid("1ce57ea2-8b3b-4074-9264-60a92872dd98"),
                            GenreName = "Crime"
                        },
                        new
                        {
                            IdGenre = new Guid("d5581b46-80e8-4ba0-b357-824130f9a779"),
                            GenreName = "Historical"
                        },
                        new
                        {
                            IdGenre = new Guid("917c3492-f531-44de-a321-b9b17a7a90e4"),
                            GenreName = "Science Fiction"
                        },
                        new
                        {
                            IdGenre = new Guid("8650a45d-ee1d-46a4-8b7f-d8a8bae09f83"),
                            GenreName = "Science Fiction2 "
                        });
                });

            modelBuilder.Entity("API.Model.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdRefGenre")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("RealeseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("IdRefGenre");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ce17fa4f-7687-4a7b-8b86-1f268af474c4"),
                            IdRefGenre = new Guid("7c6abc48-36c0-4cec-aed7-0a5161c22b0f"),
                            RealeseDate = new DateTime(2012, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "John Wick 1"
                        },
                        new
                        {
                            Id = new Guid("f4da5619-73a5-417c-8975-872d12c7da71"),
                            IdRefGenre = new Guid("7c6abc48-36c0-4cec-aed7-0a5161c22b0f"),
                            RealeseDate = new DateTime(207, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "John Wick 2"
                        },
                        new
                        {
                            Id = new Guid("841aa486-a306-4053-bac6-36db7eb079b7"),
                            IdRefGenre = new Guid("917c3492-f531-44de-a321-b9b17a7a90e4"),
                            RealeseDate = new DateTime(2008, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Avatar 1"
                        },
                        new
                        {
                            Id = new Guid("9b6aec3f-48ec-4a92-bf12-0598ff4a9d7c"),
                            IdRefGenre = new Guid("917c3492-f531-44de-a321-b9b17a7a90e4"),
                            RealeseDate = new DateTime(2022, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Avatar 2"
                        },
                        new
                        {
                            Id = new Guid("db348d76-8666-4bd1-9a66-f8050ae93018"),
                            IdRefGenre = new Guid("7252f1ba-4885-411e-9ae2-5b8b801be464"),
                            RealeseDate = new DateTime(2008, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Mr. Bean"
                        },
                        new
                        {
                            Id = new Guid("fcd8e3e5-1b03-4416-8678-0405c63d5d0c"),
                            IdRefGenre = new Guid("1ce57ea2-8b3b-4074-9264-60a92872dd98"),
                            RealeseDate = new DateTime(2010, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Film Example3"
                        },
                        new
                        {
                            Id = new Guid("e0c51a35-6324-44f4-a094-dd41f0deb249"),
                            IdRefGenre = new Guid("d3dbc108-f55a-4acb-28d7-08daa4ff6e55"),
                            RealeseDate = new DateTime(2008, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Western P2"
                        },
                        new
                        {
                            Id = new Guid("ddd44de0-0d4b-4861-9fe4-70e81ad2ba7f"),
                            IdRefGenre = new Guid("133d337e-5a77-4107-89de-210783900c1d"),
                            RealeseDate = new DateTime(2000, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Mascatul"
                        },
                        new
                        {
                            Id = new Guid("b7fcf052-71b1-49d8-9dbd-e23dc66e3f23"),
                            IdRefGenre = new Guid("7c6abc48-36c0-4cec-aed7-0a5161c22b0f"),
                            RealeseDate = new DateTime(1934, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Film Example6"
                        },
                        new
                        {
                            Id = new Guid("7cbea0bc-bf83-4985-97f1-bbb68d5cc32e"),
                            IdRefGenre = new Guid("133d337e-5a77-4107-89de-210783900c1d"),
                            RealeseDate = new DateTime(1995, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Mascatul P2"
                        },
                        new
                        {
                            Id = new Guid("250bba42-2d40-495a-914f-27d73e0a4967"),
                            IdRefGenre = new Guid("2b44ee54-2d50-437c-996d-40525e268186"),
                            RealeseDate = new DateTime(2007, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The horses"
                        });
                });

            modelBuilder.Entity("API.Model.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "admin@email.com",
                            Password = "admin",
                            UserName = "admin",
                            isActive = true
                        },
                        new
                        {
                            UserId = 2,
                            Email = "admin123@gmail.com",
                            Password = "pass123",
                            UserName = "admin123",
                            isActive = true
                        });
                });

            modelBuilder.Entity("ActorMovie", b =>
                {
                    b.HasOne("API.Model.Actor", null)
                        .WithMany()
                        .HasForeignKey("ActorsActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Model.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API.Model.ActorAdress", b =>
                {
                    b.HasOne("API.Model.Actor", "Actor")
                        .WithOne("Adress")
                        .HasForeignKey("API.Model.ActorAdress", "ActorAdressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");
                });

            modelBuilder.Entity("API.Model.Movie", b =>
                {
                    b.HasOne("API.Model.Genre", "Genre")
                        .WithMany("Movies")
                        .HasForeignKey("IdRefGenre")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("API.Model.Actor", b =>
                {
                    b.Navigation("Adress")
                        .IsRequired();
                });

            modelBuilder.Entity("API.Model.Genre", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}