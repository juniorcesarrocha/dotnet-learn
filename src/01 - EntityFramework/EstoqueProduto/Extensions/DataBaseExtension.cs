using EstoqueProduto.Infra.Data;
using Microsoft.Extensions.DependencyInjection;

namespace EstoqueProduto.Extensions
{
    public static class DataBaseExtension
    {
        public static void DataBaseConfigureServices(this IServiceCollection services)
        {
            services.AddDbContext<EstoqueProdutoContext>();
        }
    }
}