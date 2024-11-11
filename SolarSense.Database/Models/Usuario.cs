using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSense.Database.Models
{
    public class Usuario
    {
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public string Senha { get; set; }

        [Required]
        public TipoUsuario Tipo { get; set; }
        public bool Notificacoes { get; set; }
        public DateTime DataCadastro { get; set; }
    }

    public enum TipoUsuario
    {
        CLIENTE,
        ADMIN
    }
}
