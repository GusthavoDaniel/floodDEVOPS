using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FloodWatch.API.DTOs;
using FloodWatch.API.Services;
using System.Security.Claims;

namespace FloodWatch.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Realiza login do usuário
        /// </summary>
        /// <param name="loginDto">Dados de login</param>
        /// <returns>Token JWT e dados do usuário</returns>
        [HttpPost("login")]
        public async Task<ActionResult<ApiResponseDto<AuthResponseDto>>> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                var result = await _authService.LoginAsync(loginDto);
                
                if (result == null)
                {
                    return BadRequest(new ApiResponseDto<AuthResponseDto>
                    {
                        Sucesso = false,
                        Mensagem = "Email ou senha inválidos",
                        Erros = new List<string> { "Credenciais inválidas" }
                    });
                }

                return Ok(new ApiResponseDto<AuthResponseDto>
                {
                    Sucesso = true,
                    Mensagem = "Login realizado com sucesso",
                    Dados = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponseDto<AuthResponseDto>
                {
                    Sucesso = false,
                    Mensagem = "Erro interno do servidor",
                    Erros = new List<string> { ex.Message }
                });
            }
        }

        /// <summary>
        /// Registra um novo usuário
        /// </summary>
        /// <param name="registerDto">Dados de registro</param>
        /// <returns>Token JWT e dados do usuário</returns>
        [HttpPost("register")]
        public async Task<ActionResult<ApiResponseDto<AuthResponseDto>>> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                var result = await _authService.RegisterAsync(registerDto);
                
                if (result == null)
                {
                    return BadRequest(new ApiResponseDto<AuthResponseDto>
                    {
                        Sucesso = false,
                        Mensagem = "Erro ao registrar usuário",
                        Erros = new List<string> { "Email já existe ou dados inválidos" }
                    });
                }

                return Ok(new ApiResponseDto<AuthResponseDto>
                {
                    Sucesso = true,
                    Mensagem = "Usuário registrado com sucesso",
                    Dados = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponseDto<AuthResponseDto>
                {
                    Sucesso = false,
                    Mensagem = "Erro interno do servidor",
                    Erros = new List<string> { ex.Message }
                });
            }
        }

        /// <summary>
        /// Obtém o perfil do usuário autenticado
        /// </summary>
        /// <returns>Dados do usuário</returns>
        [HttpGet("profile")]
        [Authorize]
        public async Task<ActionResult<ApiResponseDto<UsuarioDto>>> GetProfile()
        {
            try
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
                var user = await _authService.GetUserProfileAsync(userId);
                
                if (user == null)
                {
                    return NotFound(new ApiResponseDto<UsuarioDto>
                    {
                        Sucesso = false,
                        Mensagem = "Usuário não encontrado"
                    });
                }

                return Ok(new ApiResponseDto<UsuarioDto>
                {
                    Sucesso = true,
                    Mensagem = "Perfil obtido com sucesso",
                    Dados = user
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponseDto<UsuarioDto>
                {
                    Sucesso = false,
                    Mensagem = "Erro interno do servidor",
                    Erros = new List<string> { ex.Message }
                });
            }
        }

        /// <summary>
        /// Atualiza o perfil do usuário autenticado
        /// </summary>
        /// <param name="updateDto">Dados para atualização</param>
        /// <returns>Resultado da operação</returns>
        [HttpPut("profile")]
        [Authorize]
        public async Task<ActionResult<ApiResponseDto<bool>>> UpdateProfile([FromBody] UpdateUsuarioDto updateDto)
        {
            try
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
                var result = await _authService.UpdateUserProfileAsync(userId, updateDto);
                
                if (!result)
                {
                    return BadRequest(new ApiResponseDto<bool>
                    {
                        Sucesso = false,
                        Mensagem = "Erro ao atualizar perfil"
                    });
                }

                return Ok(new ApiResponseDto<bool>
                {
                    Sucesso = true,
                    Mensagem = "Perfil atualizado com sucesso",
                    Dados = true
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponseDto<bool>
                {
                    Sucesso = false,
                    Mensagem = "Erro interno do servidor",
                    Erros = new List<string> { ex.Message }
                });
            }
        }

        /// <summary>
        /// Altera a senha do usuário autenticado
        /// </summary>
        /// <param name="changePasswordDto">Dados para alteração de senha</param>
        /// <returns>Resultado da operação</returns>
        [HttpPost("change-password")]
        [Authorize]
        public async Task<ActionResult<ApiResponseDto<bool>>> ChangePassword([FromBody] ChangePasswordDto changePasswordDto)
        {
            try
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
                var result = await _authService.ChangePasswordAsync(userId, changePasswordDto);
                
                if (!result)
                {
                    return BadRequest(new ApiResponseDto<bool>
                    {
                        Sucesso = false,
                        Mensagem = "Erro ao alterar senha",
                        Erros = new List<string> { "Senha atual incorreta ou nova senha inválida" }
                    });
                }

                return Ok(new ApiResponseDto<bool>
                {
                    Sucesso = true,
                    Mensagem = "Senha alterada com sucesso",
                    Dados = true
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponseDto<bool>
                {
                    Sucesso = false,
                    Mensagem = "Erro interno do servidor",
                    Erros = new List<string> { ex.Message }
                });
            }
        }

        /// <summary>
        /// Endpoint para verificar se a API está funcionando
        /// </summary>
        /// <returns>Status da API</returns>
        [HttpGet("health")]
        public ActionResult<ApiResponseDto<object>> Health()
        {
            return Ok(new ApiResponseDto<object>
            {
                Sucesso = true,
                Mensagem = "FloodWatch API está funcionando",
                Dados = new
                {
                    Status = "Healthy",
                    Timestamp = DateTime.UtcNow,
                    Version = "1.0.0"
                }
            });
        }
    }
}

