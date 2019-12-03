using Datos.Migrations;
using System.Data.Entity;
using SqlProviderServices = System.Data.Entity.SqlServer.SqlProviderServices;

namespace Datos
{
    public class GimnasioContext : DbContext
    {
        
        public GimnasioContext() : base("GimnasioContext")
        {
            Database.SetInitializer<GimnasioContext>(
            new MigrateDatabaseToLatestVersion<GimnasioContext, Configuration>());

        }

        public DbSet<Calentamiento> Calentamientos { get; set; }
        public DbSet<Calle> Calles { get; set; }
        public DbSet<Cardio> Cardios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cobranza> Cobranzas { get; set; }
        public DbSet<Control_Ingreso> Control_Ingresos { get; set; }
        public DbSet<Detalle_Cobranza> Detalle_Cobranzas { get; set; }
        public DbSet<Domicilio> Domicilios { get; set; }
        public DbSet<Ejercicio> Ejercicios { get; set; }
        public DbSet<Localidad> Localidads { get; set; }
        public DbSet<Rutina> Rutinas { get; set; }
        public DbSet<Telefono> Telefonos { get; set; }
        public DbSet<Tipo_Calentamiento> Tipos_Calentamientos { get; set; }
        public DbSet<Tipo_Rutina> Tipos_Rutinas { get; set; }
        public DbSet<Tipo_Telefono> Tipos_Telefonos { get; set; }
        public DbSet<Tipo_Usuario> Tipos_Usuarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}


