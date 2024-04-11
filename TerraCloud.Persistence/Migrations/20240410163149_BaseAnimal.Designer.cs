﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TerraCloud.Persistence.Contexts;

#nullable disable

namespace TerraCloud.Persistence.Migrations
{
    [DbContext(typeof(TerraCloudContext))]
    [Migration("20240410163149_BaseAnimal")]
    partial class BaseAnimal
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TerraCloud.Domain.Models.Animal.Animal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int?>("DayHumidity")
                        .HasColumnType("integer")
                        .HasComment("Wilgotność w dzień");

                    b.Property<int?>("DayTemperature")
                        .HasColumnType("integer")
                        .HasComment("Temperatura w dzień");

                    b.Property<int?>("NightHumidity")
                        .HasColumnType("integer")
                        .HasComment("Wilgotność w nocy");

                    b.Property<int?>("NightTemperature")
                        .HasColumnType("integer")
                        .HasComment("Temperatura w nocy");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasComment("Gatunek zwierzęcia");

                    b.HasKey("Id");

                    b.ToTable("Animal", (string)null);
                });

            modelBuilder.Entity("TerraCloud.Domain.Models.Device.Device", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasComment("Nazwa urządzenia");

                    b.HasKey("Id");

                    b.ToTable("Device", (string)null);
                });

            modelBuilder.Entity("TerraCloud.Domain.Models.Device.UserDevice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("DeviceId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.HasIndex("UserId");

                    b.ToTable("UserDevice", (string)null);
                });

            modelBuilder.Entity("TerraCloud.Domain.Models.User.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasComment("Email");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasComment("Nazwisko");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasComment("Login");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasComment("Imię");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasComment("Hasło");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasComment("Sól do szyfrowania hasła");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Login")
                        .IsUnique();

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("TerraCloud.Domain.Models.Device.UserDevice", b =>
                {
                    b.HasOne("TerraCloud.Domain.Models.Device.Device", "Device")
                        .WithMany("UserDevices")
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TerraCloud.Domain.Models.User.User", "User")
                        .WithMany("UserDevices")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TerraCloud.Domain.Models.Device.Device", b =>
                {
                    b.Navigation("UserDevices");
                });

            modelBuilder.Entity("TerraCloud.Domain.Models.User.User", b =>
                {
                    b.Navigation("UserDevices");
                });
#pragma warning restore 612, 618
        }
    }
}
