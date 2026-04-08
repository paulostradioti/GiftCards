using GiftCards.Api.Domain;
using GiftCards.Api.Features.GiftCards.Events;
using GiftCards.Api.Shared;
using MediatR;

namespace GiftCards.Api.Features.GiftCards.AddBalance
{
    public class AddBalanceHandler : IRequestHandler<AddBalanceCommand, Result<Guid>>
    {
        private readonly IEventStore eventStore;

        public AddBalanceHandler(IEventStore eventStore)
        {
            this.eventStore = eventStore;
        }

        public async Task<Result<Guid>> Handle(AddBalanceCommand command, CancellationToken cancellationToken)
        {
            var stream = new EventStream<GiftCard>(eventStore, command.Id);
            var giftCard = stream.GetEntity();

            if (giftCard.IsRedeemed)
            {
                return Result<Guid>.Failure("Não é possível adicionar saldo a um gift card já utilizado");
            }

            stream.Append(new BalanceAdded(command.Amount));
            eventStore.SaveChanges();

            return Result<Guid>.Success(command.Id);
        }
    }
}
