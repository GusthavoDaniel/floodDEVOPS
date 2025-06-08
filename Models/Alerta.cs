using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FloodWatch.API.Models
{
    [Table("alertas")]
    public class Alerta
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("regiao_coberta_id")]
        public int RegiaoCobertaId { get; set; }

        [Column("tipo_alerta")]
        public TipoAlerta TipoAlerta { get; set; }

        [Required]
        [MaxLength(200)]
        [Column("titulo")]
        public string Titulo { get; set; } = string.Empty;

        [Required]
        [MaxLength(1000)]
        [Column("descricao")]
        public string Descricao { get; set; } = string.Empty;

        [Column("data_hora_criacao")]
        public DateTime DataHoraCriacao { get; set; } = DateTime.UtcNow;

        [Column("data_hora_expiracao")]
        public DateTime? DataHoraExpiracao { get; set; }

        [Column("status")]
        public StatusAlerta Status { get; set; } = StatusAlerta.Ativo;

        [Column("usuario_criador_id")]
        public int UsuarioCriadorId { get; set; }

        [Column("nivel_severidade")]
        public NivelSeveridade NivelSeveridade { get; set; } = NivelSeveridade.Baixo;

        [MaxLength(500)]
        [Column("instrucoes_seguranca")]
        public string? InstrucoesSeguranca { get; set; }

        [Column("raio_afetado_km")]
        [Precision(8, 2)]
        public decimal? RaioAfetadoKm { get; set; }

        [Column("pessoas_afetadas_estimadas")]
        public int? PessoasAfetadasEstimadas { get; set; }

        [Column("data_atualizacao")]
        public DateTime DataAtualizacao { get; set; } = DateTime.UtcNow;

        // Relacionamentos
        [ForeignKey("RegiaoCobertaId")]
        public virtual RegiaoCoberta RegiaoCoberta { get; set; } = null!;

        [ForeignKey("UsuarioCriadorId")]
        public virtual Usuario UsuarioCriador { get; set; } = null!;
    }
}

