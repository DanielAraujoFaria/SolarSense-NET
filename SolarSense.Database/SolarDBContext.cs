using Microsoft.EntityFrameworkCore;
using SolarSense.Database.Mappings;
using SolarSense.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable CS1591
public class SolarDBContext : DbContext
{
    public DbSet<Painel> Paineis { get; set; }
    public DbSet<ProducaoPainel> Producoes { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    public SolarDBContext(DbContextOptions<SolarDBContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PainelMapping());
        modelBuilder.ApplyConfiguration(new ProducaoPainelMapping());
        modelBuilder.ApplyConfiguration(new UsuarioMapping());

        base.OnModelCreating(modelBuilder);
    }
}
#pragma warning restore CS1591