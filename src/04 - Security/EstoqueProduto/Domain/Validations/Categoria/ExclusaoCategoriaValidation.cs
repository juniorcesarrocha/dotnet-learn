using EstoqueProduto.Domain.Entities;
using FluentValidation;

namespace EstoqueProduto.Domain.Validations
{
    public class ExclusaoCategoriaValidation : CategoriaValidation
    {
        public ExclusaoCategoriaValidation() 
        {            
            ValidarId();
        }        
    }
}