namespace EstoqueProduto.Domain.Validations
{
    public class NovoEstoqueValidation : EstoqueValidation
    {
        public NovoEstoqueValidation()
        {
            ValidarProduto();
            ValidarQuantidadeMaxima();
            ValidarQuantidadeMinima();
            ValidarLocalizacao();
        }
    }
}