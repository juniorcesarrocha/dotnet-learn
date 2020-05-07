using EstoqueProduto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstoqueProduto.Infra.Data.Mappings
{
    public class MovimentacaoEntradaEstoqueMapping : IEntityTypeConfiguration<MovimentacaoEntradaProduto>
    {
        public void Configure(EntityTypeBuilder<MovimentacaoEntradaProduto> builder)
        {            
            builder.Property(c => c.Id)
                .IsRequired();
            builder.Property(c => c.DataEntrada)
                .IsRequired();
            builder.Property(c => c.QuantidadeEntrada)
                .IsRequired();
            builder.ToTable("MovimentacaoEntradaProdutos");
        }
    }
}