using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EstoqueProduto.Domain.Contracts.Service;
using EstoqueProduto.Domain.Entities;
using EstoqueProduto.Infra.Notifications;
using EstoqueProduto.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EstoqueProduto.Controllers
{
    
    [Authorize(Roles = "Administrator")]
    [Route("api/categorias")]
    public class CategoriaController : ApiControllerBase
    {
        private readonly ICategoriaService _categoriaService;
        private readonly IMapper _mapper;        
        public CategoriaController(ICategoriaService categoriaService, 
                                IMapper mapper,
                                IRequestNotificator notifications) : base(notifications)
        {
            _categoriaService = categoriaService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<CategoriaViewModel>> Get()
        {
            return _mapper.Map<IEnumerable<CategoriaViewModel>>(await _categoriaService.ListarTodosAsync());
        }
        [HttpGet("{id:int}")]
        public async Task<CategoriaViewModel> Get(int id)
        {
            return _mapper.Map<CategoriaViewModel>(await _categoriaService.BuscarPorIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Inserir(NovaCategoriaViewModel categoriaViewModel)
        {
            var categoria = _mapper.Map<Categoria>(categoriaViewModel);
            await _categoriaService.InserirAsync(categoria);
            return Result();
        }
        [HttpPut]
        public async Task<IActionResult> Atualizar(CategoriaViewModel categoriaViewModel)
        {
            var categoria = _mapper.Map<Categoria>(categoriaViewModel);
            await _categoriaService.AtualizarAsync(categoria);
            return Result();
        }
        [HttpDelete("{id:int}"), Authorize(Policy = "ExcluirCategoriaPolicy")]
        public async Task<IActionResult> Remover(int id)
        {            
            await _categoriaService.RemoverAsync(id);
            return Result();
        }
    }
}
