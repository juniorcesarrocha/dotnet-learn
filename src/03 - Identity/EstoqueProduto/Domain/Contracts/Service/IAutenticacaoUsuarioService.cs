using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EstoqueProduto.Domain.Contracts.Service
{
    public interface IAutenticacaoUsuarioService
    {
         Task Registrar(IdentityUser novoUsuario, string senha);
         Task Login(IdentityUser login, string senha);
    }
}