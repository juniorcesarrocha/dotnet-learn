using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace EstoqueProduto.Extensions
{
    public static class AutoMapperExtension
    {
        public static void AutoMapperConfigureServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
        }
    }
}