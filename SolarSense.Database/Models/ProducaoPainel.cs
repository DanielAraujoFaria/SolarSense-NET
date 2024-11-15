using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolarSense.Database.Models
{
    public class ProducaoPainel
    {
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        public int IdPainel { get; set; }

        public DateTime DataMedicao { get; set; }

        // Energia gerada em kWh
        [Range(0, double.MaxValue)]
        public double Energia { get; set; }

        [Range(0, 100)]
        public int Eficiencia { get; set; }

        // Alerta em caso de baixa eficiência
        [MaxLength(3)]
        [Required]
        public string Alerta { get; set; } = "NAO"; // "SIM" ou "NAO"
    }
}
