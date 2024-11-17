using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSense.Database.Models
{
    // Classe de previsão de potencia para o Machine Learning
    public class PainelPotencia
    {
        public int Id { get; set; }
        public int IdPainel { get; set; }
        public int IdCliente { get; set; }
        public string CondicaoClimatica { get; set; } // Ex.: Ensolarado, Nublado
        public string Localizacao { get; set; } // Ex.: São Paulo
        public float PotenciaGerada { get; set; } // Potência gerada em watts
        public DateTime DataRegistro { get; set; } // Data do registro
    }
}
