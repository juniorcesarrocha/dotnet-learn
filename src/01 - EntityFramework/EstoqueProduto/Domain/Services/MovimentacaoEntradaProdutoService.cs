using System.Collections.Generic;
using System.Threading.Tasks;
using EstoqueProduto.Domain.Contracts.Data;
using EstoqueProduto.Domain.Contracts.Service;
using EstoqueProduto.Domain.Entities;

namespace EstoqueProduto.Domain.Services
{
    public class MovimentacaoEntradaProdutoService : IMovimentacaoEntradaProdutoService
    {
        private readonly IMovimentacaoEntradaProdutoRepository _movimentacaoEntradaProdutoRepository;
        public MovimentacaoEntradaProdutoService(IMovimentacaoEntradaProdutoRepository movimentacaoEntradaProdutoRepository)
        {
            _movimentacaoEntradaProdutoRepository = movimentacaoEntradaProdutoRepository;
        }
        public async Task<IEnumerable<MovimentacaoEntradaProduto>> ListarPorIdProdutoAsync(int idProduto)
        {
            return await _movimentacaoEntradaProdutoRepository.ListarPorIdProdutoAsync(idProduto);
        }        
        public async Task InserirAsync(MovimentacaoEntradaProduto movimentacaoEntradaProduto)
        {
            await _movimentacaoEntradaProdutoRepository.InserirAsync(movimentacaoEntradaProduto);
            await _movimentacaoEntradaProdutoRepository.CommitAsync();
        }
        public async Task AtualizarAsync(MovimentacaoEntradaProduto movimentacaoEntradaProduto)
        {
            _movimentacaoEntradaProdutoRepository.AtualizarAsync(movimentacaoEntradaProduto);
            await _movimentacaoEntradaProdutoRepository.CommitAsync();
        }
    }
}