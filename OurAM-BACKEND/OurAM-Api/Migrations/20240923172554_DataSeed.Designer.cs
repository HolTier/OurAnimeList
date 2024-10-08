﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OurAM_Api.Data;

#nullable disable

namespace OurAM_Api.Migrations
{
    [DbContext(typeof(OuramDbContext))]
    [Migration("20240923172554_DataSeed")]
    partial class DataSeed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("OurAM_Api.Models.Anime", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime?>("AiredEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("AiredStart")
                        .HasColumnType("datetime2");

                    b.Property<int>("AnimeStatusID")
                        .HasColumnType("int");

                    b.Property<int>("AnimeTypeID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Episodes")
                        .HasColumnType("int");

                    b.Property<int>("GenreID")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<string>("RatingRank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudioID")
                        .HasColumnType("int");

                    b.Property<string>("TitleEN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleJP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AnimeStatusID");

                    b.HasIndex("AnimeTypeID");

                    b.HasIndex("GenreID");

                    b.HasIndex("StudioID");

                    b.ToTable("Anime");
                });

            modelBuilder.Entity("OurAM_Api.Models.AnimeStatus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("AnimeStatuses");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Currently Airing"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Finished Airing"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Not Yet Aired"
                        });
                });

            modelBuilder.Entity("OurAM_Api.Models.AnimeType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("AnimeType");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "TV"
                        },
                        new
                        {
                            ID = 2,
                            Name = "OVA"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Movie"
                        },
                        new
                        {
                            ID = 4,
                            Name = "Special"
                        },
                        new
                        {
                            ID = 5,
                            Name = "ONA"
                        },
                        new
                        {
                            ID = 6,
                            Name = "Music"
                        });
                });

            modelBuilder.Entity("OurAM_Api.Models.Genre", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Action"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Adventure"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Comedy"
                        },
                        new
                        {
                            ID = 4,
                            Name = "Drama"
                        },
                        new
                        {
                            ID = 5,
                            Name = "Fantasy"
                        },
                        new
                        {
                            ID = 6,
                            Name = "Magic"
                        },
                        new
                        {
                            ID = 7,
                            Name = "Mecha"
                        },
                        new
                        {
                            ID = 8,
                            Name = "Music"
                        },
                        new
                        {
                            ID = 9,
                            Name = "Romance"
                        },
                        new
                        {
                            ID = 10,
                            Name = "Sci-Fi"
                        },
                        new
                        {
                            ID = 11,
                            Name = "Shounen"
                        },
                        new
                        {
                            ID = 12,
                            Name = "Slice of Life"
                        },
                        new
                        {
                            ID = 13,
                            Name = "Sports"
                        });
                });

            modelBuilder.Entity("OurAM_Api.Models.Studio", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Studios");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Madhouse"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Bones"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Sunrise"
                        },
                        new
                        {
                            ID = 4,
                            Name = "Toei Animation"
                        },
                        new
                        {
                            ID = 5,
                            Name = "Studio Ghibli"
                        },
                        new
                        {
                            ID = 6,
                            Name = "Production I.G"
                        },
                        new
                        {
                            ID = 7,
                            Name = "J.C. Staff"
                        },
                        new
                        {
                            ID = 8,
                            Name = "Kyoto Animation"
                        },
                        new
                        {
                            ID = 9,
                            Name = "A-1 Pictures"
                        },
                        new
                        {
                            ID = 10,
                            Name = "TMS Entertainment"
                        },
                        new
                        {
                            ID = 11,
                            Name = "Wit Studio"
                        },
                        new
                        {
                            ID = 12,
                            Name = "White Fox"
                        },
                        new
                        {
                            ID = 13,
                            Name = "P.A. Works"
                        },
                        new
                        {
                            ID = 14,
                            Name = "Shaft"
                        },
                        new
                        {
                            ID = 15,
                            Name = "Trigger"
                        },
                        new
                        {
                            ID = 16,
                            Name = "Gonzo"
                        },
                        new
                        {
                            ID = 17,
                            Name = "Ufotable"
                        },
                        new
                        {
                            ID = 18,
                            Name = "Bee Train"
                        },
                        new
                        {
                            ID = 19,
                            Name = "Nippon Animation"
                        },
                        new
                        {
                            ID = 20,
                            Name = "Satelight"
                        });
                });

            modelBuilder.Entity("OurAM_Api.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

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

                    b.Property<string>("Provider")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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
                });

            modelBuilder.Entity("OurAM_Api.Models.UserAnimeList", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("AnimeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<int>("EpisodeWatched")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FinishWatching")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsFavorite")
                        .HasColumnType("bit");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Score")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartWatching")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserAnimeStatusID")
                        .HasColumnType("int");

                    b.HasKey("UserId", "AnimeId");

                    b.HasIndex("AnimeId");

                    b.HasIndex("UserAnimeStatusID");

                    b.ToTable("UserAnimeLists");
                });

            modelBuilder.Entity("OurAM_Api.Models.UserAnimeStatus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("UserAnimeStatuses");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Status = "Watching"
                        },
                        new
                        {
                            ID = 2,
                            Status = "Completed"
                        },
                        new
                        {
                            ID = 3,
                            Status = "On Hold"
                        },
                        new
                        {
                            ID = 4,
                            Status = "Dropped"
                        },
                        new
                        {
                            ID = 5,
                            Status = "Plan to Watch"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("OurAM_Api.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("OurAM_Api.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OurAM_Api.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("OurAM_Api.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OurAM_Api.Models.Anime", b =>
                {
                    b.HasOne("OurAM_Api.Models.AnimeStatus", "AnimeStatus")
                        .WithMany("Anime")
                        .HasForeignKey("AnimeStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OurAM_Api.Models.AnimeType", "AnimeType")
                        .WithMany("Anime")
                        .HasForeignKey("AnimeTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OurAM_Api.Models.Genre", "Genre")
                        .WithMany("Anime")
                        .HasForeignKey("GenreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OurAM_Api.Models.Studio", "Studio")
                        .WithMany("Anime")
                        .HasForeignKey("StudioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AnimeStatus");

                    b.Navigation("AnimeType");

                    b.Navigation("Genre");

                    b.Navigation("Studio");
                });

            modelBuilder.Entity("OurAM_Api.Models.UserAnimeList", b =>
                {
                    b.HasOne("OurAM_Api.Models.Anime", "Anime")
                        .WithMany("UserAnimeLists")
                        .HasForeignKey("AnimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OurAM_Api.Models.UserAnimeStatus", "UserAnimeStatus")
                        .WithMany("UserAnimeLists")
                        .HasForeignKey("UserAnimeStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OurAM_Api.Models.User", "User")
                        .WithMany("UserAnimeLists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Anime");

                    b.Navigation("User");

                    b.Navigation("UserAnimeStatus");
                });

            modelBuilder.Entity("OurAM_Api.Models.Anime", b =>
                {
                    b.Navigation("UserAnimeLists");
                });

            modelBuilder.Entity("OurAM_Api.Models.AnimeStatus", b =>
                {
                    b.Navigation("Anime");
                });

            modelBuilder.Entity("OurAM_Api.Models.AnimeType", b =>
                {
                    b.Navigation("Anime");
                });

            modelBuilder.Entity("OurAM_Api.Models.Genre", b =>
                {
                    b.Navigation("Anime");
                });

            modelBuilder.Entity("OurAM_Api.Models.Studio", b =>
                {
                    b.Navigation("Anime");
                });

            modelBuilder.Entity("OurAM_Api.Models.User", b =>
                {
                    b.Navigation("UserAnimeLists");
                });

            modelBuilder.Entity("OurAM_Api.Models.UserAnimeStatus", b =>
                {
                    b.Navigation("UserAnimeLists");
                });
#pragma warning restore 612, 618
        }
    }
}
