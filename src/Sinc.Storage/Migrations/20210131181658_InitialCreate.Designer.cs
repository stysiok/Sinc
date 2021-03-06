﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Sinc.Storage.Postgres;

namespace Sinc.Storage.Migrations
{
    [DbContext(typeof(SincContext))]
    [Migration("20210131181658_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Sinc.Storage.Models.StoredPlaylist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SpotifyId");

                    b.HasKey("Id");

                    b.ToTable("Playlists");
                });

            modelBuilder.Entity("Sinc.Storage.Models.StoredSong", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SpotifyId");

                    b.Property<int?>("StoredPlaylistId");

                    b.HasKey("Id");

                    b.HasIndex("StoredPlaylistId");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("Sinc.Storage.Models.StoredSong", b =>
                {
                    b.HasOne("Sinc.Storage.Models.StoredPlaylist")
                        .WithMany("Songs")
                        .HasForeignKey("StoredPlaylistId");
                });
#pragma warning restore 612, 618
        }
    }
}
