using System.Collections.Generic;
using System.Threading.Tasks;
using EstoqueProduto.Domain.Entities;

namespace EstoqueProduto.Domain.Contracts.Service
{
    public interface IMovimentacaoSaidaProdutoService
    {
        Task<IEnumerable<MovimentacaoSaidaProduto>> ListarPorIdProdutoAsync(int idProduto);
        Task InserirAsync(MovimentacaoSaidaProduto movimentacaoSaidaProduto);
        Task AtualizarAsync(MovimentacaoSaidaProduto movimentacaoSaidaProduto);        
    }
}