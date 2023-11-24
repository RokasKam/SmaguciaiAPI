﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmaguciaiInfrastructure.Data;

#nullable disable

namespace SmaguciaiInfrastructure.Migrations
{
    [DbContext(typeof(SmaguciaiDataContext))]
    [Migration("20231117090837_CreateUserTable")]
    partial class CreateUserTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SmaguciaiDomain.Entities.Gender", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GenderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genders");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c726eaa8-0a41-413d-8e29-a904e0ffbc47"),
                            GenderName = "Man"
                        },
                        new
                        {
                            Id = new Guid("a9f5eeca-beaa-4c2b-982c-30b8eb330a1a"),
                            GenderName = "Women"
                        },
                        new
                        {
                            Id = new Guid("b81d6893-6578-4499-bcfa-bf2f21da8022"),
                            GenderName = "Unisex"
                        },
                        new
                        {
                            Id = new Guid("7d7519ee-4c6f-4fb2-8540-cc60a2f08eb3"),
                            GenderName = "Man"
                        },
                        new
                        {
                            Id = new Guid("252f7fbf-2234-4791-965f-8bf7338e78ce"),
                            GenderName = "Women"
                        },
                        new
                        {
                            Id = new Guid("f6465369-14c0-4749-969b-e6f74f8e6824"),
                            GenderName = "Unisex"
                        },
                        new
                        {
                            Id = new Guid("f980a88a-f203-4a71-bc93-2e3bd8e726eb"),
                            GenderName = "Man"
                        },
                        new
                        {
                            Id = new Guid("edcfa76f-fe40-40c7-8548-d4f1fcd80cdd"),
                            GenderName = "Women"
                        },
                        new
                        {
                            Id = new Guid("fd91919f-b541-4d6e-adbc-0aa133afa70c"),
                            GenderName = "Unisex"
                        });
                });

            modelBuilder.Entity("SmaguciaiDomain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("10f3984e-67e8-4645-bd67-37363b85c5f2"),
                            RoleName = "Admin"
                        },
                        new
                        {
                            Id = new Guid("46c58d37-0df8-4ee1-8088-e2a59dca40c7"),
                            RoleName = "User"
                        },
                        new
                        {
                            Id = new Guid("f4ad230a-9506-4324-81c4-86b0db74dbf8"),
                            RoleName = "Admin"
                        },
                        new
                        {
                            Id = new Guid("cfb5ed38-27cd-4775-8614-9f79ae9485be"),
                            RoleName = "User"
                        },
                        new
                        {
                            Id = new Guid("975a0140-9910-4bb8-81a9-ea9d525e62f2"),
                            RoleName = "Admin"
                        },
                        new
                        {
                            Id = new Guid("5edc5605-e40e-40bf-8a87-be929863ed5b"),
                            RoleName = "User"
                        });
                });

            modelBuilder.Entity("SmaguciaiDomain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("GenderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReviewCount")
                        .HasColumnType("int");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SmaguciaiDomain.Entities.User", b =>
                {
                    b.HasOne("SmaguciaiDomain.Entities.Gender", "Gender")
                        .WithMany("Users")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmaguciaiDomain.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gender");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("SmaguciaiDomain.Entities.Gender", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("SmaguciaiDomain.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
