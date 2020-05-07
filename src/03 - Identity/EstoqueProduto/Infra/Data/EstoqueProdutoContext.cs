using System.Reflection;
using EstoqueProduto.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EstoqueProduto.Infra.Data
{
    public class EstoqueProdutoContext: DbContext
    {
        public EstoqueProdutoContext(DbContextOptions<EstoqueProdutoContext> options)
            : base(options)
        {
        }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<Categoria> Categora { get; set; }
        public DbSet<Estoque> Estoque { get; set; }
        public DbSet<MovimentacaoEntradaProduto> MovimentacaoEntradaProduto { get; set; }
        public DbSet<MovimentacaoSaidaProduto> MovimentacaoSaidaProduto { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=estoque.db");
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}