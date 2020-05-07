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
    [Route("api/categorias")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;
        private readonly IMapper _mapper;
        public CategoriaController(ICategoriaService categoriaService, 
                                IMapper mapper)
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
        public async Task Inserir(NovaCategoriaViewModel categoriaViewModel)
        {
            var categoria = _mapper.Map<Categoria>(categoriaViewModel);
            await _categoriaService.InserirAsync(categoria);
        }
        [HttpPut]
        public async Task Atualizar(CategoriaViewModel categoriaViewModel)
        {
            var categoria = _mapper.Map<Categoria>(categoriaViewModel);
            await _categoriaService.AtualizarAsync(categoria);
        }
        [HttpDelete("{id:int}")]
        public async Task Remover(int id)
        {            
            await _categoriaService.RemoverAsync(id);
        }
    }
}
