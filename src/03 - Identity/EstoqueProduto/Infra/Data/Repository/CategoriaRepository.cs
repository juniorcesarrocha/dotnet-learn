using EstoqueProduto.Domain.Contracts.Data;
using EstoqueProduto.Domain.Entities;

namespace EstoqueProduto.Infra.Data.Repository
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(EstoqueProdutoContext dbContext) : base(dbContext)
        {
        }
    }
}