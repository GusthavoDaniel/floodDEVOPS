namespace FloodWatch.API.DTOs
{
    public class HistoricoEventoDto
    {
        public int Id { get; set; }
        public int RegiaoCobertaId { get; set; }
        public string RegiaoCobertaNome { get; set; } = string.Empty;
        public string TipoEvento { get; set; } = string.Empty;
        public DateTime DataHoraInicio { get; set; }
        public DateTime? DataHoraFim { get; set; }
        public string NivelSeveridade { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int? PessoasAfetadas { get; set; }
        public decimal? DanosEstimados { get; set; }
        public decimal? AreaAfetadaKm2 { get; set; }
        public decimal? NivelAguaMaximo { get; set; }
        public decimal? PrecipitacaoTotal { get; set; }
        public string? AcesTomadas { get; set; }
        public string? LicoesAprendidas { get; set; }
        public int DuracaoHoras { get; set; }
        public bool EventoFinalizado { get; set; }
    }

    public class CreateHistoricoEventoDto
    {
        public int RegiaoCobertaId { get; set; }
        public string TipoEvento { get; set; } = string.Empty;
        public DateTime DataHoraInicio { get; set; }
        public DateTime? DataHoraFim { get; set; }
        public string NivelSeveridade { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int? PessoasAfetadas { get; set; }
        public decimal? DanosEstimados { get; set; }
        public decimal? AreaAfetadaKm2 { get; set; }
        public decimal? NivelAguaMaximo { get; set; }
        public decimal? PrecipitacaoTotal { get; set; }
        public string? AcesTomadas { get; set; }
        public string? LicoesAprendidas { get; set; }
    }

    public class EstatisticasEventoDto
    {
        public int TotalEventos { get; set; }
        public int EventosUltimos30Dias { get; set; }
        public int PessoasTotalAfetadas { get; set; }
        public decimal DanosTotalEstimados { get; set; }
        public string TipoEventoMaisFrequente { get; set; } = string.Empty;
        public string RegiaoCobertaMaisAfetada { get; set; } = string.Empty;
        public decimal TempoMedioEventoHoras { get; set; }
        public List<EventoPorMesDto> EventosPorMes { get; set; } = new();
        public List<EventoPorTipoDto> EventosPorTipo { get; set; } = new();
    }

    public class EventoPorMesDto
    {
        public int Ano { get; set; }
        public int Mes { get; set; }
        public string MesNome { get; set; } = string.Empty;
        public int TotalEventos { get; set; }
    }

    public class EventoPorTipoDto
    {
        public string TipoEvento { get; set; } = string.Empty;
        public int TotalEventos { get; set; }
        public int PessoasAfetadas { get; set; }
        public decimal DanosEstimados { get; set; }
    }
}

