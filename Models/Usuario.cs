using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FloodWatch.API.Models
{
    [Table("usuarios")]
    public class Usuario : IdentityUser<int>
    {
        [Required]
        [MaxLength(100)]
        [Column("nome")]
        public string Nome { get; set; } = string.Empty;

        [Column("tipo")]
        public TipoUsuario Tipo { get; set; } = TipoUsuario.Cidadao;

        [Column("data_cadastro")]
        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

        [Column("ultimo_acesso")]
        public DateTime? UltimoAcesso { get; set; }

        [Column("ativo")]
        public bool Ativo { get; set; } = true;

        [MaxLength(20)]
        [Column("telefone")]
        public string? Telefone { get; set; }

        [MaxLength(200)]
        [Column("endereco")]
        public string? Endereco { get; set; }

        [Column("latitude")]
        [Precision(10, 8)]
        public decimal? Latitude { get; set; }

        [Column("longitude")]
        [Precision(11, 8)]
        public decimal? Longitude { get; set; }

        [Column("receber_notificacoes")]
        public bool ReceberNotificacoes { get; set; } = true;

        [Column("data_atualizacao")]
        public DateTime DataAtualizacao { get; set; } = DateTime.UtcNow;

        // Relacionamentos
        public virtual ICollection<Alerta> AlertasCriados { get; set; } = new List<Alerta>();
    }
}

