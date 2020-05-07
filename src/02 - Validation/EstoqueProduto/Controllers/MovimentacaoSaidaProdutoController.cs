using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EstoqueProduto.Domain.Contracts.Service;
using EstoqueProduto.Domain.Entities;
using EstoqueProduto.Infra.Notifications;
using EstoqueProduto.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EstoqueProduto.Controllers
{
    [ApiController]
    [Route("api/saida-produtos")]
    public class MovimentacaoSaidaProdutoController : ApiControllerBase
    {
        private readonly IMovimentacaoSaidaProdutoService _movimentacaoSaidaProdutoService;
        private readonly IMapper _mapper;
        public MovimentacaoSaidaProdutoController(IMovimentacaoSaidaProdutoService movimentacaoSaidaProdutoService, 
                                IMapper mapper,
                                IRequestNotificator notificator) : base(notificator)
        {
            _movimentacaoSaidaProdutoService = movimentacaoSaidaProdutoService;
            _mapper = mapper;
        }
        
        [HttpPost]
        public async Task<IActionResult> Inserir(NovaMovimentacaoSaidaProdutoViewModel movimentacaoSaidaProdutoViewModel)
        {
            var movimentacaoSaidaProduto = _mapper.Map<MovimentacaoSaidaProduto>(movimentacaoSaidaProdutoViewModel);
            await _movimentacaoSaidaProdutoService.InserirAsync(movimentacaoSaidaProduto);
            return Result();
        }
        [HttpPut]
        public async Task<IActionResult> Atualizar(MovimentacaoSaidaProdutoViewModel movimentacaoSaidaProdutoViewModel)
        {
            var movimentacaoSaidaProduto = _mapper.Map<MovimentacaoSaidaProduto>(movimentacaoSaidaProdutoViewModel);
            await _movimentacaoSaidaProdutoService.AtualizarAsync(movimentacaoSaidaProduto);
            return Result();
        }        
    }
}
