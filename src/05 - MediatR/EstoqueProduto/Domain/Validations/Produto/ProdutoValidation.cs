using System;
using EstoqueProduto.Domain.Entities;
using FluentValidation;

namespace EstoqueProduto.Domain.Validations
{
    public class ProdutoValidation : AbstractValidator<Produto>
    {
        public ProdutoValidation() {}
        
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

        public void ValidarUnidadeConsumo() 
        {
            var propertyName = "Unidade de Consumo";
            RuleFor(c => c.UnidadeConsumo)                
                .NotEmpty().WithName(propertyName).WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(2, 10).WithName(propertyName).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");
        }

        public void ValidarValorUnitario() 
        {
            var propertyName = "Valor Unitário";
            RuleFor(c => c.ValorUnitario)                
                .NotEmpty().WithName(propertyName).WithMessage("O campo {PropertyName} é obrigatório.")
                .GreaterThan(0).WithName(propertyName).WithMessage("O campo {PropertyName} precisa ser maior que zero.");
        }

        public void ValidarCodigoBarra() 
        {
            var propertyName = "Código de Barra";
            RuleFor(c => c.CodigoBarra)                
                .NotEmpty().WithName(propertyName).WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(2, 100).WithName(propertyName).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");
        }

        public void ValidarDataVencimento() 
        {
            var propertyName = "Data de Vencimento";
            When(c => c.DataVencimento.HasValue, () => {
                RuleFor(c => c.DataVencimento.Value)
                    .Must(BeAValidDate).WithName(propertyName).WithMessage("O campo {PropertyName} precisa ser uma data válida.");
            });            
        }

        public void ValidarAtivo() 
        {
            var propertyName = "Ativo";
            RuleFor(c => c.Ativo)                
                .NotEmpty().WithName(propertyName).WithMessage("O campo {PropertyName} é obrigatório.");
        }

        public void ValidarCategoria() 
        {
            var propertyName = "Categoria";
            RuleFor(c => c.CategoriaId)                
                .NotEmpty().WithName(propertyName).WithMessage("O campo {PropertyName} é obrigatório.")
                .GreaterThan(0).WithName(propertyName).WithMessage("O campo {PropertyName} precisa ser maior que zero.");
        }

        private bool BeAValidDate(DateTime value)
        {
            DateTime date;
            return DateTime.TryParse(value.ToString(), out date);
        }
    }
}