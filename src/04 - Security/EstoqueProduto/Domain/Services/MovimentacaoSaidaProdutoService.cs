using System.Collections.Generic;
using System.Threading.Tasks;
using EstoqueProduto.Domain.Contracts.Data;
using EstoqueProduto.Domain.Contracts.Service;
using EstoqueProduto.Domain.Entities;
using EstoqueProduto.Domain.Validations;
using EstoqueProduto.Infra.Notifications;

namespace EstoqueProduto.Domain.Services
{
    public class MovimentacaoSaidaProdutoService : IMovimentacaoSaidaProdutoService
    {
        private readonly IMovimentacaoSaidaProdutoRepository _movimentacaoSaidaProdutoRepository;
        private readonly IRequestNotificator _notifications;
        public MovimentacaoSaidaProdutoService(IMovimentacaoSaidaProdutoRepository movimentacaoSaidaProdutoRepository,
                                IRequestNotificator notifications)
        {
            _movimentacaoSaidaProdutoRepository = movimentacaoSaidaProdutoRepository;
            _notifications = notifications;
        }
        public async Task<IEnumerable<MovimentacaoSaidaProduto>> ListarPorIdProdutoAsync(int idProduto)
        {
            return await _movimentacaoSaidaProdutoRepository.ListarPorIdProdutoAsync(idProduto);
        }        
        public async Task InserirAsync(MovimentacaoSaidaProduto movimentacaoSaidaProduto)
        {
            var validationResult = new NovoMovimentacaoSaidaProdutoValidation().Validate(movimentacaoSaidaProduto);

            if (!validationResult.IsValid)  
            {
                _notifications.Add(validationResult);                
                return;
            }

            await _movimentacaoSaidaProdutoRepository.InserirAsync(movimentacaoSaidaProduto);
            await _movimentacaoSaidaProdutoRepository.CommitAsync();
        }
        public async Task AtualizarAsync(MovimentacaoSaidaProduto movimentacaoSaidaProduto)
        {
            var validationResult = new AtualizacaoMovimentacaoSaidaProdutoValidation().Validate(movimentacaoSaidaProduto);

            if (!validationResult.IsValid)  
            {
                _notifications.Add(validationResult);                
                return;
            }

            _movimentacaoSaidaProdutoRepository.AtualizarAsync(movimentacaoSaidaProduto);
            await _movimentacaoSaidaProdutoRepository.CommitAsync();
        }
    }
}