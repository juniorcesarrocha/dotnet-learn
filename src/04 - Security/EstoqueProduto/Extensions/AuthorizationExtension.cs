using EstoqueProduto.Infra.Security.Policies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace EstoqueProduto.Extensions
{
    public static class AuthorizationExtension
    {
        public static void AuthorizationConfigureServices(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ExcluirCategoriaPolicy", policy =>
                    policy.Requirements.Add(new ExcluirCategoriaRequirement("PodeExcluirCategoria")));

                options.AddPolicy("ExcluirProdutoPolicy", policy =>
                    policy.Requirements.Add(new ExcluirProdutoRequirement("PodeExcluirProduto")));
            });

            services.AddSingleton<IAuthorizationHandler, ExcluirCategoriaRequirementHandler>();
            services.AddSingleton<IAuthorizationHandler, ExcluirProdutoRequirementHandler>();
        }
    }
}