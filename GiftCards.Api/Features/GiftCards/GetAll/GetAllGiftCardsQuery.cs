using GiftCards.Api.Shared;
using MediatR;

namespace GiftCards.Api.Features.GiftCards.GetAll
{
    public record GetAllGiftCardsQuery : IRequest<Result<List<GetAllGiftCardsResponse>>>;
}
