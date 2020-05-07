using System.Collections.Generic;
using System.Threading.Tasks;
using EstoqueProduto.Domain.Contracts.Data;
using EstoqueProduto.Domain.Contracts.Service;
using EstoqueProduto.Domain.Entities;

namespace EstoqueProduto.Domain.Services
{
    public class MovimentacaoSaidaProdutoService : IMovimentacaoSaidaProdutoService
    {
        private readonly IMovimentacaoSaidaProdutoRepository _movimentacaoSaidaProdutoRepository;
        public MovimentacaoSaidaProdutoService(IMovimentacaoSaidaProdutoRepository movimentacaoSaidaProdutoRepository)
        {
            _movimentacaoSaidaProdutoRepository = movimentacaoSaidaProdutoRepository;
        }
        public async Task<IEnumerable<MovimentacaoSaidaProduto>> ListarPorIdProdutoAsync(int idProduto)
        {
            return await _movimentacaoSaidaProdutoRepository.ListarPorIdProdutoAsync(idProduto);
        }        
        public async Task InserirAsync(MovimentacaoSaidaProduto movimentacaoSaidaProduto)
        {
            await _movimentacaoSaidaProdutoRepository.InserirAsync(movimentacaoSaidaProduto);
            await _movimentacaoSaidaProdutoRepository.CommitAsync();
        }
        public async Task AtualizarAsync(MovimentacaoSaidaProduto movimentacaoSaidaProduto)
        {
            _movimentacaoSaidaProdutoRepository.AtualizarAsync(movimentacaoSaidaProduto);
            await _movimentacaoSaidaProdutoRepository.CommitAsync();
        }
    }
}