using Microsoft.AspNetCore.Authorization;

namespace EstoqueProduto.Infra.Security.Policies
{
    public class ExcluirProdutoRequirement : IAuthorizationRequirement
    {
        public string RequiredPermission { get; }

        public ExcluirProdutoRequirement(string requiredPermission)
        {
            RequiredPermission = requiredPermission;
        }
    }
}