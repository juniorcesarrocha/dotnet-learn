namespace EstoqueProduto.Domain.Validations
{
    public class AtualizacaoEstoqueValidation : EstoqueValidation
    {
        public AtualizacaoEstoqueValidation()
        {
            ValidarId();
            ValidarProduto();
            ValidarQuantidadeMaxima();
            ValidarQuantidadeMinima();
            ValidarLocalizacao();
        }
    }
}