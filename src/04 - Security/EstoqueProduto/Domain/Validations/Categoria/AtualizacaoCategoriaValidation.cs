using EstoqueProduto.Domain.Entities;
using FluentValidation;

namespace EstoqueProduto.Domain.Validations
{
    public class AtualizacaoCategoriaValidation : CategoriaValidation
    {
        public AtualizacaoCategoriaValidation() 
        {            
            ValidarId();
            ValidarNome();
            ValidarDescricao();
        }        
    }
}