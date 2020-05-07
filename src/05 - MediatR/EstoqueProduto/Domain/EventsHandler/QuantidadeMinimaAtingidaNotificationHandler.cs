using System.Threading;
using System.Threading.Tasks;
using EstoqueProduto.Domain.Event;
using EstoqueProduto.Infra.Http;
using MediatR;

namespace EstoqueProduto.Domain.EventsHandler
{
    public class QuantidadeMinimaAtingidaEventHandler : INotificationHandler<QuantidadeMinimaAtingidaEvent>
    {
        private readonly IEmail _email;
        public QuantidadeMinimaAtingidaEventHandler(IEmail email)
        {
            _email = email;
        }
        public async Task Handle(QuantidadeMinimaAtingidaEvent notification, CancellationToken cancellationToken)
        {
            await _email.SendEmailAsync(notification.Email, "Produto Quantidade Insuficiente Atingida", "Produto Quantidade Insuficiente Atingida");
        }
    }
}