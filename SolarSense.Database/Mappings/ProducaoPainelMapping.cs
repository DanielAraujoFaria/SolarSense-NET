using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolarSense.Database.Models;
using System;

namespace SolarSense.Database.Mappings
{
    public class ProducaoPainelMapping : IEntityTypeConfiguration<ProducaoPainel>
    {
        public void Configure(EntityTypeBuilder<ProducaoPainel> builder)
        {
            // Nome da tabela
            builder
                .ToTable("T_SO_PROD_PAINEL");

            // Chave primária
            builder
                .HasKey(x => x.Id);

            // Chave estrangeira Produção Painel
            builder
                .HasOne(x => x.Painel) 
                .WithMany()          
                .HasForeignKey(x => x.IdPainel)
                .OnDelete(DeleteBehavior.Cascade);

            // Data de medição
            builder
                .Property(x => x.DataMedicao)
                .HasColumnName("DATAMEDICAO")
                .IsRequired();

            // Energia gerada em kWh
            builder
                .Property(x => x.Energia)
                .HasColumnName("ENERGIA")
                .IsRequired();

            // Eficiência
            builder
                .Property(x => x.Eficiencia)
                .HasColumnName("EFICIENCIA")
                .IsRequired();

            // Alerta de baixa eficiência
            builder
                .Property(x => x.Alerta)
                .HasColumnName("ALERTA")
                .IsRequired();
        }
    }
}
