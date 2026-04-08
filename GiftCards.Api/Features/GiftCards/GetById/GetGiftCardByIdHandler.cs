using GiftCards.Api.Domain;
using GiftCards.Api.Shared;
using MediatR;

namespace GiftCards.Api.Features.GiftCards.GetById
{
    public class GetGiftCardByIdHandler : IRequestHandler<GetGiftCardByIdQuery, Result<GetGiftCardByIdResponse>>
    {
        private readonly IEventStore eventStore;

        public GetGiftCardByIdHandler(IEventStore eventStore)
        {
            this.eventStore = eventStore;
        }

        public Task<Result<GetGiftCardByIdResponse>> Handle(GetGiftCardByIdQuery request, CancellationToken cancellationToken)
        {
            var stream = new EventStream<GiftCard>(eventStore, request.Id);
            var card = stream.GetEntity();

            var response = new GetGiftCardByIdResponse(card.Code, card.Message, card.Balance, card.IsRedeemed);

            return Task.FromResult(Result<GetGiftCardByIdResponse>.Success(response));
        }
    }
}
