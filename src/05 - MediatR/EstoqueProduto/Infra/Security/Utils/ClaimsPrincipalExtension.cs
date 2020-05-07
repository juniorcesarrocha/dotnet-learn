using System.Security.Claims;

namespace EstoqueProduto.Infra.Security.Utils
{
    internal static class ClaimsPrincipalExtension
    {
        public static bool HasPermissionClaim(this ClaimsPrincipal principal, string value)
        {
            var claim = principal.FindFirst("permissions");
            if (claim == null) return false;
            return claim.Value.Contains(value);
        }
    }
}