using EstoqueProduto.Domain.Contracts.Data;
using EstoqueProduto.Domain.Contracts.Service;
using EstoqueProduto.Domain.Services;
using EstoqueProduto.Infra.Data.Repository;
using EstoqueProduto.Infra.Http;
using EstoqueProduto.Infra.Notifications;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace EstoqueProduto.Extensions
{
    public static class DomainExtension
    {
        public static void DomainConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IEstoqueService, EstoqueService>();
            services.AddScoped<IMovimentacaoEntradaProdutoService, MovimentacaoEntradaProdutoService>();
            services.AddScoped<IMovimentacaoSaidaProdutoService, MovimentacaoSaidaProdutoService>();
            
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IEstoqueRepository, EstoqueRepository>();
            services.AddScoped<IMovimentacaoEntradaProdutoRepository, MovimentacaoEntradaProdutoRepository>();
            services.AddScoped<IMovimentacaoSaidaProdutoRepository, MovimentacaoSaidaProdutoRepository>();
            
            services.AddScoped<IAutenticacaoUsuarioService, AutenticacaoUsuarioService>();
            
            services.AddScoped<IRequestNotificator, RequestNotificator>();
            services.AddSingleton<IEmail, Email>();
            
        }
    }
}