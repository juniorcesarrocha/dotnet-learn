using System.Collections.Generic;
using System.Threading.Tasks;
using EstoqueProduto.Domain.Contracts.Data;
using EstoqueProduto.Domain.Contracts.Service;
using EstoqueProduto.Domain.Entities;
using EstoqueProduto.Domain.Validations;
using EstoqueProduto.Infra.Notifications;

namespace EstoqueProduto.Domain.Services
{
    public class MovimentacaoEntradaProdutoService : IMovimentacaoEntradaProdutoService
    {
        private readonly IMovimentacaoEntradaProdutoRepository _movimentacaoEntradaProdutoRepository;
        private readonly IRequestNotificator _notifications;
        public MovimentacaoEntradaProdutoService(IMovimentacaoEntradaProdutoRepository movimentacaoEntradaProdutoRepository,
                                IRequestNotificator notifications)
        {
            _movimentacaoEntradaProdutoRepository = movimentacaoEntradaProdutoRepository;
            _notifications = notifications;
        }
        public async Task<IEnumerable<MovimentacaoEntradaProduto>> ListarPorIdProdutoAsync(int idProduto)
        {
            return await _movimentacaoEntradaProdutoRepository.ListarPorIdProdutoAsync(idProduto);
        }        
        public async Task InserirAsync(MovimentacaoEntradaProduto movimentacaoEntradaProduto)
        {
            var validationResult = new NovoMovimentacaoEntradaProdutoValidation().Validate(movimentacaoEntradaProduto);

            if (!validationResult.IsValid)  
            {
                _notifications.Add(validationResult);                
                return;
            }

            await _movimentacaoEntradaProdutoRepository.InserirAsync(movimentacaoEntradaProduto);
            await _movimentacaoEntradaProdutoRepository.CommitAsync();
        }
        public async Task AtualizarAsync(MovimentacaoEntradaProduto movimentacaoEntradaProduto)
        {
            var validationResult = new AtualizacaoMovimentacaoEntradaProdutoValidation().Validate(movimentacaoEntradaProduto);

            if (!validationResult.IsValid)  
            {
                _notifications.Add(validationResult);                
                return;
            }

            _movimentacaoEntradaProdutoRepository.AtualizarAsync(movimentacaoEntradaProduto);
            await _movimentacaoEntradaProdutoRepository.CommitAsync();
        }
    }
}