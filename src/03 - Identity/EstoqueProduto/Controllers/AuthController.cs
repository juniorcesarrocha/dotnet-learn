using System.Threading.Tasks;
using AutoMapper;
using EstoqueProduto.Domain.Contracts.Service;
using EstoqueProduto.Infra.Notifications;
using EstoqueProduto.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueProduto.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ApiControllerBase
    {
        private readonly IAutenticacaoUsuarioService _autenticacaoUsuarioService;
        private readonly IMapper _mapper;
        public AuthController(IRequestNotificator notificator,
                                IMapper mapper, 
                                IAutenticacaoUsuarioService autenticacaoUsuarioService) : base(notificator)
        {
            _autenticacaoUsuarioService = autenticacaoUsuarioService;
            _mapper = mapper;
        }
        [HttpPost("registrar")]
        [AllowAnonymous]        
        public async Task<IActionResult> Registrar(LoginViewModel registroNovoUsuario)
        {
            var novoUsuario = _mapper.Map<IdentityUser>(registroNovoUsuario);
            await _autenticacaoUsuarioService.Registrar(novoUsuario, registroNovoUsuario.Senha);
            
            return Result();
        }

        [HttpPost("entrar")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            var usuario = _mapper.Map<IdentityUser>(login);
            await _autenticacaoUsuarioService.Login(usuario, login.Senha);
            
            return Result();
        }
    }
}