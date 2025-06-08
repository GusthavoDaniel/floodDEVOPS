namespace FloodWatch.API.DTOs
{
    public class ApiResponseDto<T>
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public T? Dados { get; set; }
        public List<string> Erros { get; set; } = new();
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }

    public class PagedResponseDto<T>
    {
        public List<T> Dados { get; set; } = new();
        public int PaginaAtual { get; set; }
        public int TotalPaginas { get; set; }
        public int TamanhoPagina { get; set; }
        public int TotalItens { get; set; }
        public bool TemProximaPagina { get; set; }
        public bool TemPaginaAnterior { get; set; }
    }

    public class DashboardDto
    {
        public int TotalSensores { get; set; }
        public int SensoresAtivos { get; set; }
        public int SensoresInativos { get; set; }
        public int AlertasAtivos { get; set; }
        public int RegioesCoberta { get; set; }
        public int EventosUltimos30Dias { get; set; }
        public List<SensorResumoDto> SensoresRecentes { get; set; } = new();
        public List<AlertaResumoDto> AlertasRecentes { get; set; } = new();
        public List<LeituraTempoRealDto> LeiturasTempoReal { get; set; } = new();
        public EstatisticasEventoDto EstatisticasEventos { get; set; } = null!;
    }

    public class FiltroDto
    {
        public int Pagina { get; set; } = 1;
        public int TamanhoPagina { get; set; } = 10;
        public string? Busca { get; set; }
        public string? OrdenarPor { get; set; }
        public bool OrdemDecrescente { get; set; } = false;
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
    }

    public class FiltroSensorDto : FiltroDto
    {
        public string? Tipo { get; set; }
        public string? Status { get; set; }
        public int? RegiaoCobertaId { get; set; }
    }

    public class FiltroAlertaDto : FiltroDto
    {
        public string? TipoAlerta { get; set; }
        public string? Status { get; set; }
        public string? NivelSeveridade { get; set; }
        public int? RegiaoCobertaId { get; set; }
        public bool? ApenasAtivos { get; set; }
    }

    public class FiltroLeituraDto : FiltroDto
    {
        public int? SensorId { get; set; }
        public string? StatusQualidade { get; set; }
        public decimal? ValorMinimo { get; set; }
        public decimal? ValorMaximo { get; set; }
    }

    public class FiltroEventoDto : FiltroDto
    {
        public string? TipoEvento { get; set; }
        public string? NivelSeveridade { get; set; }
        public int? RegiaoCobertaId { get; set; }
        public bool? ApenasFinalizados { get; set; }
    }
}

