using System.Threading.Tasks;
using EstoqueProduto.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace EstoqueProduto.Domain.Contracts.Service
{
    public interface IAutenticacaoUsuarioService
    {
         Task Registrar(IdentityUser novoUsuario, string senha);
         Task<UsuarioAutenticadoTokenViewModel> Login(IdentityUser login, string senha);
    }
}