namespace FloodWatch.API.DTOs
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public DateTime DataCadastro { get; set; }
        public DateTime? UltimoAcesso { get; set; }
        public bool Ativo { get; set; }
        public string? Telefone { get; set; }
        public string? Endereco { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public bool ReceberNotificacoes { get; set; }
    }

    public class LoginDto
    {
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
    }

    public class RegisterDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string ConfirmarSenha { get; set; } = string.Empty;
        public string? Telefone { get; set; }
        public string? Endereco { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public bool ReceberNotificacoes { get; set; } = true;
    }

    public class AuthResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public DateTime Expiracao { get; set; }
        public UsuarioDto Usuario { get; set; } = null!;
    }

    public class UpdateUsuarioDto
    {
        public string Nome { get; set; } = string.Empty;
        public string? Telefone { get; set; }
        public string? Endereco { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public bool ReceberNotificacoes { get; set; }
    }

    public class ChangePasswordDto
    {
        public string SenhaAtual { get; set; } = string.Empty;
        public string NovaSenha { get; set; } = string.Empty;
        public string ConfirmarNovaSenha { get; set; } = string.Empty;
    }
}

