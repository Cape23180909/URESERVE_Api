using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace URESERVE_Api.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<Usuarios> Usuarios { get; set; }
    public DbSet<Estudiantes> Estudiantes { get; set; }
    public DbSet<TipoCargo> TiposCargo { get; set; }
    public DbSet<Reservaciones> Reservaciones { get; set; }
    public DbSet<Proyectores> Proyectores { get; set; }
    public DbSet<DetalleReservaProyector> DetallesReservaProyectores { get; set; }
    public DbSet<Cubiculos> Cubiculos { get; set; }
    public DbSet<DetalleReservaCubiculo> DetallesReservaCubiculos { get; set; }
    public DbSet<Laboratorios> Laboratorios { get; set; }
    public DbSet<DetalleReservaLaboratorio> DetallesReservaLaboratorios { get; set; }
    public DbSet<Restaurantes> Restaurantes { get; set; }
    public DbSet<DetalleReservaRestaurante> DetallesReservaRestaurantes { get; set; }
    public DbSet<Reportes> Reportes { get; set; }
    public DbSet<TarjetaCredito> TarjetaCredito { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Precargar 10 cubículos fijos
        modelBuilder.Entity<Cubiculos>().HasData(new List<Cubiculos>()
    {
        new Cubiculos() { CubiculoId = 1, Nombre = "Cubículo 1", Disponible = true },
        new Cubiculos() { CubiculoId = 2, Nombre = "Cubículo 2", Disponible = true },
        new Cubiculos() { CubiculoId = 3, Nombre = "Cubículo 3", Disponible = true },
        new Cubiculos() { CubiculoId = 4, Nombre = "Cubículo 4", Disponible = true },
        new Cubiculos() { CubiculoId = 5, Nombre = "Cubículo 5", Disponible = true },
        new Cubiculos() { CubiculoId = 6, Nombre = "Cubículo 6", Disponible = true },
        new Cubiculos() { CubiculoId = 7, Nombre = "Cubículo 7", Disponible = true },
        new Cubiculos() { CubiculoId = 8, Nombre = "Cubículo 8", Disponible = false },
        new Cubiculos() { CubiculoId = 9, Nombre = "Cubículo 9", Disponible = true },
        new Cubiculos() { CubiculoId = 10, Nombre = "Cubículo 10", Disponible = false }
    });

        modelBuilder.Entity<Laboratorios>().HasData(new List<Laboratorios>()
    {
        new Laboratorios() { LaboratorioId = 1, Nombre = "Laboratorio A", Disponible = true },
        new Laboratorios() { LaboratorioId = 2, Nombre = "Laboratorio B", Disponible = true },
        new Laboratorios() { LaboratorioId = 3, Nombre = "Laboratorio C", Disponible = true },
        new Laboratorios() { LaboratorioId = 4, Nombre = "Laboratorio D", Disponible = true },
        new Laboratorios() { LaboratorioId = 5, Nombre = "Laboratorio E", Disponible = true }
    });

        modelBuilder.Entity<Proyectores>().HasData(new List<Proyectores>()
    {
        new Proyectores() {
            ProyectorId = 1,
            Nombre = "Proyector Epson EB-X41",
            Cantidad = 5,
            Conectividad = "HDMI, VGA",
            Disponible = true
        },
        new Proyectores() {
            ProyectorId = 2,
            Nombre = "Proyector BenQ MW632",
            Cantidad = 3,
            Conectividad = "HDMI, USB, Wireless",
             Disponible = true
        },
        new Proyectores() {
            ProyectorId = 3,
            Nombre = "Proyector Sony VPL-DX120",
            Cantidad = 2,
            Conectividad = "HDMI, VGA, LAN",
             Disponible = true
        },
        new Proyectores() {
            ProyectorId = 4,
            Nombre = "Proyector Optoma X341",
            Cantidad = 4,
            Conectividad = "HDMI, VGA, USB",
             Disponible = true
        }
    });
        modelBuilder.Entity<Restaurantes>().HasData(
      new Restaurantes
      {
          RestauranteId = 1,
          Nombre = " SalaVIP",
          Ubicacion = "Edificio Principal, Primer Piso",
          Capacidad = 15,
          Telefono = "809-555-1001",
          Correo = "salavip@universidad.edu",
          Descripcion = "Área exclusiva para comidas ejecutivas y reuniones privadas",
          Disponible = true
      },
      new Restaurantes
      {
          RestauranteId = 2,
          Nombre = "SalaReuniones",
          Ubicacion = "Edificio Administrativo, Segundo Piso",
          Capacidad = 35,
          Telefono = "809-555-1002",
          Correo = "salareuniones@universidad.edu",
          Descripcion = "Espacio amplio para reuniones de equipo con servicio de catering",
          Disponible = true
      },
      new Restaurantes
      {
          RestauranteId = 3,
          Nombre = "Restaurante",
          Ubicacion = "Edificio Comedor Central, Planta Baja",
          Capacidad = 15,
          Telefono = "809-555-1003",
          Correo = "restaurante@universidad.edu",
          Descripcion = "Comedor principal con variedad de opciones gastronómicas",
          Disponible = true
      }
  );
    }
}