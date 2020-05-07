using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EstoqueProduto.Domain.Contracts.Service;
using EstoqueProduto.Domain.Entities;
using EstoqueProduto.Infra.Notifications;
using EstoqueProduto.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EstoqueProduto.Controllers
{    
    [Authorize]
    [Route("api/entrada-produtos")]
    public class MovimentacaoEntradaProdutoController : ApiControllerBase
    {
        private readonly IMovimentacaoEntradaProdutoService _movimentacaoEntradaProdutoService;
        private readonly IMapper _mapper;
        public MovimentacaoEntradaProdutoController(IMovimentacaoEntradaProdutoService movimentacaoEntradaProdutoService, 
                                IMapper mapper,
                                IRequestNotificator notificator) : base(notificator)
        {
            _movimentacaoEntradaProdutoService = movimentacaoEntradaProdutoService;
            _mapper = mapper;
        }
        
        [HttpPost]
        public async Task<IActionResult> Inserir(NovaMovimentacaoEntradaProdutoViewModel movimentacaoEntradaProdutoViewModel)
        {            
            var movimentacaoEntradaProduto = _mapper.Map<MovimentacaoEntradaProduto>(movimentacaoEntradaProdutoViewModel);
            await _movimentacaoEntradaProdutoService.InserirAsync(movimentacaoEntradaProduto);
            return Result();
        }
        [HttpPut]
        public async Task<IActionResult> Atualizar(MovimentacaoEntradaProdutoViewModel movimentacaoEntradaProdutoViewModel)
        {
            var movimentacaoEntradaProduto = _mapper.Map<MovimentacaoEntradaProduto>(movimentacaoEntradaProdutoViewModel);
            await _movimentacaoEntradaProdutoService.AtualizarAsync(movimentacaoEntradaProduto);
            return Result();
        }        
    }
}
