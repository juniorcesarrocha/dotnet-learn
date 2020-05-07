using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using EstoqueProduto.Domain.Contracts.Data;
using EstoqueProduto.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EstoqueProduto.Infra.Data.Repository
{
    public class MovimentacaoSaidaProdutoRepository: Repository<MovimentacaoSaidaProduto>, IMovimentacaoSaidaProdutoRepository
    {
        public MovimentacaoSaidaProdutoRepository(EstoqueProdutoContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<MovimentacaoSaidaProduto>> ListarPorIdProdutoAsync(int idProduto)
        {
            return await _dbContext.MovimentacaoSaidaProduto.Where(x => x.ProdutoId == idProduto).ToListAsync();
        }
    }
}