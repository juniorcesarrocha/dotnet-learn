using System.Threading;
using System.Threading.Tasks;
using EstoqueProduto.Domain.Command;
using EstoqueProduto.Domain.Event;
using MediatR;

namespace EstoqueProduto.Domain.CommandHandler
{
    public class QuantidadeMinimaAtingidaCommandHandler : IRequestHandler<QuantidadeMinimaAtingidaCommand, bool>
    {
        private readonly IMediator _mediator;

        public QuantidadeMinimaAtingidaCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> Handle(QuantidadeMinimaAtingidaCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Publish(new QuantidadeMinimaAtingidaEvent
            {
                NomeProduto = request.NomeProduto,
                Email = "juniorcesar.rocha@gmail.com"
            }, cancellationToken);

            return await Task.FromResult(true);
        }
    }
}