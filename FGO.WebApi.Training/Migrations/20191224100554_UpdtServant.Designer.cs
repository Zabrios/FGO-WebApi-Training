﻿// <auto-generated />
using System;
using System.ComponentModel.DataAnnotations.Schema;
using FGO.WebApi.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FGO.WebApi.Training.Migrations
{
    [DbContext(typeof(FGOContext))]
    [Migration("20191224100554_UpdtServant")]
    partial class UpdtServant
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FGO.WebApi.Domain.Entities.Models.AliasModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ServantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServantId");

                    b.ToTable("Aliases");
                });

            modelBuilder.Entity("FGO.WebApi.Domain.Entities.Models.AscensionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("ServantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServantId");

                    b.ToTable("Ascensions");
                });

            modelBuilder.Entity("FGO.WebApi.Domain.Entities.Models.ServantBaseModel", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int")
                        .HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.None);

                    b.Property<int>("AtkLv1")
                        .HasColumnType("int");

                    b.Property<int>("AtkLv100")
                        .HasColumnType("int");

                    b.Property<int>("AtkMaxLv")
                        .HasColumnType("int");

                    b.Property<string>("CommandCards")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<int>("HpLv1")
                        .HasColumnType("int");

                    b.Property<int>("HpLv100")
                        .HasColumnType("int");

                    b.Property<int>("HpMaxLv")
                        .HasColumnType("int");

                    b.Property<int>("MaxLvl")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RarityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RarityNum")
                        .HasColumnType("int");

                    b.Property<string>("ServantClass")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Servants");
                });

            modelBuilder.Entity("FGO.WebApi.Domain.Entities.Models.AliasModel", b =>
                {
                    b.HasOne("FGO.WebApi.Domain.Entities.Models.ServantBaseModel", "Servant")
                        .WithMany("Aliases")
                        .HasForeignKey("ServantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FGO.WebApi.Domain.Entities.Models.AscensionModel", b =>
                {
                    b.HasOne("FGO.WebApi.Domain.Entities.Models.ServantBaseModel", "Servant")
                        .WithMany("Ascensions")
                        .HasForeignKey("ServantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
