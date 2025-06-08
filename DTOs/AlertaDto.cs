namespace FloodWatch.API.DTOs
{
    public class AlertaDto
    {
        public int Id { get; set; }
        public int RegiaoCobertaId { get; set; }
        public string RegiaoCobertaNome { get; set; } = string.Empty;
        public string TipoAlerta { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataHoraCriacao { get; set; }
        public DateTime? DataHoraExpiracao { get; set; }
        public string Status { get; set; } = string.Empty;
        public int UsuarioCriadorId { get; set; }
        public string UsuarioCriadorNome { get; set; } = string.Empty;
        public string NivelSeveridade { get; set; } = string.Empty;
        public string? InstrucoesSeguranca { get; set; }
        public decimal? RaioAfetadoKm { get; set; }
        public int? PessoasAfetadasEstimadas { get; set; }
        public bool Ativo { get; set; }
        public int MinutosParaExpiracao { get; set; }
    }

    public class CreateAlertaDto
    {
        public int RegiaoCobertaId { get; set; }
        public string TipoAlerta { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTime? DataHoraExpiracao { get; set; }
        public string NivelSeveridade { get; set; } = "Baixo";
        public string? InstrucoesSeguranca { get; set; }
        public decimal? RaioAfetadoKm { get; set; }
        public int? PessoasAfetadasEstimadas { get; set; }
    }

    public class UpdateAlertaDto
    {
        public string TipoAlerta { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTime? DataHoraExpiracao { get; set; }
        public string Status { get; set; } = string.Empty;
        public string NivelSeveridade { get; set; } = string.Empty;
        public string? InstrucoesSeguranca { get; set; }
        public decimal? RaioAfetadoKm { get; set; }
        public int? PessoasAfetadasEstimadas { get; set; }
    }

    public class AlertaResumoDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string TipoAlerta { get; set; } = string.Empty;
        public string NivelSeveridade { get; set; } = string.Empty;
        public string RegiaoCobertaNome { get; set; } = string.Empty;
        public DateTime DataHoraCriacao { get; set; }
        public string Status { get; set; } = string.Empty;
        public bool Ativo { get; set; }
    }
}

