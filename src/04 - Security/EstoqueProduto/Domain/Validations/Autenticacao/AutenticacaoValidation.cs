using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace EstoqueProduto.Domain.Validations
{
    public class AutenticacaoValidation : AbstractValidator<IdentityUser>
    {
        public AutenticacaoValidation() { }
        
        public void ValidarEmail()
        {
            var propertyName = "E-mail";
            RuleFor(c => c.Email)
                .NotEmpty().WithName(propertyName).WithMessage("O campo {PropertyName} é obrigatório.")
                .EmailAddress().WithName(propertyName).WithMessage("O campo {PropertyName} está inválido.")
                .Length(3, 100).WithName(propertyName).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");
        }        
    }
}