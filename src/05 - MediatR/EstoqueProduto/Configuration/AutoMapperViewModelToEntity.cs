using AutoMapper;
using EstoqueProduto.Domain.Entities;
using EstoqueProduto.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace EstoqueProduto.Configuration
{
    public class AutoMapperViewModelToEntity : Profile
    {
        public AutoMapperViewModelToEntity()
        {
            CategoriaMap();
            ProdutoMap();
            EstoqueMap();
            MovimentacaoEntradaProdutoMap();
            MovimentacaoSaidaProdutoMap();
            LoginMap();
        }

        private void CategoriaMap()
        {
            CreateMap<CategoriaViewModel, Categoria>();
            CreateMap<NovaCategoriaViewModel, Categoria>();
        }

        private void ProdutoMap()
        {
            CreateMap<ProdutoViewModel, Produto>();
            CreateMap<NovoProdutoViewModel, Produto>();
            CreateMap<AtualizaProdutoViewModel, Produto>();
        }

        private void EstoqueMap() 
        {
            CreateMap<EstoqueViewModel, Estoque>();
            CreateMap<NovoEstoqueViewModel, Estoque>();
        }

        private void MovimentacaoEntradaProdutoMap() 
        {
            CreateMap<MovimentacaoEntradaProdutoViewModel, MovimentacaoEntradaProduto>();
            CreateMap<NovaMovimentacaoEntradaProdutoViewModel, MovimentacaoEntradaProduto>();
        }

        private void MovimentacaoSaidaProdutoMap() 
        {
            CreateMap<MovimentacaoSaidaProdutoViewModel, MovimentacaoSaidaProduto>();
            CreateMap<NovaMovimentacaoSaidaProdutoViewModel, MovimentacaoSaidaProduto>();
        }

        private void LoginMap()
        {
            CreateMap<LoginViewModel, IdentityUser>()
                .ForPath(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForPath(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
        }        
    }
}