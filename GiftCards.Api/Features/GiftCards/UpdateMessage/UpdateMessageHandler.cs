using GiftCards.Api.Domain;
using GiftCards.Api.Features.GiftCards.Events;
using GiftCards.Api.Shared;
using MediatR;

namespace GiftCards.Api.Features.GiftCards.UpdateMessage
{
    public class UpdateMessageHandler : IRequestHandler<UpdateMessageCommand, Result<Guid>>
    {
        private readonly IEventStore eventStore;

        public UpdateMessageHandler(IEventStore eventStore)
        {
            this.eventStore = eventStore;
        }

        public async Task<Result<Guid>> Handle(UpdateMessageCommand command, CancellationToken cancellationToken)
        {
            var stream = new EventStream<GiftCard>(eventStore, command.Id);
            var giftCard = stream.GetEntity();

            stream.Append(new MessageUpdated(command.NewMessage));
            eventStore.SaveChanges();

            return Result<Guid>.Success(command.Id);
        }
    }
}
