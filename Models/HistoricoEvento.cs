using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FloodWatch.API.Models
{
    [Table("historico_eventos")]
    public class HistoricoEvento
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("regiao_coberta_id")]
        public int RegiaoCobertaId { get; set; }

        [Column("tipo_evento")]
        public TipoEvento TipoEvento { get; set; }

        [Column("data_hora_inicio")]
        public DateTime DataHoraInicio { get; set; }

        [Column("data_hora_fim")]
        public DateTime? DataHoraFim { get; set; }

        [Column("nivel_severidade")]
        public NivelSeveridade NivelSeveridade { get; set; }

        [Required]
        [MaxLength(1000)]
        [Column("descricao")]
        public string Descricao { get; set; } = string.Empty;

        [Column("pessoas_afetadas")]
        public int? PessoasAfetadas { get; set; }

        [Column("danos_estimados")]
        [Precision(15, 2)]
        public decimal? DanosEstimados { get; set; }

        [Column("area_afetada_km2")]
        [Precision(10, 4)]
        public decimal? AreaAfetadaKm2 { get; set; }

        [Column("nivel_agua_maximo")]
        [Precision(8, 2)]
        public decimal? NivelAguaMaximo { get; set; }

        [Column("precipitacao_total")]
        [Precision(8, 2)]
        public decimal? PrecipitacaoTotal { get; set; }

        [MaxLength(500)]
        [Column("acoes_tomadas")]
        public string? AcesTomadas { get; set; }

        [MaxLength(500)]
        [Column("licoes_aprendidas")]
        public string? LicoesAprendidas { get; set; }

        [Column("data_criacao")]
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        [Column("data_atualizacao")]
        public DateTime DataAtualizacao { get; set; } = DateTime.UtcNow;

        // Relacionamentos
        [ForeignKey("RegiaoCobertaId")]
        public virtual RegiaoCoberta RegiaoCoberta { get; set; } = null!;
    }
}

