﻿// <auto-generated />
using System;
using DemoApp.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DemoApp.Backend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240716135303_InitialMigrations")]
    partial class InitialMigrations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DemoApp.Backend.Models.WeatherForecast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Summary")
                        .HasColumnType("text");

                    b.Property<int>("TemperatureC")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("WeatherForecasts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateOnly(2024, 7, 16),
                            Summary = "Mild",
                            TemperatureC = 13
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateOnly(2024, 7, 17),
                            Summary = "Hot",
                            TemperatureC = 47
                        },
                        new
                        {
                            Id = 3,
                            Date = new DateOnly(2024, 7, 18),
                            Summary = "Balmy",
                            TemperatureC = 30
                        },
                        new
                        {
                            Id = 4,
                            Date = new DateOnly(2024, 7, 19),
                            Summary = "Freezing",
                            TemperatureC = -4
                        },
                        new
                        {
                            Id = 5,
                            Date = new DateOnly(2024, 7, 20),
                            Summary = "Warm",
                            TemperatureC = 4
                        },
                        new
                        {
                            Id = 6,
                            Date = new DateOnly(2024, 7, 21),
                            Summary = "Bracing",
                            TemperatureC = -8
                        },
                        new
                        {
                            Id = 7,
                            Date = new DateOnly(2024, 7, 22),
                            Summary = "Sweltering",
                            TemperatureC = 5
                        },
                        new
                        {
                            Id = 8,
                            Date = new DateOnly(2024, 7, 23),
                            Summary = "Bracing",
                            TemperatureC = -9
                        },
                        new
                        {
                            Id = 9,
                            Date = new DateOnly(2024, 7, 24),
                            Summary = "Balmy",
                            TemperatureC = 0
                        },
                        new
                        {
                            Id = 10,
                            Date = new DateOnly(2024, 7, 25),
                            Summary = "Scorching",
                            TemperatureC = 2
                        },
                        new
                        {
                            Id = 11,
                            Date = new DateOnly(2024, 7, 26),
                            Summary = "Bracing",
                            TemperatureC = 27
                        },
                        new
                        {
                            Id = 12,
                            Date = new DateOnly(2024, 7, 27),
                            Summary = "Scorching",
                            TemperatureC = 52
                        },
                        new
                        {
                            Id = 13,
                            Date = new DateOnly(2024, 7, 28),
                            Summary = "Cool",
                            TemperatureC = 25
                        },
                        new
                        {
                            Id = 14,
                            Date = new DateOnly(2024, 7, 29),
                            Summary = "Freezing",
                            TemperatureC = 19
                        },
                        new
                        {
                            Id = 15,
                            Date = new DateOnly(2024, 7, 30),
                            Summary = "Bracing",
                            TemperatureC = -12
                        },
                        new
                        {
                            Id = 16,
                            Date = new DateOnly(2024, 7, 31),
                            Summary = "Scorching",
                            TemperatureC = 11
                        },
                        new
                        {
                            Id = 17,
                            Date = new DateOnly(2024, 8, 1),
                            Summary = "Hot",
                            TemperatureC = 0
                        },
                        new
                        {
                            Id = 18,
                            Date = new DateOnly(2024, 8, 2),
                            Summary = "Freezing",
                            TemperatureC = 42
                        },
                        new
                        {
                            Id = 19,
                            Date = new DateOnly(2024, 8, 3),
                            Summary = "Hot",
                            TemperatureC = 53
                        },
                        new
                        {
                            Id = 20,
                            Date = new DateOnly(2024, 8, 4),
                            Summary = "Hot",
                            TemperatureC = 30
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
