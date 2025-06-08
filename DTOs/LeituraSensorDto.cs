namespace FloodWatch.API.DTOs
{
    public class LeituraSensorDto
    {
        public int Id { get; set; }
        public int SensorId { get; set; }
        public string SensorNome { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public string UnidadeMedida { get; set; } = string.Empty;
        public DateTime DataHoraLeitura { get; set; }
        public string StatusQualidade { get; set; } = string.Empty;
        public string? Observacoes { get; set; }
        public decimal? TemperaturaAmbiente { get; set; }
        public decimal? UmidadeRelativa { get; set; }
        public decimal? PressaoAtmosferica { get; set; }
    }

    public class CreateLeituraSensorDto
    {
        public int SensorId { get; set; }
        public decimal Valor { get; set; }
        public string UnidadeMedida { get; set; } = string.Empty;
        public DateTime? DataHoraLeitura { get; set; }
        public string StatusQualidade { get; set; } = "Boa";
        public string? Observacoes { get; set; }
        public decimal? TemperaturaAmbiente { get; set; }
        public decimal? UmidadeRelativa { get; set; }
        public decimal? PressaoAtmosferica { get; set; }
    }

    public class LeituraTempoRealDto
    {
        public int SensorId { get; set; }
        public string SensorNome { get; set; } = string.Empty;
        public string TipoSensor { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public string UnidadeMedida { get; set; } = string.Empty;
        public DateTime DataHoraLeitura { get; set; }
        public string StatusQualidade { get; set; } = string.Empty;
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string RegiaoCobertaNome { get; set; } = string.Empty;
    }

    public class EstatisticasLeituraDto
    {
        public int SensorId { get; set; }
        public string SensorNome { get; set; } = string.Empty;
        public decimal ValorMinimo { get; set; }
        public decimal ValorMaximo { get; set; }
        public decimal ValorMedio { get; set; }
        public int TotalLeituras { get; set; }
        public DateTime PeriodoInicio { get; set; }
        public DateTime PeriodoFim { get; set; }
        public string UnidadeMedida { get; set; } = string.Empty;
    }
}

