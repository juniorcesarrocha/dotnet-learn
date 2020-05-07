using EstoqueProduto.Domain.Entities;
using FluentValidation;

namespace EstoqueProduto.Domain.Validations
{
    public class MovimentacaoSaidaProdutoValidation : AbstractValidator<MovimentacaoSaidaProduto>
    {
        public MovimentacaoSaidaProdutoValidation() {}

        public void ValidarId() 
        {
            var propertyName = "Identificador";
            RuleFor(c => c.Id)            
            .NotEmpty().WithName(propertyName).WithMessage("O campo {PropertyName} é obrigatório.");
        }

        public void ValidarDataSaida() 
        {
            var propertyName = "Data de Saida";
            RuleFor(c => c.DataSaida)            
            .NotEmpty().WithName(propertyName).WithMessage("O campo {PropertyName} é obrigatório.");
        }

        public void ValidarQuantidade() 
        {
            var propertyName = "Quantidade";
            RuleFor(c => c.QuantidadeSaida)            
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