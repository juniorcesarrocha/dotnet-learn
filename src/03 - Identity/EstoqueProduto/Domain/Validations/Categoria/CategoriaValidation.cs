using EstoqueProduto.Domain.Entities;
using FluentValidation;

namespace EstoqueProduto.Domain.Validations
{
    public class CategoriaValidation : AbstractValidator<Categoria>
    {
        public CategoriaValidation() { }

        public void ValidarId() 
        {
            var propertyName = "Identificador";
            RuleFor(c => c.Id)            
            .NotEmpty().WithName(propertyName).WithMessage("O campo {PropertyName} é obrigatório.");
        }
        public void ValidarNome() 
        {
            var propertyName = "Nome";
            RuleFor(c => c.Nome)
                .NotEmpty().WithName(propertyName).WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(2, 100).WithName(propertyName).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");
        }

        public void ValidarDescricao() 
        {
            var propertyName = "Descrição";
            RuleFor(c => c.Descricao)                
                .NotEmpty().WithName(propertyName).WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(2, 1000).WithName(propertyName).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");
        }
    }
}