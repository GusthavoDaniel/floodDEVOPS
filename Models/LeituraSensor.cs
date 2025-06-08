using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FloodWatch.API.Models
{
    [Table("leituras_sensor")]
    public class LeituraSensor
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("sensor_id")]
        public int SensorId { get; set; }

        [Column("valor")]
        [Precision(10, 4)]
        public decimal Valor { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("unidade_medida")]
        public string UnidadeMedida { get; set; } = string.Empty;

        [Column("data_hora_leitura")]
        public DateTime DataHoraLeitura { get; set; } = DateTime.UtcNow;

        [Column("status_qualidade")]
        public StatusQualidade StatusQualidade { get; set; } = StatusQualidade.Boa;

        [MaxLength(200)]
        [Column("observacoes")]
        public string? Observacoes { get; set; }

        [Column("temperatura_ambiente")]
        [Precision(5, 2)]
        public decimal? TemperaturaAmbiente { get; set; }

        [Column("umidade_relativa")]
        [Precision(5, 2)]
        public decimal? UmidadeRelativa { get; set; }

        [Column("pressao_atmosferica")]
        [Precision(8, 2)]
        public decimal? PressaoAtmosferica { get; set; }

        [Column("data_criacao")]
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        // Relacionamentos
        [ForeignKey("SensorId")]
        public virtual Sensor Sensor { get; set; } = null!;
    }
}

