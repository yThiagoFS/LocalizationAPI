﻿// <auto-generated />
using System;
using Localization.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Localization.Infra.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231118141846_v1")]
    partial class v1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Localization.Domain.Entities.Localization", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("DATETIME");

                    b.HasKey("Id");

                    b.ToTable("Localizations");
                });

            modelBuilder.Entity("Localization.Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Localization.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("DATETIME");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UserRole", b =>
                {
                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("Localization.Domain.Entities.Localization", b =>
                {
                    b.OwnsOne("Localization.Domain.ValueObjects.Name", "AddedBy", b1 =>
                        {
                            b1.Property<Guid>("LocalizationId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(60)
                                .HasColumnType("VARCHAR")
                                .HasColumnName("AddedBy");

                            b1.HasKey("LocalizationId");

                            b1.ToTable("Localizations");

                            b1.WithOwner()
                                .HasForeignKey("LocalizationId");
                        });

                    b.OwnsOne("Localization.Domain.ValueObjects.Name", "UpdatedBy", b1 =>
                        {
                            b1.Property<Guid>("LocalizationId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .HasMaxLength(60)
                                .HasColumnType("VARCHAR")
                                .HasColumnName("UpdatedBy");

                            b1.HasKey("LocalizationId");

                            b1.ToTable("Localizations");

                            b1.WithOwner()
                                .HasForeignKey("LocalizationId");
                        });

                    b.OwnsOne("Localization.Domain.ValueObjects.IBGECode", "IBGECode", b1 =>
                        {
                            b1.Property<Guid>("LocalizationId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Code")
                                .IsRequired()
                                .HasMaxLength(8)
                                .HasColumnType("VARCHAR")
                                .HasColumnName("IbgeCode");

                            b1.HasKey("LocalizationId");

                            b1.ToTable("Localizations");

                            b1.WithOwner()
                                .HasForeignKey("LocalizationId");
                        });

                    b.OwnsOne("Localization.Domain.ValueObjects.State", "State", b1 =>
                        {
                            b1.Property<Guid>("LocalizationId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Acronym")
                                .IsRequired()
                                .HasMaxLength(2)
                                .HasColumnType("VARCHAR")
                                .HasColumnName("State");

                            b1.HasKey("LocalizationId");

                            b1.ToTable("Localizations");

                            b1.WithOwner()
                                .HasForeignKey("LocalizationId");
                        });

                    b.OwnsOne("Localization.Domain.ValueObjects.ZipCode", "ZipCode", b1 =>
                        {
                            b1.Property<Guid>("LocalizationId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Code")
                                .IsRequired()
                                .HasMaxLength(8)
                                .HasColumnType("VARCHAR")
                                .HasColumnName("ZipCode");

                            b1.HasKey("LocalizationId");

                            b1.ToTable("Localizations");

                            b1.WithOwner()
                                .HasForeignKey("LocalizationId");
                        });

                    b.Navigation("AddedBy")
                        .IsRequired();

                    b.Navigation("IBGECode")
                        .IsRequired();

                    b.Navigation("State")
                        .IsRequired();

                    b.Navigation("UpdatedBy");

                    b.Navigation("ZipCode")
                        .IsRequired();
                });

            modelBuilder.Entity("Localization.Domain.Entities.User", b =>
                {
                    b.OwnsOne("Localization.Domain.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(60)
                                .HasColumnType("VARCHAR")
                                .HasColumnName("Name");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Localization.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("NVARCHAR")
                                .HasColumnName("Email");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Localization.Domain.ValueObjects.Password", "Password", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("NVARCHAR");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Name")
                        .IsRequired();

                    b.Navigation("Password")
                        .IsRequired();
                });

            modelBuilder.Entity("UserRole", b =>
                {
                    b.HasOne("Localization.Domain.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_UserRole_RoleId");

                    b.HasOne("Localization.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_UserRole_UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
