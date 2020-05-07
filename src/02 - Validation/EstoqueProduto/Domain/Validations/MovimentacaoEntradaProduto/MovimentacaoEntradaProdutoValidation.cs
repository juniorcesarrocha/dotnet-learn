using EstoqueProduto.Domain.Entities;
using FluentValidation;

namespace EstoqueProduto.Domain.Validations
{
    public class MovimentacaoEntradaProdutoValidation : AbstractValidator<MovimentacaoEntradaProduto>
    {
        public MovimentacaoEntradaProdutoValidation() {}

        public void ValidarId() 
        {
            var propertyName = "Identificador";
            RuleFor(c => c.Id)            
            .NotEmpty().WithName(propertyName).WithMessage("O campo {PropertyName} é obrigatório.");
        }

        public void ValidarDataEntrada() 
        {
            var propertyName = "Data de Entrada";
            RuleFor(c => c.DataEntrada)            
            .NotEmpty().WithName(propertyName).WithMessage("O campo {PropertyName} é obrigatório.");
        }

        public void ValidarQuantidade() 
        {
            var propertyName = "Quantidade";
            RuleFor(c => c.QuantidadeEntrada)            
            .NotEmpty().WithName(propertyName).WithMessage("O campo {PropertyName} é obrigatório.")
            .GreaterThan(0).WithName(propertyName).WithMessage("O campo {PropertyName} precisa ser maior que zero.");
        }

        public void ValidarProduto() 
        {
            var propertyName = "Produto";
            RuleFor(c => c.ProdutoId)                
                .NotEmpty().WithName(propertyName).WithMessage("O campo {PropertyName} é obrigatório.")
                .GreaterThan(0).WithName(propertyName).WithMessage("O campo {PropertyName} precisa ser maior que zero.");
        }
    }
}