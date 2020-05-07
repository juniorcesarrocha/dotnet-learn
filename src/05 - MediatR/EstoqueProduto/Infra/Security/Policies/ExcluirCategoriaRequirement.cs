using Microsoft.AspNetCore.Authorization;

namespace EstoqueProduto.Infra.Security.Policies
{
    public class ExcluirCategoriaRequirement : IAuthorizationRequirement
    {
        public string RequiredPermission { get; }

        public ExcluirCategoriaRequirement(string requiredPermission)
        {
            RequiredPermission = requiredPermission;
        }
    }
}