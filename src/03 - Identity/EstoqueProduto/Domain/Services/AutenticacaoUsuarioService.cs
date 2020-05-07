using System.Linq;
using System.Threading.Tasks;
using EstoqueProduto.Domain.Contracts.Service;
using EstoqueProduto.Domain.Validations;
using EstoqueProduto.Infra.Notifications;
using EstoqueProduto.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace EstoqueProduto.Domain.Services
{
    public class AutenticacaoUsuarioService : IAutenticacaoUsuarioService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IRequestNotificator _notifications;
        public AutenticacaoUsuarioService(UserManager<IdentityUser> userManager,
                                            SignInManager<IdentityUser> signInManager,
                                            IRequestNotificator notifications)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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

        public async Task Login(IdentityUser usuario, string senha)
        {
            var validationLoginResult = new LoginValidation().Validate(usuario);
            var validationSenhaUsuarioResult = new SenhaUsuarioValidation().Validate(senha);

            if (!validationLoginResult.IsValid)  
            {
                _notifications.Add(validationLoginResult);                
                return;
            }

            if (!validationSenhaUsuarioResult.IsValid)  
            {
                _notifications.Add(validationSenhaUsuarioResult);                
                return;
            }

            var result = await _signInManager.PasswordSignInAsync(usuario.Email, senha, false, false);
            if (!result.Succeeded) 
            {
                _notifications.Add("E-mail ou senha incorretos.");
                return;
            }
        }
    }
}