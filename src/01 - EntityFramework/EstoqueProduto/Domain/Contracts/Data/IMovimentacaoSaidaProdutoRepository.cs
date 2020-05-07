using System.Collections.Generic;
using System.Threading.Tasks;
using EstoqueProduto.Domain.Entities;

namespace EstoqueProduto.Domain.Contracts.Data
{
    public interface IMovimentacaoSaidaProdutoRepository : IRepository<MovimentacaoSaidaProduto>
    {
        Task<IEnumerable<MovimentacaoSaidaProduto>> ListarPorIdProdutoAsync(int idProduto);
    }
}