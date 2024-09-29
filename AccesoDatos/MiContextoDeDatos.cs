using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace ProyectoC.AccesoDatos
{
    public class MiContextoDeDatos : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ProyectoConsolaDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configura TPT para cada tipo derivado, para que las tablas herencia se creen en la BD
            modelBuilder.Entity<ClienteDatos>().ToTable("Clientes");
            modelBuilder.Entity<VendedorDatos>().ToTable("Vendedores");
        }

        // Define los DbSets aquí para las operaciones CRUD sobre las entidades
        public DbSet<PersonaDatos> Personas { get; set; }
        public DbSet<ClienteDatos> Clientes { get; set; }
        public DbSet<VendedorDatos> Vendedores { get; set; }
        public DbSet<EmpresaDatos> Empresas { get; set; }
        public DbSet<FacturaDatos> Facturas { get; set; }
        public DbSet<ProductoDatos> Productos { get; set; }
        public DbSet<ProductosPorFacturaDatos> ProductosPorFactura { get; set; }
    }
}