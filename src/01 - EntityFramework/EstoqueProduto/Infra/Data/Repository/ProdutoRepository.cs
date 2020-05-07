using System.Linq;
using System.Threading.Tasks;
using EstoqueProduto.Domain.Contracts.Data;
using EstoqueProduto.Domain.Entities;

namespace EstoqueProduto.Infra.Data.Repository
{
    public class ProdutoRepository: Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(EstoqueProdutoContext dbContext) : base(dbContext)
        {            
        }

        public override async Task<Produto> BuscarPorIdAsync(int id) {
            var produto = await _dbContext.Set<Produto>().FindAsync(id);

            await _dbContext.Entry(produto)
                .Collection(p => p.MovimentacaoEntradaProdutos).LoadAsync();

            await _dbContext.Entry(produto)
                .Collection(p => p.MovimentacaoSaidaProdutos).LoadAsync();
            
            return produto;
        }
    }
}