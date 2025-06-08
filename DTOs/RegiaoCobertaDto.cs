namespace FloodWatch.API.DTOs
{
    public class RegiaoCobertaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public string NivelRiscoAtual { get; set; } = string.Empty;
        public int PopulacaoEstimada { get; set; }
        public decimal AreaKm2 { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public int TotalSensores { get; set; }
        public int AlertasAtivos { get; set; }
    }

    public class CreateRegiaoCobertaDto
    {
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public int PopulacaoEstimada { get; set; }
        public decimal AreaKm2 { get; set; }
    }

    public class UpdateRegiaoCobertaDto
    {
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public string NivelRiscoAtual { get; set; } = string.Empty;
        public int PopulacaoEstimada { get; set; }
        public decimal AreaKm2 { get; set; }
    }
}

