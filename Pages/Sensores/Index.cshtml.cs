using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FloodWatch.API.Pages.Sensores
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string? FiltroNome { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string? FiltroTipo { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string? FiltroStatus { get; set; }

        public List<SensorViewModel> Sensores { get; set; } = new();

        public void OnGet()
        {
            // Simular dados para demonstração
            var todosSensores = new List<SensorViewModel>
            {
                new SensorViewModel
                {
                    Id = 1,
                    Nome = "Sensor Anhangabaú",
                    Tipo = "NivelAgua",
                    Status = "Ativo",
                    Latitude = -23.5489m,
                    Longitude = -46.6388m,
                    UltimaLeitura = DateTime.Now.AddMinutes(-15),
                    Descricao = "Sensor de nível de água no Vale do Anhangabaú"
                },
                new SensorViewModel
                {
                    Id = 2,
                    Nome = "Sensor Ibirapuera",
                    Tipo = "Precipitacao",
                    Status = "Ativo",
                    Latitude = -23.5873m,
                    Longitude = -46.6573m,
                    UltimaLeitura = DateTime.Now.AddMinutes(-5),
                    Descricao = "Sensor de precipitação no Parque Ibirapuera"
                },
                new SensorViewModel
                {
                    Id = 3,
                    Nome = "Sensor Marginal Tietê",
                    Tipo = "NivelAgua",
                    Status = "Manutencao",
                    Latitude = -23.5205m,
                    Longitude = -46.6333m,
                    UltimaLeitura = DateTime.Now.AddHours(-3),
                    Descricao = "Sensor principal da Marginal Tietê"
                },
                new SensorViewModel
                {
                    Id = 4,
                    Nome = "Sensor Vila Madalena",
                    Tipo = "Temperatura",
                    Status = "Ativo",
                    Latitude = -23.5505m,
                    Longitude = -46.6890m,
                    UltimaLeitura = DateTime.Now.AddMinutes(-8),
                    Descricao = "Sensor de temperatura ambiente"
                },
                new SensorViewModel
                {
                    Id = 5,
                    Nome = "Sensor Brooklin",
                    Tipo = "Umidade",
                    Status = "Inativo",
                    Latitude = -23.6109m,
                    Longitude = -46.7025m,
                    UltimaLeitura = DateTime.Now.AddDays(-2),
                    Descricao = "Sensor de umidade relativa do ar"
                },
                new SensorViewModel
                {
                    Id = 6,
                    Nome = "Sensor Morumbi",
                    Tipo = "Precipitacao",
                    Status = "Ativo",
                    Latitude = -23.6181m,
                    Longitude = -46.7195m,
                    UltimaLeitura = DateTime.Now.AddMinutes(-12),
                    Descricao = "Sensor de chuva na região do Morumbi"
                }
            };

            // Aplicar filtros
            Sensores = todosSensores.Where(s =>
                (string.IsNullOrEmpty(FiltroNome) || s.Nome.Contains(FiltroNome, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(FiltroTipo) || s.Tipo == FiltroTipo) &&
                (string.IsNullOrEmpty(FiltroStatus) || s.Status == FiltroStatus)
            ).ToList();
        }
    }

    public class SensorViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public DateTime? UltimaLeitura { get; set; }
        public string? Descricao { get; set; }
    }
}

