using System;
using Microsoft.EntityFrameworkCore;
using Primero.App.Dominio;
namespace Primero.App.Persistencia
{
    public class AppContext:DbContext
    {
        public DbSet<Persona> Personas{get;set;}
        public DbSet<Administrador> Administradores{get;set;}
        public DbSet<Coordinador> Coordinadores{get;set;}
        public DbSet<DatoMeteorologico> DatoMeteorologicos{get;set;}
        public DbSet<Estacion> Estaciones{get;set;}
        public DbSet<Tecnico> Tecnicos{get;set;}
        public DbSet<Reporte> Reportes{get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DB54_2");
            }
        }
    }
}