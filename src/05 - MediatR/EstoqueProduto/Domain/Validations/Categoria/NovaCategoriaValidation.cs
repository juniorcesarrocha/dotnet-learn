using EstoqueProduto.Domain.Entities;
using FluentValidation;

namespace EstoqueProduto.Domain.Validations
{
    public class NovaCategoriaValidation : CategoriaValidation
    {
        public NovaCategoriaValidation() 
        {            
            ValidarNome();
            ValidarDescricao();
        }        
    }
}