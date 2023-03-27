﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Primero.App.Persistencia;

namespace Primero.App.Persistencia.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20220831114124_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Primero.App.Dominio.DatoMeteorologico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("FechaHora")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Valor")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("DatoMeteorologicos");
                });

            modelBuilder.Entity("Primero.App.Dominio.Estacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DatoId")
                        .HasColumnType("int");

                    b.Property<string>("Departamento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaMontaje")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Latitud")
                        .HasColumnType("real");

                    b.Property<float>("Longitud")
                        .HasColumnType("real");

                    b.Property<string>("Municipio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonalMonitoreoId")
                        .HasColumnType("int");

                    b.Property<int?>("ReporteId")
                        .HasColumnType("int");

                    b.Property<int?>("TecnicoMantenimientoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DatoId");

                    b.HasIndex("PersonalMonitoreoId");

                    b.HasIndex("ReporteId");

                    b.HasIndex("TecnicoMantenimientoId");

                    b.ToTable("Estaciones");
                });

            modelBuilder.Entity("Primero.App.Dominio.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cedula")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Personas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");
                });

            modelBuilder.Entity("Primero.App.Dominio.Reporte", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Reportes");
                });

            modelBuilder.Entity("Primero.App.Dominio.Administrador", b =>
                {
                    b.HasBaseType("Primero.App.Dominio.Persona");

                    b.Property<int>("Password")
                        .HasColumnType("int")
                        .HasColumnName("Administrador_Password");

                    b.Property<string>("Roll")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Administrador_Roll");

                    b.HasDiscriminator().HasValue("Administrador");
                });

            modelBuilder.Entity("Primero.App.Dominio.Coordinador", b =>
                {
                    b.HasBaseType("Primero.App.Dominio.Persona");

                    b.Property<int>("Password")
                        .HasColumnType("int");

                    b.Property<string>("Roll")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Coordinador");
                });

            modelBuilder.Entity("Primero.App.Dominio.Tecnico", b =>
                {
                    b.HasBaseType("Primero.App.Dominio.Persona");

                    b.Property<string>("TarjetaProfesional")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Tecnico");
                });

            modelBuilder.Entity("Primero.App.Dominio.Estacion", b =>
                {
                    b.HasOne("Primero.App.Dominio.DatoMeteorologico", "Dato")
                        .WithMany()
                        .HasForeignKey("DatoId");

                    b.HasOne("Primero.App.Dominio.Coordinador", "PersonalMonitoreo")
                        .WithMany()
                        .HasForeignKey("PersonalMonitoreoId");

                    b.HasOne("Primero.App.Dominio.Reporte", "Reporte")
                        .WithMany()
                        .HasForeignKey("ReporteId");

                    b.HasOne("Primero.App.Dominio.Tecnico", "TecnicoMantenimiento")
                        .WithMany()
                        .HasForeignKey("TecnicoMantenimientoId");

                    b.Navigation("Dato");

                    b.Navigation("PersonalMonitoreo");

                    b.Navigation("Reporte");

                    b.Navigation("TecnicoMantenimiento");
                });
#pragma warning restore 612, 618
        }
    }
}
