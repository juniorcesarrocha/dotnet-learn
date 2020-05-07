using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using EstoqueProduto.Domain.Contracts.Data;
using EstoqueProduto.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EstoqueProduto.Infra.Data.Repository
{
    public class MovimentacaoEntradaProdutoRepository: Repository<MovimentacaoEntradaProduto>, IMovimentacaoEntradaProdutoRepository
    {
        public MovimentacaoEntradaProdutoRepository(EstoqueProdutoContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<MovimentacaoEntradaProduto>> ListarPorIdProdutoAsync(int idProduto)
        {
            return await _dbContext.MovimentacaoEntradaProduto.Where(x => x.ProdutoId == idProduto).ToListAsync();
        }
    }
}