using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FloodWatch.API.Models
{
    [Table("regioes_cobertas")]
    public class RegiaoCoberta
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("nome")]
        public string Nome { get; set; } = string.Empty;

        [MaxLength(500)]
        [Column("descricao")]
        public string? Descricao { get; set; }

        [Column("nivel_risco_atual")]
        public NivelRisco NivelRiscoAtual { get; set; } = NivelRisco.Baixo;

        [Column("populacao_estimada")]
        public int PopulacaoEstimada { get; set; }

        [Column("area_km2")]
        [Precision(10, 4)]
        public decimal AreaKm2 { get; set; }

        [Column("data_criacao")]
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        [Column("data_atualizacao")]
        public DateTime DataAtualizacao { get; set; } = DateTime.UtcNow;

        // Relacionamentos
        public virtual ICollection<Sensor> Sensores { get; set; } = new List<Sensor>();
        public virtual ICollection<Alerta> Alertas { get; set; } = new List<Alerta>();
        public virtual ICollection<HistoricoEvento> HistoricoEventos { get; set; } = new List<HistoricoEvento>();
    }
}

