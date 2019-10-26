﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Models;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20191002165229_SeedEmployeeMigration")]
    partial class SeedEmployeeMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication1.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Department")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Department = 2,
                            Email = "okoro1@gmail.com",
                            Name = "chris"
                        },
                        new
                        {
                            Id = 2,
                            Department = 2,
                            Email = "okoro2@gmail.com",
                            Name = "chris"
                        },
                        new
                        {
                            Id = 3,
                            Department = 2,
                            Email = "okoro3@gmail.com",
                            Name = "chris"
                        },
                        new
                        {
                            Id = 4,
                            Department = 2,
                            Email = "okoro4@gmail.com",
                            Name = "chris"
                        },
                        new
                        {
                            Id = 5,
                            Department = 2,
                            Email = "okoro5@gmail.com",
                            Name = "chris"
                        },
                        new
                        {
                            Id = 6,
                            Department = 2,
                            Email = "okoro6@gmail.com",
                            Name = "chris"
                        },
                        new
                        {
                            Id = 7,
                            Department = 2,
                            Email = "okoro7@gmail.com",
                            Name = "chris"
                        },
                        new
                        {
                            Id = 8,
                            Department = 2,
                            Email = "okoro8@gmail.com",
                            Name = "chris"
                        },
                        new
                        {
                            Id = 9,
                            Department = 2,
                            Email = "okoro9@gmail.com",
                            Name = "chris"
                        },
                        new
                        {
                            Id = 10,
                            Department = 2,
                            Email = "okoro10@gmail.com",
                            Name = "chris"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
