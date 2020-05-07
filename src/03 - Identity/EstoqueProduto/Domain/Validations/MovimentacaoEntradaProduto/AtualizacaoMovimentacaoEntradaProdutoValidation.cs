namespace EstoqueProduto.Domain.Validations
{
    public class AtualizacaoMovimentacaoEntradaProdutoValidation : MovimentacaoEntradaProdutoValidation
    {
        public AtualizacaoMovimentacaoEntradaProdutoValidation()
        {
            ValidarId();
            ValidarProduto();
            ValidarQuantidade();
            ValidarDataEntrada();
        }
    }
}