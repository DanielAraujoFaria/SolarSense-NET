using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolarSense.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSense.Database.Mappings
{
    public class PainelMapping : IEntityTypeConfiguration<Painel>
    {
        public void Configure(EntityTypeBuilder<Painel> builder)
        {
            // Nome da tabela
            builder
                .ToTable("T_SO_PAINEL");

            // Chave primária
            builder
                .HasKey(x => x.Id);

            // Nome do usuário
            builder
                .Property(x => x.Nome)
                .HasMaxLength(50)
                .HasColumnName("NOME")
                .IsRequired();

            // Potência
            builder
                .Property(x => x.Potencia)
                .HasColumnName("POTENCIA")
                .IsRequired();

            // Localização
            builder
                .Property(x => x.Localizacao)
                .HasMaxLength(255)
                .HasColumnName("LOCALIZACAO")
                .IsRequired();

            // Tipo de Painel
            builder
                .Property(x => x.TipoPainel)
                .HasColumnName("TIPOPAINEL")
                .IsRequired();

            // Data de Instalação
            builder
                .Property(x => x.DataInstalacao)
                .HasColumnName("DATAINSTALACAO")
                .IsRequired();

            // Chave estrangeira Usuário
            builder
                .HasOne(x => x.Usuario) 
                .WithMany()     
                .HasForeignKey(x => x.IdCliente)
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
    
}
