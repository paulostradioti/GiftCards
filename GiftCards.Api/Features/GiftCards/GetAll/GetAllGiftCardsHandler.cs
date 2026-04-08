using GiftCards.Api.Domain;
using GiftCards.Api.Shared;
using MediatR;

namespace GiftCards.Api.Features.GiftCards.GetAll
{
    public class GetAllGiftCardsHandler : IRequestHandler<GetAllGiftCardsQuery, Result<List<GetAllGiftCardsResponse>>>
    {
        private readonly IEventStore eventStore;

        public GetAllGiftCardsHandler(IEventStore eventStore)
        {
            this.eventStore = eventStore;
        }

        public Task<Result<List<GetAllGiftCardsResponse>>> Handle(GetAllGiftCardsQuery request, CancellationToken cancellationToken)
        {
            var aggregateIds = eventStore.GetAllAggregateIds();
            var giftCards = new List<GetAllGiftCardsResponse>();

            foreach (var aggregateId in aggregateIds)
            {
                var stream = new EventStream<GiftCard>(eventStore, aggregateId);
                var card = stream.GetEntity();

                giftCards.Add(new GetAllGiftCardsResponse(aggregateId, card.Code, card.Message, card.Balance, card.IsRedeemed));
            }

            return Task.FromResult(Result<List<GetAllGiftCardsResponse>>.Success(giftCards));
        }
    }
}
