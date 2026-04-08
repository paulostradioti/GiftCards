using GiftCards.Api.Shared;
using MediatR;

namespace GiftCards.Api.Features.GiftCards.AddBalance
{
    public record AddBalanceCommand(Guid Id, decimal Amount) : IRequest<Result<Guid>>;
}
