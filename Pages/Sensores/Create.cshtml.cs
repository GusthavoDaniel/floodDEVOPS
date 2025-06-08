using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace FloodWatch.API.Pages.Sensores
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public SensorCreateViewModel Sensor { get; set; } = new();

        public void OnGet()
        {
            // Valores padrão
            Sensor.Status = "Ativo";
            Sensor.IntervaloLeituraMinutos = 15;
            Sensor.AtivarAlertas = true;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Aqui seria feita a chamada para a API ou serviço para salvar o sensor
            // Por enquanto, apenas simular o salvamento
            
            // Simular delay de processamento
            await Task.Delay(500);

            // Redirecionar para a lista com mensagem de sucesso
            TempData["SuccessMessage"] = $"Sensor '{Sensor.Nome}' criado com sucesso!";
            return RedirectToPage("Index");
        }
    }

    public class SensorCreateViewModel
    {
        [Required(ErrorMessage = "O nome do sensor é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O tipo do sensor é obrigatório")]
        public string Tipo { get; set; } = string.Empty;

        [Required(ErrorMessage = "A latitude é obrigatória")]
        [Range(-90, 90, ErrorMessage = "A latitude deve estar entre -90 e 90")]
        public decimal Latitude { get; set; }

        [Required(ErrorMessage = "A longitude é obrigatória")]
        [Range(-180, 180, ErrorMessage = "A longitude deve estar entre -180 e 180")]
        public decimal Longitude { get; set; }

        [Required(ErrorMessage = "O status é obrigatório")]
        public string Status { get; set; } = "Ativo";

        [Range(1, 1440, ErrorMessage = "O intervalo deve estar entre 1 e 1440 minutos")]
        public int IntervaloLeituraMinutos { get; set; } = 15;

        [Range(0, double.MaxValue, ErrorMessage = "O valor mínimo deve ser positivo")]
        public decimal? ValorMinimo { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "O valor máximo deve ser positivo")]
        public decimal? ValorMaximo { get; set; }

        [StringLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres")]
        public string? Descricao { get; set; }

        public bool AtivarAlertas { get; set; } = true;
    }
}

