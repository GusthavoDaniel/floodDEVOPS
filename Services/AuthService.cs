using Microsoft.AspNetCore.Identity;
using FloodWatch.API.Models;
using FloodWatch.API.DTOs;

namespace FloodWatch.API.Services
{
    public interface IAuthService
    {
        Task<AuthResponseDto?> LoginAsync(LoginDto loginDto);
        Task<AuthResponseDto?> RegisterAsync(RegisterDto registerDto);
        Task<bool> ChangePasswordAsync(int userId, ChangePasswordDto changePasswordDto);
        Task<UsuarioDto?> GetUserProfileAsync(int userId);
        Task<bool> UpdateUserProfileAsync(int userId, UpdateUsuarioDto updateDto);
    }

    public class AuthService : IAuthService
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly IJwtService _jwtService;

        public AuthService(
            UserManager<Usuario> userManager,
            SignInManager<Usuario> signInManager,
            IJwtService jwtService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
        }

        public async Task<AuthResponseDto?> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null || !user.Ativo)
                return null;

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Senha, false);
            if (!result.Succeeded)
                return null;

            // Atualizar último acesso
            user.UltimoAcesso = DateTime.UtcNow;
            await _userManager.UpdateAsync(user);

            var token = _jwtService.GenerateToken(user);
            var expiration = DateTime.UtcNow.AddHours(24);

            return new AuthResponseDto
            {
                Token = token,
                Expiracao = expiration,
                Usuario = MapToUsuarioDto(user)
            };
        }

        public async Task<AuthResponseDto?> RegisterAsync(RegisterDto registerDto)
        {
            if (registerDto.Senha != registerDto.ConfirmarSenha)
                return null;

            var existingUser = await _userManager.FindByEmailAsync(registerDto.Email);
            if (existingUser != null)
                return null;

            var user = new Usuario
            {
                Nome = registerDto.Nome,
                Email = registerDto.Email,
                UserName = registerDto.Email,
                Telefone = registerDto.Telefone,
                Endereco = registerDto.Endereco,
                Latitude = registerDto.Latitude,
                Longitude = registerDto.Longitude,
                ReceberNotificacoes = registerDto.ReceberNotificacoes,
                Tipo = TipoUsuario.Cidadao,
                DataCadastro = DateTime.UtcNow,
                Ativo = true
            };

            var result = await _userManager.CreateAsync(user, registerDto.Senha);
            if (!result.Succeeded)
                return null;

            var token = _jwtService.GenerateToken(user);
            var expiration = DateTime.UtcNow.AddHours(24);

            return new AuthResponseDto
            {
                Token = token,
                Expiracao = expiration,
                Usuario = MapToUsuarioDto(user)
            };
        }

        public async Task<bool> ChangePasswordAsync(int userId, ChangePasswordDto changePasswordDto)
        {
            if (changePasswordDto.NovaSenha != changePasswordDto.ConfirmarNovaSenha)
                return false;

            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return false;

            var result = await _userManager.ChangePasswordAsync(user, changePasswordDto.SenhaAtual, changePasswordDto.NovaSenha);
            return result.Succeeded;
        }

        public async Task<UsuarioDto?> GetUserProfileAsync(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            return user != null ? MapToUsuarioDto(user) : null;
        }

        public async Task<bool> UpdateUserProfileAsync(int userId, UpdateUsuarioDto updateDto)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return false;

            user.Nome = updateDto.Nome;
            user.Telefone = updateDto.Telefone;
            user.Endereco = updateDto.Endereco;
            user.Latitude = updateDto.Latitude;
            user.Longitude = updateDto.Longitude;
            user.ReceberNotificacoes = updateDto.ReceberNotificacoes;
            user.DataAtualizacao = DateTime.UtcNow;

            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }

        private static UsuarioDto MapToUsuarioDto(Usuario user)
        {
            return new UsuarioDto
            {
                Id = user.Id,
                Nome = user.Nome,
                Email = user.Email ?? string.Empty,
                Tipo = user.Tipo.ToString(),
                DataCadastro = user.DataCadastro,
                UltimoAcesso = user.UltimoAcesso,
                Ativo = user.Ativo,
                Telefone = user.Telefone,
                Endereco = user.Endereco,
                Latitude = user.Latitude,
                Longitude = user.Longitude,
                ReceberNotificacoes = user.ReceberNotificacoes
            };
        }
    }
}

