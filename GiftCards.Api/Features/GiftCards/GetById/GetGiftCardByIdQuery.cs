using GiftCards.Api.Shared;
using MediatR;

namespace GiftCards.Api.Features.GiftCards.GetById
{
    public record GetGiftCardByIdQuery(Guid Id) : IRequest<Result<GetGiftCardByIdResponse>>;
}
