using System.Linq;
using System.Threading.Tasks;
using EstoqueProduto.Domain.Contracts.Data;
using EstoqueProduto.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EstoqueProduto.Infra.Data.Repository
{
    public class EstoqueRepository : Repository<Estoque>, IEstoqueRepository
    {
        public EstoqueRepository(EstoqueProdutoContext dbContext) : base(dbContext)
        {
        }

        public async Task<Estoque> BuscarPorIdProdutoAsync(int produtoId)
        {
            return await _dbContext.Estoque.Where(x => x.ProdutoId == produtoId).FirstAsync();
        }
    }
}