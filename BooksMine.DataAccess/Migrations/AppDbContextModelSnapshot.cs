﻿// <auto-generated />
using System;
using BooksMineWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BooksMine.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BooksMine.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("cityId")
                        .HasColumnType("int");

                    b.Property<int>("countryId")
                        .HasColumnType("int");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("cityId");

                    b.HasIndex("countryId");

                    b.ToTable("authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            cityId = 1,
                            countryId = 1,
                            firstName = "Charles",
                            lastName = "Dickens"
                        },
                        new
                        {
                            Id = 2,
                            cityId = 1,
                            countryId = 1,
                            firstName = "William",
                            lastName = "Shakespear"
                        });
                });

            modelBuilder.Entity("BooksMine.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("authId")
                        .HasColumnType("int");

                    b.Property<int?>("catId")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("edition")
                        .HasColumnType("int");

                    b.Property<string>("imgUrl")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("noInStock")
                        .HasColumnType("int");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.Property<int?>("pubId")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("authId");

                    b.HasIndex("catId");

                    b.HasIndex("pubId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            authId = 1,
                            catId = 2,
                            description = "A Tale of Two Cities is a historical novel published in 1859 by English author Charles Dickens, set in London and Paris before and during the French Revolution.",
                            edition = 10,
                            imgUrl = "test.jpg",
                            noInStock = 5,
                            price = 560.0,
                            pubId = 1,
                            title = "A Tale of Two Cities"
                        },
                        new
                        {
                            Id = 2,
                            authId = 2,
                            catId = 2,
                            description = "The Tragedy of Julius Caesar (First Folio title: The Tragedie of Ivlivs Cæsar), often shortened to Julius Caesar, is a history play and tragedy by William Shakespeare first performed in 1599.",
                            edition = 9,
                            imgUrl = "test2.jpg",
                            noInStock = 12,
                            price = 360.0,
                            pubId = 1,
                            title = "Julius Caesar"
                        });
                });

            modelBuilder.Entity("BooksMine.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            description = "This Category Include The Scariest Adventures One Can Ever Expreince",
                            name = "Horror"
                        },
                        new
                        {
                            Id = 2,
                            description = "This Category Include The Greatest Novels Ever Wrote in History",
                            name = "Drama"
                        },
                        new
                        {
                            Id = 3,
                            description = "This Category Include Adventures Beyond Imagination",
                            name = "Sci-FI"
                        });
                });

            modelBuilder.Entity("BooksMine.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            name = "London"
                        },
                        new
                        {
                            Id = 2,
                            name = "Paris"
                        });
                });

            modelBuilder.Entity("BooksMine.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            name = "England"
                        },
                        new
                        {
                            Id = 2,
                            name = "France"
                        });
                });

            modelBuilder.Entity("BooksMine.Models.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("cityId")
                        .HasColumnType("int");

                    b.Property<int>("countryId")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("cityId");

                    b.HasIndex("countryId");

                    b.ToTable("publishers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            address = "Sheraton House, Castle Park, Cambridge, CB3 0AX,",
                            cityId = 1,
                            countryId = 1,
                            email = "editors@pegasuspublishers.com",
                            name = "pegasus",
                            phone = "01223665568"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BooksMine.Models.Models.AppUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("AppUser");
                });

            modelBuilder.Entity("BooksMine.Models.Author", b =>
                {
                    b.HasOne("BooksMine.Models.City", "city")
                        .WithMany()
                        .HasForeignKey("cityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BooksMine.Models.Country", "country")
                        .WithMany()
                        .HasForeignKey("countryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("city");

                    b.Navigation("country");
                });

            modelBuilder.Entity("BooksMine.Models.Book", b =>
                {
                    b.HasOne("BooksMine.Models.Author", "author")
                        .WithMany()
                        .HasForeignKey("authId");

                    b.HasOne("BooksMine.Models.Category", "category")
                        .WithMany()
                        .HasForeignKey("catId");

                    b.HasOne("BooksMine.Models.Publisher", "publisher")
                        .WithMany()
                        .HasForeignKey("pubId");

                    b.Navigation("author");

                    b.Navigation("category");

                    b.Navigation("publisher");
                });

            modelBuilder.Entity("BooksMine.Models.Publisher", b =>
                {
                    b.HasOne("BooksMine.Models.City", "city")
                        .WithMany()
                        .HasForeignKey("cityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BooksMine.Models.Country", "country")
                        .WithMany()
                        .HasForeignKey("countryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("city");

                    b.Navigation("country");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
