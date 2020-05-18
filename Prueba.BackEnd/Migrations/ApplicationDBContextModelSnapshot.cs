﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Prueba.BackEnd.Data;

namespace Prueba.BackEnd.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Prueba.BackEnd.Models.Persona", b =>
                {
                    b.Property<int>("IntId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NroDocumento")
                        .HasColumnType("int");

                    b.Property<string>("TipoDocumento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IntId");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("Prueba.BackEnd.Models.Premios", b =>
                {
                    b.Property<int>("intId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("intId");

                    b.ToTable("Premios");
                });
#pragma warning restore 612, 618
        }
    }
}
