using MediatR;

namespace EstoqueProduto.Domain.Command
{
    public class QuantidadeMinimaAtingidaCommand : IRequest<bool>
    {
        public string NomeProduto { get; set; }
    }
}