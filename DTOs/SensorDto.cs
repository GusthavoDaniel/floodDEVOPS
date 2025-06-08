namespace FloodWatch.API.DTOs
{
    public class SensorDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime DataInstalacao { get; set; }
        public DateTime? UltimaLeitura { get; set; }
        public int RegiaoCobertaId { get; set; }
        public string RegiaoCobertaNome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public int IntervaloLeituraMinutos { get; set; }
        public decimal? ValorMinimo { get; set; }
        public decimal? ValorMaximo { get; set; }
        public decimal? UltimoValorLido { get; set; }
        public string? UltimaUnidadeMedida { get; set; }
    }

    public class CreateSensorDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int RegiaoCobertaId { get; set; }
        public string? Descricao { get; set; }
        public int IntervaloLeituraMinutos { get; set; } = 15;
        public decimal? ValorMinimo { get; set; }
        public decimal? ValorMaximo { get; set; }
    }

    public class UpdateSensorDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Status { get; set; } = string.Empty;
        public int RegiaoCobertaId { get; set; }
        public string? Descricao { get; set; }
        public int IntervaloLeituraMinutos { get; set; }
        public decimal? ValorMinimo { get; set; }
        public decimal? ValorMaximo { get; set; }
    }

    public class SensorResumoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime? UltimaLeitura { get; set; }
        public decimal? UltimoValor { get; set; }
        public string? UnidadeMedida { get; set; }
    }
}

