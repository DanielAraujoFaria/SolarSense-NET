using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSense.Database.Models
{
    public class Painel
    {
        [Column("ID")]
        public int Id { get; set; }

        public int IdCliente { get; set; }

        public string Nome { get; set; }

        // Potencia em kW
        [Range(0, int.MaxValue)]
        public int Potencia { get; set; }

        public string Localizacao { get; set; }

        public string TipoPainel { get; set; }

        public DateTime DataInstalacao { get; set; }
    }
}
