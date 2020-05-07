namespace EstoqueProduto.Domain.Validations
{
    public class AtualizacaoMovimentacaoSaidaProdutoValidation : MovimentacaoSaidaProdutoValidation
    {
        public AtualizacaoMovimentacaoSaidaProdutoValidation()
        {
            ValidarId();
            ValidarProduto();
            ValidarQuantidade();
            ValidarDataSaida();
        }
    }
}