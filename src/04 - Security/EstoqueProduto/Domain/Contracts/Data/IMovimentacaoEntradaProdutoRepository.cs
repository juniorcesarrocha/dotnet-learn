using System.Collections.Generic;
using System.Threading.Tasks;
using EstoqueProduto.Domain.Entities;

namespace EstoqueProduto.Domain.Contracts.Data
{
    public interface IMovimentacaoEntradaProdutoRepository : IRepository<MovimentacaoEntradaProduto>
    {
         Task<IEnumerable<MovimentacaoEntradaProduto>> ListarPorIdProdutoAsync(int idProduto);
    }
}