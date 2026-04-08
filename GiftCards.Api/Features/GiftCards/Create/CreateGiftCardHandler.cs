using GiftCards.Api.Domain;
using GiftCards.Api.Features.GiftCards.Events;
using GiftCards.Api.Shared;
using MediatR;

namespace GiftCards.Api.Features.GiftCards.Create
{
    public class CreateGiftCardHandler : IRequestHandler<CreateGiftCardCommand, Result<Guid>>
    {
        private readonly IEventStore eventStore;

        public CreateGiftCardHandler(IEventStore eventStore)
        {
            this.eventStore = eventStore;
        }
        public async Task<Result<Guid>> Handle(CreateGiftCardCommand command, CancellationToken cancellationToken)
        {
            var stream = new EventStream<GiftCard>(eventStore, command.Id);
            var giftCard = stream.GetEntity();

            stream.Append(new GiftCardCreated(command.Code, command.Message));
            eventStore.SaveChanges();

            return Result<Guid>.Success(command.Id);
        }
    }
}
