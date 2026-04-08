using GiftCards.Api.Domain;
using GiftCards.Api.Domain.Events;
using GiftCards.Api.Domain.Repositories;
using GiftCards.Api.Shared;
using MediatR;

namespace GiftCards.Api.Features.GiftCards.Redeem
{
    public class RedeemGiftCardHandler : IRequestHandler<RedeemGiftCardCommand, Result<Guid>>
    {
        private readonly IEventStore eventStore;

        public RedeemGiftCardHandler(IEventStore eventStore)
        {
            this.eventStore = eventStore;
        }

        public async Task<Result<Guid>> Handle(RedeemGiftCardCommand command, CancellationToken cancellationToken)
        {
            var stream = new EventStream<GiftCard>(eventStore, command.Id);
            var giftCard = stream.GetEntity();

            if (giftCard.IsRedeemed)
            {
                return Result<Guid>.Failure("Gift card já foi utilizado e não pode ser utilizado novamente");
            }

            stream.Append(new GiftCardRedeemed(giftCard.Balance));
            eventStore.SaveChanges();

            return Result<Guid>.Success(command.Id);
        }
    }
}
