using EstoqueProduto.Infra.Data;
using EstoqueProduto.Infra.Messages;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EstoqueProduto.Extensions
{
    public static class IdentityUserExtension
    {
        public static void IdentityUserConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {                        
            services.AddDbContext<IdentityUserContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("UserConnection")));
            
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityUserContext>()
                .AddErrorDescriber<IdentityMessageError>()
                .AddDefaultTokenProviders();
        }   
    }
}