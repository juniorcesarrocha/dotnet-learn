using EstoqueProduto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstoqueProduto.Infra.Data.Mappings
{
    public class MovimentacaoSaidaEstoqueMapping : IEntityTypeConfiguration<MovimentacaoSaidaProduto>
    {
        public void Configure(EntityTypeBuilder<MovimentacaoSaidaProduto> builder)
        {            
            builder.Property(c => c.Id)
                .IsRequired();
                builder.Property(c => c.DataSaida)
                .IsRequired();
                builder.Property(c => c.QuantidadeSaida)
                    .IsRequired();
                builder.ToTable("MovimentacaoSaidaProdutos");
        }
    }
}