using EstoqueProduto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstoqueProduto.Infra.Data.Mappings
{
    public class ProdutoMapping: IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {            
            builder.Property(c => c.Id)
                .IsRequired();
            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(c => c.Descricao)
                .IsRequired()
                .HasMaxLength(1000);
            builder.Property(c => c.UnidadeConsumo)
                .IsRequired()
                .HasMaxLength(10);
            builder.Property(c => c.ValorUnitario)
                .IsRequired();
            builder.Property(c => c.CodigoBarra)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(c => c.DataVencimento);
            builder.Property(c => c.Ativo)
                .IsRequired();

            builder.HasMany(c => c.MovimentacaoEntradaProdutos)
                .WithOne(p => p.Produto)
                .HasForeignKey(p => p.ProdutoId);
            
            builder.HasMany(c => c.MovimentacaoSaidaProdutos)
                .WithOne(p => p.Produto)
                .HasForeignKey(p => p.ProdutoId);

            builder.ToTable("Produtos");
        }
    }
}