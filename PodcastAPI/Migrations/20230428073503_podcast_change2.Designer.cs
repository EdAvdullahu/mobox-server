﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PodcastAPI.DbContexts;

#nullable disable

namespace PodcastAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230428073503_podcast_change2")]
    partial class podcast_change2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ArtistPodcast", b =>
                {
                    b.Property<int>("FeaturedId")
                        .HasColumnType("int");

                    b.Property<int>("PodcastsId")
                        .HasColumnType("int");

                    b.HasKey("FeaturedId", "PodcastsId");

                    b.HasIndex("PodcastsId");

                    b.ToTable("ArtistPodcast");
                });

            modelBuilder.Entity("PodcastAPI.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("PodcastAPI.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("PodcastAPI.Models.Podcast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CloudanaryPublicId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CloudanaryPublicMp3Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("Length")
                        .HasColumnType("time");

                    b.Property<string>("Mp3Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PodcasterId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Podcasts");
                });

            modelBuilder.Entity("PodcastAPI.Models.PodcastGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("PodcastId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("PodcastId");

                    b.ToTable("PodcastGenre");
                });

            modelBuilder.Entity("ArtistPodcast", b =>
                {
                    b.HasOne("PodcastAPI.Models.Artist", null)
                        .WithMany()
                        .HasForeignKey("FeaturedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PodcastAPI.Models.Podcast", null)
                        .WithMany()
                        .HasForeignKey("PodcastsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PodcastAPI.Models.PodcastGenre", b =>
                {
                    b.HasOne("PodcastAPI.Models.Genre", "Genre")
                        .WithMany("Podcasts")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PodcastAPI.Models.Podcast", "Podcast")
                        .WithMany("Genres")
                        .HasForeignKey("PodcastId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Podcast");
                });

            modelBuilder.Entity("PodcastAPI.Models.Genre", b =>
                {
                    b.Navigation("Podcasts");
                });

            modelBuilder.Entity("PodcastAPI.Models.Podcast", b =>
                {
                    b.Navigation("Genres");
                });
#pragma warning restore 612, 618
        }
    }
}
