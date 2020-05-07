using EstoqueProduto.Domain.Entities;
using FluentValidation;

namespace EstoqueProduto.Domain.Validations
{
    public class EstoqueValidation : AbstractValidator<Estoque>
    {
        public EstoqueValidation() {}

        public void ValidarId() 
        {
            var propertyName = "Identificador";
            RuleFor(c => c.Id)            
            .NotEmpty().WithName(propertyName).WithMessage("O campo {PropertyName} é obrigatório.");
        }

        public void ValidarProduto() 
        {
            var propertyName = "Produto";
            RuleFor(c => c.ProdutoId)                
                .NotEmpty().WithName(propertyName).WithMessage("O campo {PropertyName} é obrigatório.")
                .GreaterThan(0).WithName(propertyName).WithMessage("O campo {PropertyName} precisa ser maior que zero.");
        }

        public void ValidarLocalizacao() 
        {
            var propertyName = "Localização";
            RuleFor(c => c.Localizacao)                
                .NotEmpty().WithName(propertyName).WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(2, 10).WithName(propertyName).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");
        }

        public void ValidarQuantidadeMinima() 
        {
            var propertyName = "Quantidade Mínima";
            RuleFor(c => c.QuantidadeMinima)                
                .NotEmpty().WithName(propertyName).WithMessage("O campo {PropertyName} é obrigatório.")
                .GreaterThan(0).WithName(propertyName).WithMessage("O campo {PropertyName} precisa ser maior que zero.");                
        }

        public void ValidarQuantidadeMaxima() 
        {
            var propertyName = "Quantidade Máxima";
            When(c => c.QuantidadeMaxima.HasValue, () => {
                RuleFor(c => c.QuantidadeMaxima)                
                    .GreaterThan(0).WithName(propertyName).WithMessage("O campo {PropertyName} precisa ser maior que zero.");
            });            
        }
    }
}