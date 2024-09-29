﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoC.AccesoDatos;

#nullable disable

namespace ProyectoC.Migrations
{
    [DbContext(typeof(MiContextoDeDatos))]
    [Migration("20240929025857_ProyectoConsolaDB")]
    partial class ProyectoConsolaDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProyectoC.AccesoDatos.EmpresaDatos", b =>
                {
                    b.Property<int>("EmpresaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmpresaId"));

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmpresaId");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("ProyectoC.AccesoDatos.FacturaDatos", b =>
                {
                    b.Property<int>("FacturaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FacturaId"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<long>("Numero")
                        .HasColumnType("bigint");

                    b.Property<int>("PersonaId")
                        .HasColumnType("int");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.HasKey("FacturaId");

                    b.HasIndex("PersonaId");

                    b.ToTable("Facturas");
                });

            modelBuilder.Entity("ProyectoC.AccesoDatos.PersonaDatos", b =>
                {
                    b.Property<int>("PersonaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonaId"));

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonaId");

                    b.ToTable("Personas");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("ProyectoC.AccesoDatos.ProductoDatos", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductoId"));

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<double>("ValorUnitario")
                        .HasColumnType("float");

                    b.HasKey("ProductoId");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("ProyectoC.AccesoDatos.ProductosPorFacturaDatos", b =>
                {
                    b.Property<int>("ProductosPorFacturaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductosPorFacturaId"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("FacturaId")
                        .HasColumnType("int");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<double>("Subtotal")
                        .HasColumnType("float");

                    b.HasKey("ProductosPorFacturaId");

                    b.HasIndex("FacturaId");

                    b.HasIndex("ProductoId");

                    b.ToTable("ProductosPorFactura");
                });

            modelBuilder.Entity("ProyectoC.AccesoDatos.ClienteDatos", b =>
                {
                    b.HasBaseType("ProyectoC.AccesoDatos.PersonaDatos");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<double>("Credito")
                        .HasColumnType("float");

                    b.ToTable("Clientes", (string)null);
                });

            modelBuilder.Entity("ProyectoC.AccesoDatos.VendedorDatos", b =>
                {
                    b.HasBaseType("ProyectoC.AccesoDatos.PersonaDatos");

                    b.Property<int>("Carne")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Vendedores", (string)null);
                });

            modelBuilder.Entity("ProyectoC.AccesoDatos.FacturaDatos", b =>
                {
                    b.HasOne("ProyectoC.AccesoDatos.PersonaDatos", "Persona")
                        .WithMany("Facturas")
                        .HasForeignKey("PersonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("ProyectoC.AccesoDatos.ProductosPorFacturaDatos", b =>
                {
                    b.HasOne("ProyectoC.AccesoDatos.FacturaDatos", "Factura")
                        .WithMany("ProductosPorFactura")
                        .HasForeignKey("FacturaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoC.AccesoDatos.ProductoDatos", "Producto")
                        .WithMany("ProductosPorFactura")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Factura");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("ProyectoC.AccesoDatos.ClienteDatos", b =>
                {
                    b.HasOne("ProyectoC.AccesoDatos.PersonaDatos", null)
                        .WithOne()
                        .HasForeignKey("ProyectoC.AccesoDatos.ClienteDatos", "PersonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProyectoC.AccesoDatos.VendedorDatos", b =>
                {
                    b.HasOne("ProyectoC.AccesoDatos.PersonaDatos", null)
                        .WithOne()
                        .HasForeignKey("ProyectoC.AccesoDatos.VendedorDatos", "PersonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProyectoC.AccesoDatos.FacturaDatos", b =>
                {
                    b.Navigation("ProductosPorFactura");
                });

            modelBuilder.Entity("ProyectoC.AccesoDatos.PersonaDatos", b =>
                {
                    b.Navigation("Facturas");
                });

            modelBuilder.Entity("ProyectoC.AccesoDatos.ProductoDatos", b =>
                {
                    b.Navigation("ProductosPorFactura");
                });
#pragma warning restore 612, 618
        }
    }
}