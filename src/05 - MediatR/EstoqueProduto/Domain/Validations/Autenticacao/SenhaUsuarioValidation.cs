using FluentValidation;

namespace EstoqueProduto.Domain.Validations
{
    public class SenhaUsuarioValidation : AbstractValidator<string>
    {
        public SenhaUsuarioValidation() 
        { 
            ValidarSenha();
        }

        public void ValidarSenha() {
            var propertyName = "Senha";
            RuleFor(c => c)
                .NotEmpty().WithName(propertyName).WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(8, 20).WithName(propertyName).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");
        }
    }
}