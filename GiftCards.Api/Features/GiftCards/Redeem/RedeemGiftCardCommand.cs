using GiftCards.Api.Shared;
using MediatR;

namespace GiftCards.Api.Features.GiftCards.Redeem
{
    public record RedeemGiftCardCommand(Guid Id) : IRequest<Result<Guid>>;
}
