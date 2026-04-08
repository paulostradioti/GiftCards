using GiftCards.Api.Shared;
using MediatR;

namespace GiftCards.Api.Features.GiftCards.UpdateMessage
{
    public record UpdateMessageCommand(Guid Id, string NewMessage) : IRequest<Result<Guid>>;
}
