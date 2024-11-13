using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSense.Database.Models
{
    public class ProducaoPainel
    {
        [Column("ID")]
        public int Id { get; set; }

        [ForeignKey("Painel")]
        [Required]
        public int IdPainel { get; set; }

        public DateTime DataMedicao { get; set; }

        // Energia gerada em kWh
        [Range(0, int.MaxValue)]
        public double Energia {  get; set; }

        [Range(0, 100)]
        public int Eficiencia { get; set; }

        // Alerta em caso de baixa eficiência
        public bool Alerta {  get; set; }

        // Navegação para Painel
        public Painel Painel { get; set; }

    }

    public enum AlertaPainel
    {
        NORMAL,
        ALTA
    }
}
