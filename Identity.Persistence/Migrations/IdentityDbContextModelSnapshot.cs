﻿// <auto-generated />
using System;
using Identity.Persistence.DataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Identity.Persistence.Migrations
{
    [DbContext(typeof(IdentityDbContext))]
    partial class IdentityDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Identity.Domain.Entities.AccessToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsRevoked")
                        .HasColumnType("boolean");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("AccessTokens");
                });

            modelBuilder.Entity("Identity.Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("DisAbled")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Type")
                        .IsUnique();

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9496766e-0d40-42e3-8a28-e43680854ce1"),
                            CreatedTime = new DateTime(2023, 11, 13, 4, 11, 13, 457, DateTimeKind.Utc).AddTicks(2559),
                            DisAbled = false,
                            ModifiedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = 2
                        },
                        new
                        {
                            Id = new Guid("7ad89a3c-b151-4e82-9f9d-c33c35ce9c75"),
                            CreatedTime = new DateTime(2023, 11, 13, 4, 11, 13, 457, DateTimeKind.Utc).AddTicks(2564),
                            DisAbled = false,
                            ModifiedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("9cc6c7bd-60ac-462a-918a-3a7b5e48de4e"),
                            CreatedTime = new DateTime(2023, 11, 13, 4, 11, 13, 457, DateTimeKind.Utc).AddTicks(2567),
                            DisAbled = false,
                            ModifiedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = 0
                        });
                });

            modelBuilder.Entity("Identity.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsEmailAddressverified")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7af84dc0-a713-40f8-8f6b-8b67cb545215"),
                            Age = 0,
                            EmailAddress = "dfsgh",
                            FirstName = "Admin",
                            IsEmailAddressverified = true,
                            LastName = "Admin",
                            PasswordHash = "fdsg",
                            RoleId = new Guid("9496766e-0d40-42e3-8a28-e43680854ce1")
                        });
                });

            modelBuilder.Entity("Identity.Domain.Entities.AccessToken", b =>
                {
                    b.HasOne("Identity.Domain.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("Identity.Domain.Entities.AccessToken", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Identity.Domain.Entities.User", b =>
                {
                    b.HasOne("Identity.Domain.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
