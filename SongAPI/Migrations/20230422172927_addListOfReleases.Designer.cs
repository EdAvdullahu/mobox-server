﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SongAPI.DbContexts;

#nullable disable

namespace SongAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230422172927_addListOfReleases")]
    partial class addListOfReleases
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SongAPI.Models.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArtistId"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ArtistId");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("SongAPI.Models.Feature", b =>
                {
                    b.Property<int>("FeatureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeatureId"), 1L, 1);

                    b.Property<int>("ArtistID")
                        .HasColumnType("int");

                    b.Property<int>("FeatureRole")
                        .HasColumnType("int");

                    b.Property<int>("SongId")
                        .HasColumnType("int");

                    b.HasKey("FeatureId");

                    b.HasIndex("ArtistID");

                    b.HasIndex("SongId");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("SongAPI.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreId"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("SongAPI.Models.GenreSong", b =>
                {
                    b.Property<int>("SongGenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SongGenreId"), 1L, 1);

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("SongId")
                        .HasColumnType("int");

                    b.HasKey("SongGenreId");

                    b.HasIndex("GenreId");

                    b.HasIndex("SongId");

                    b.ToTable("GenreSong");
                });

            modelBuilder.Entity("SongAPI.Models.Release", b =>
                {
                    b.Property<int>("ReleaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReleaseId"), 1L, 1);

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReleaseType")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReleaseId");

                    b.HasIndex("ArtistId");

                    b.ToTable("Releases");
                });

            modelBuilder.Entity("SongAPI.Models.Song", b =>
                {
                    b.Property<int>("SongId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SongId"), 1L, 1);

                    b.Property<bool>("HasFeatures")
                        .HasColumnType("bit");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsExplicite")
                        .HasColumnType("bit");

                    b.Property<TimeSpan>("Length")
                        .HasColumnType("time");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ReleaseId")
                        .HasColumnType("int");

                    b.HasKey("SongId");

                    b.HasIndex("ReleaseId");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("SongAPI.Models.Feature", b =>
                {
                    b.HasOne("SongAPI.Models.Artist", "Artist")
                        .WithMany("Features")
                        .HasForeignKey("ArtistID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SongAPI.Models.Song", "Song")
                        .WithMany("Features")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Song");
                });

            modelBuilder.Entity("SongAPI.Models.GenreSong", b =>
                {
                    b.HasOne("SongAPI.Models.Genre", "Genre")
                        .WithMany("Songs")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SongAPI.Models.Song", "Song")
                        .WithMany("Genres")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Song");
                });

            modelBuilder.Entity("SongAPI.Models.Release", b =>
                {
                    b.HasOne("SongAPI.Models.Artist", "Artist")
                        .WithMany("Releases")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("SongAPI.Models.Song", b =>
                {
                    b.HasOne("SongAPI.Models.Release", "Release")
                        .WithMany("Songs")
                        .HasForeignKey("ReleaseId");

                    b.Navigation("Release");
                });

            modelBuilder.Entity("SongAPI.Models.Artist", b =>
                {
                    b.Navigation("Features");

                    b.Navigation("Releases");
                });

            modelBuilder.Entity("SongAPI.Models.Genre", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("SongAPI.Models.Release", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("SongAPI.Models.Song", b =>
                {
                    b.Navigation("Features");

                    b.Navigation("Genres");
                });
#pragma warning restore 612, 618
        }
    }
}
