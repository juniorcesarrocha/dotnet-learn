using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using EstoqueProduto.Infra.Security.Utils;

namespace EstoqueProduto.Infra.Security.Policies
{
    public class ExcluirProdutoRequirementHandler : AuthorizationHandler<ExcluirProdutoRequirement>
    {
        private const string AdministratorRoleName = "Administrator";
	    private AuthorizationHandlerContext _context;
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ExcluirProdutoRequirement requirement)
        {
            _context = context;

            var isAdministrator = IsAdministrator();
            var canDeleteUser = HasRequirements(requirement);

            if (isAdministrator && canDeleteUser)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }

        private bool IsAdministrator() => _context.User.HasClaim(ClaimTypes.Role, AdministratorRoleName);

        private bool HasRequirements(ExcluirProdutoRequirement requirement) =>
            _context.User.HasPermissionClaim(requirement.RequiredPermission);
    }
}