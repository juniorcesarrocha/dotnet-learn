using EstoqueProduto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstoqueProduto.Infra.Data.Mappings
{
    public class EstoqueMapping : IEntityTypeConfiguration<Estoque>
    {
        public void Configure(EntityTypeBuilder<Estoque> builder)
        {            
            builder.Property(c => c.Id)
                .IsRequired();
            builder.HasOne(c => c.Produto).WithOne(p => p.Estoque)
		        .HasForeignKey<Estoque>(e => e.ProdutoId);
            builder.Property(c => c.Localizacao)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(c => c.QuantidadeMinima)
                .IsRequired();
            builder.Property(c => c.QuantidadeMaxima);            
            builder.ToTable("Estoques");
        }
    }
}