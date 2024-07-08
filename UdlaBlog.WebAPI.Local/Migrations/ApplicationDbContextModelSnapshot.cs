﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UdlaBlog.Infrastructure.Data;

#nullable disable

namespace UdlaBlog.WebAPI.Local.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UdlaBlog.Domain.Entities.BlogFica", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Contenido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BlogFicas");
                });

            modelBuilder.Entity("UdlaBlog.Domain.Entities.BlogNodo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Contenido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BlogNodos");
                });

            modelBuilder.Entity("UdlaBlog.Domain.Entities.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BlogFicaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BlogNodoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Contenido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BlogFicaId");

                    b.HasIndex("BlogNodoId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("UdlaBlog.Domain.Entities.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Username");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UdlaBlog.Domain.Entities.Comment", b =>
                {
                    b.HasOne("UdlaBlog.Domain.Entities.BlogFica", "BlogFica")
                        .WithMany("Comments")
                        .HasForeignKey("BlogFicaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UdlaBlog.Domain.Entities.BlogNodo", "BlogNodo")
                        .WithMany("Comments")
                        .HasForeignKey("BlogNodoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("BlogFica");

                    b.Navigation("BlogNodo");
                });

            modelBuilder.Entity("UdlaBlog.Domain.Entities.BlogFica", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("UdlaBlog.Domain.Entities.BlogNodo", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
