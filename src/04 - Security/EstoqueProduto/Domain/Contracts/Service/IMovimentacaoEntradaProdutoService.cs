using System.Collections.Generic;
using System.Threading.Tasks;
using EstoqueProduto.Domain.Entities;

namespace EstoqueProduto.Domain.Contracts.Service
{
    public interface IMovimentacaoEntradaProdutoService
    {
        Task<IEnumerable<MovimentacaoEntradaProduto>> ListarPorIdProdutoAsync(int idProduto);
        Task InserirAsync(MovimentacaoEntradaProduto movimentacaoEntradaProduto);
        Task AtualizarAsync(MovimentacaoEntradaProduto movimentacaoEntradaProduto);
    }
}