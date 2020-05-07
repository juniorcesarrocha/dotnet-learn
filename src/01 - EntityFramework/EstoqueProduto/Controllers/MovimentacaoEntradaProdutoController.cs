using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EstoqueProduto.Domain.Contracts.Service;
using EstoqueProduto.Domain.Entities;
using EstoqueProduto.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EstoqueProduto.Controllers
{
    [ApiController]
    [Route("api/entrada-produtos")]
    public class MovimentacaoEntradaProdutoController : ControllerBase
    {
        private readonly IMovimentacaoEntradaProdutoService _movimentacaoEntradaProdutoService;
        private readonly IMapper _mapper;
        public MovimentacaoEntradaProdutoController(IMovimentacaoEntradaProdutoService movimentacaoEntradaProdutoService, 
                                IMapper mapper)
        {
            _movimentacaoEntradaProdutoService = movimentacaoEntradaProdutoService;
            _mapper = mapper;
        }
        
        [HttpPost]
        public async Task Inserir(NovaMovimentacaoEntradaProdutoViewModel movimentacaoEntradaProdutoViewModel)
        {
            var movimentacaoEntradaProduto = _mapper.Map<MovimentacaoEntradaProduto>(movimentacaoEntradaProdutoViewModel);
            await _movimentacaoEntradaProdutoService.InserirAsync(movimentacaoEntradaProduto);
        }
        [HttpPut]
        public async Task Atualizar(MovimentacaoEntradaProdutoViewModel movimentacaoEntradaProdutoViewModel)
        {
            var movimentacaoEntradaProduto = _mapper.Map<MovimentacaoEntradaProduto>(movimentacaoEntradaProdutoViewModel);
            await _movimentacaoEntradaProdutoService.AtualizarAsync(movimentacaoEntradaProduto);
        }        
    }
}
