﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StaffPortal.Server.Data;

#nullable disable

namespace StaffPortal.Server.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240717153459_seeddata")]
    partial class seeddata
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("StaffPortal.Server.Models.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Gender", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Male"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Female"
                        });
                });

            modelBuilder.Entity("StaffPortal.Server.Models.Qualification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Qualification", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Diploma",
                            Level = 5
                        },
                        new
                        {
                            Id = 2,
                            Description = "Degree",
                            Level = 6
                        },
                        new
                        {
                            Id = 3,
                            Description = "Post Graduate",
                            Level = 7
                        },
                        new
                        {
                            Id = 4,
                            Description = "Master’s Degree",
                            Level = 8
                        });
                });

            modelBuilder.Entity("StaffPortal.Server.Models.Staff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmployeeNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QualificationId")
                        .HasColumnType("int");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("YearsOfWorkExperience")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.HasIndex("QualificationId");

                    b.ToTable("Staff", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfBirth = new DateTime(1985, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeNumber = "EMP001",
                            FirstName = "John",
                            GenderId = 1,
                            LastName = "Doe",
                            QualificationId = 2,
                            Salary = 0m,
                            YearsOfWorkExperience = 5
                        },
                        new
                        {
                            Id = 2,
                            DateOfBirth = new DateTime(1990, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeNumber = "EMP002",
                            FirstName = "Jane",
                            GenderId = 2,
                            LastName = "Smith",
                            QualificationId = 3,
                            Salary = 0m,
                            YearsOfWorkExperience = 3
                        });
                });

            modelBuilder.Entity("StaffPortal.Server.Models.Staff", b =>
                {
                    b.HasOne("StaffPortal.Server.Models.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StaffPortal.Server.Models.Qualification", "Qualification")
                        .WithMany()
                        .HasForeignKey("QualificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gender");

                    b.Navigation("Qualification");
                });
#pragma warning restore 612, 618
        }
    }
}
