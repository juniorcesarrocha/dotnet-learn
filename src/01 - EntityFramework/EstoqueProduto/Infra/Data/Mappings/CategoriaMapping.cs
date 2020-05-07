using EstoqueProduto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstoqueProduto.Infra.Data.Mappings
{
    public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {            
            builder.Property(c => c.Id)
                .IsRequired();
            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(c => c.Descricao)
                .HasMaxLength(500);
            builder.HasMany(c => c.Produtos).WithOne(p => p.Categoria)
                .HasForeignKey(p => p.CategoriaId);
                
            builder.ToTable("Categorias");
        }
    }
}