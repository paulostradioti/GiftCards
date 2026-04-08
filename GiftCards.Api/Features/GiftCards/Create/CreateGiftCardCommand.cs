
using GiftCards.Api.Shared;
using MediatR;

namespace GiftCards.Api.Features.GiftCards.Create
{
    public record CreateGiftCardCommand(Guid Id, string Code, string Message) : IRequest<Result<Guid>>;
}
