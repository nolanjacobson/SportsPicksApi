﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SportsPicksApi.Models;

namespace SportsPicksApi.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20200111192720_CorrectedDescriptiontypo")]
    partial class CorrectedDescriptiontypo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("SportsPicksApi.Models.NewGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Sport")
                        .HasColumnType("text");

                    b.Property<string>("TeamOne")
                        .HasColumnType("text");

                    b.Property<string>("TeamTwo")
                        .HasColumnType("text");

                    b.Property<string>("WinningTeam")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("NewGame");
                });
#pragma warning restore 612, 618
        }
    }
}
