using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EstoqueProduto.Configuration;
using EstoqueProduto.Domain.Contracts.Service;
using EstoqueProduto.Domain.Validations;
using EstoqueProduto.Infra.Notifications;
using EstoqueProduto.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace EstoqueProduto.Domain.Services
{
    public class AutenticacaoUsuarioService : IAutenticacaoUsuarioService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly JwtConfiguration _jwtConfiguration;
        private readonly IRequestNotificator _notifications;
        public AutenticacaoUsuarioService(IRequestNotificator notificator,
                                            UserManager<IdentityUser> userManager,
                                            SignInManager<IdentityUser> signInManager,
                                            IOptions<JwtConfiguration> jwtConfiguration,
                                            IRequestNotificator notifications)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtConfiguration = jwtConfiguration.Value;
            _notifications = notifications;
        }

        public async Task Registrar(IdentityUser novoUsuario, string senha)
        {            
            var validationNovoUsuarioResult = new LoginValidation().Validate(novoUsuario);
            var validationSenhaUsuarioResult = new SenhaUsuarioValidation().Validate(senha);

            if (!validationNovoUsuarioResult.IsValid)  
            {
                _notifications.Add(validationNovoUsuarioResult);
                return;
            }

            if (!validationSenhaUsuarioResult.IsValid)  
            {
                _notifications.Add(validationSenhaUsuarioResult);                
                return;
            }

            var result = await _userManager.CreateAsync(novoUsuario, senha);
            if (result.Succeeded) 
            {
                await _signInManager.SignInAsync(novoUsuario, false);
            } 
            else
            {                
                _notifications.Add(result.Errors.Select(x => x.Description));
                return;
            }
        }

        public async Task<UsuarioAutenticadoTokenViewModel> Login(IdentityUser usuario, string senha)
        {
            var validationLoginResult = new LoginValidation().Validate(usuario);
            var validationSenhaUsuarioResult = new SenhaUsuarioValidation().Validate(senha);

            if (!validationLoginResult.IsValid)  
            {
                _notifications.Add(validationLoginResult);                
                return null;
            }

            if (!validationSenhaUsuarioResult.IsValid)  
            {
                _notifications.Add(validationSenhaUsuarioResult);                
                return null;
            }

            var result = await _signInManager.PasswordSignInAsync(usuario.Email, senha, false, false);
            if (!result.Succeeded) 
            {
                _notifications.Add("E-mail ou senha incorretos.");
                return null;
            }

            return await GerarTokenAcesso(usuario.Email);
        }

        private async Task<UsuarioAutenticadoTokenViewModel> GerarTokenAcesso(string email)
        {
            var usuarioAutenticado = await _userManager.FindByEmailAsync(email);
            var claims = await _userManager.GetClaimsAsync(usuarioAutenticado);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, usuarioAutenticado.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, usuarioAutenticado.Email));
            claims.Add(new Claim(ClaimTypes.Role, "Administrator"));
            claims.Add(new Claim("permissions", "PodeExcluirProduto, PodeExcluirCategoria"));

            var claimsIdentity = new ClaimsIdentity();
            claimsIdentity.AddClaims(claims);

            

            var tokenHandler = new JwtSecurityTokenHandler();
            var secret = Encoding.ASCII.GetBytes(_jwtConfiguration.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _jwtConfiguration.Issuer,
                Audience = _jwtConfiguration.Audience,
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddHours(_jwtConfiguration.ExpiredTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature)
            });

            var usuarioAutenticadoToken = new UsuarioAutenticadoTokenViewModel {                
                Token = tokenHandler.WriteToken(token)
            };

            return usuarioAutenticadoToken;
        }
    }
}