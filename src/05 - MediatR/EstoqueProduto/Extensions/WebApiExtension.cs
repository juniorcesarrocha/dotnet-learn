using EstoqueProduto.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EstoqueProduto.Extensions
{
    public static class WebApiExtension
    {
        public static void WebApiConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.Configure<SmtpSettings>(configuration.GetSection("SmtpSettings"));
        }
    }
}