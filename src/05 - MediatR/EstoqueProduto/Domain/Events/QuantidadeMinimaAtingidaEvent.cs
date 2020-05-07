using MediatR;

namespace EstoqueProduto.Domain.Event
{
    public class QuantidadeMinimaAtingidaEvent : INotification
    {
        public string NomeProduto { get; set; }
        public string Email { get; set; }
    }
}