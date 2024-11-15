using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolarSense.Database.Models
{
    public class Usuario
    {
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        public string Tipo { get; set; } // 'CLIENTE' ou 'ADMIN'

        public string Notificacoes { get; set; } // 'SIM' ou 'NAO'

        public DateTime DataCadastro { get; set; }
    }
}
