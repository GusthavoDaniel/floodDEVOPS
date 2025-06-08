using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FloodWatch.API.Models
{
    [Table("sensores")]
    public class Sensor
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("nome")]
        public string Nome { get; set; } = string.Empty;

        [Column("tipo")]
        public TipoSensor Tipo { get; set; }

        [Column("latitude")]
        [Precision(10, 8)]
        public decimal Latitude { get; set; }

        [Column("longitude")]
        [Precision(11, 8)]
        public decimal Longitude { get; set; }

        [Column("status")]
        public StatusSensor Status { get; set; } = StatusSensor.Ativo;

        [Column("data_instalacao")]
        public DateTime DataInstalacao { get; set; } = DateTime.UtcNow;

        [Column("ultima_leitura")]
        public DateTime? UltimaLeitura { get; set; }

        [Column("regiao_coberta_id")]
        public int RegiaoCobertaId { get; set; }

        [MaxLength(200)]
        [Column("descricao")]
        public string? Descricao { get; set; }

        [Column("intervalo_leitura_minutos")]
        public int IntervaloLeituraMinutos { get; set; } = 15;

        [Column("valor_minimo")]
        [Precision(10, 4)]
        public decimal? ValorMinimo { get; set; }

        [Column("valor_maximo")]
        [Precision(10, 4)]
        public decimal? ValorMaximo { get; set; }

        [Column("data_criacao")]
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        [Column("data_atualizacao")]
        public DateTime DataAtualizacao { get; set; } = DateTime.UtcNow;

        // Relacionamentos
        [ForeignKey("RegiaoCobertaId")]
        public virtual RegiaoCoberta RegiaoCoberta { get; set; } = null!;
        
        public virtual ICollection<LeituraSensor> Leituras { get; set; } = new List<LeituraSensor>();
    }
}

