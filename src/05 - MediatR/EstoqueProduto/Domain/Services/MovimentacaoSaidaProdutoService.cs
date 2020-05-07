using System.Collections.Generic;
using System.Threading.Tasks;
using EstoqueProduto.Domain.Command;
using EstoqueProduto.Domain.Contracts.Data;
using EstoqueProduto.Domain.Contracts.Service;
using EstoqueProduto.Domain.Entities;
using EstoqueProduto.Domain.Validations;
using EstoqueProduto.Infra.Notifications;
using MediatR;

namespace EstoqueProduto.Domain.Services
{
    public class MovimentacaoSaidaProdutoService : IMovimentacaoSaidaProdutoService
    {
        private readonly IMovimentacaoSaidaProdutoRepository _movimentacaoSaidaProdutoRepository;
        private readonly IProdutoService _produtoService;
        private readonly IEstoqueService _estoqueService;
        private readonly IMediator _mediator;
        private readonly IRequestNotificator _notifications;
        public MovimentacaoSaidaProdutoService(IMovimentacaoSaidaProdutoRepository movimentacaoSaidaProdutoRepository,
                                IRequestNotificator notifications,
                                IProdutoService produtoService,
                                IEstoqueService estoqueService,
                                IMediator mediator)
        {
            _movimentacaoSaidaProdutoRepository = movimentacaoSaidaProdutoRepository;
            _produtoService = produtoService;
            _estoqueService = estoqueService;
            _mediator = mediator;
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

            var produto = await _produtoService.BuscarPorIdAsync(movimentacaoSaidaProduto.ProdutoId);
            var quantidadeAtualProduto = produto.BuscarQuantidadeAtual();

            var estoqueProduto = await _estoqueService.BuscarPorIdProdutoAsync(movimentacaoSaidaProduto.ProdutoId);

            if (quantidadeAtualProduto <= estoqueProduto.QuantidadeMinima) 
            {
                var response = await _mediator.Send(new QuantidadeMinimaAtingidaCommand 
                { 
                    NomeProduto = produto.Nome 
                });
            }
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