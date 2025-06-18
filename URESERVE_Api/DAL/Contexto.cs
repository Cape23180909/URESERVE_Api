using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace URESERVE_Api.DAL;

public class Contexto :DbContext
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
}