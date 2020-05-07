using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using EstoqueProduto.Infra.Security.Utils;

namespace EstoqueProduto.Infra.Security.Policies
{
    public class ExcluirCategoriaRequirementHandler : AuthorizationHandler<ExcluirCategoriaRequirement>
    {
        private const string AdministratorRoleName = "Administrator";
	    private AuthorizationHandlerContext _context;
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ExcluirCategoriaRequirement requirement)
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

        private bool IsAdministrator() => 
            _context.User.HasClaim(ClaimTypes.Role, AdministratorRoleName);

        private bool HasRequirements(ExcluirCategoriaRequirement requirement) => 
            _context.User.HasPermissionClaim(requirement.RequiredPermission);
    }
}