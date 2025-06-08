using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FloodWatch.API.Pages
{
    public class IndexModel : PageModel
    {
        public int TotalSensores { get; set; } = 12;
        public int AlertasAtivos { get; set; } = 3;
        public int RegioesMonitoradas { get; set; } = 5;
        public int LeiturasDiarias { get; set; } = 1247;
        
        public List<AlertaViewModel> AlertasRecentes { get; set; } = new();

        public void OnGet()
        {
            // Simular dados para demonstração
            AlertasRecentes = new List<AlertaViewModel>
            {
                new AlertaViewModel
                {
                    Titulo = "Nível de água elevado - Rio Tietê",
                    Descricao = "Sensor detectou aumento significativo no nível da água",
                    Nivel = "Alto",
                    DataHora = DateTime.Now.AddMinutes(-15)
                },
                new AlertaViewModel
                {
                    Titulo = "Precipitação intensa - Zona Sul",
                    Descricao = "Chuva forte detectada na região do Ibirapuera",
                    Nivel = "Medio",
                    DataHora = DateTime.Now.AddMinutes(-45)
                },
                new AlertaViewModel
                {
                    Titulo = "Sensor offline - Centro",
                    Descricao = "Sensor Anhangabaú não está respondendo",
                    Nivel = "Baixo",
                    DataHora = DateTime.Now.AddHours(-2)
                }
            };
        }
    }

    public class AlertaViewModel
    {
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Nivel { get; set; } = string.Empty;
        public DateTime DataHora { get; set; }
    }
}

