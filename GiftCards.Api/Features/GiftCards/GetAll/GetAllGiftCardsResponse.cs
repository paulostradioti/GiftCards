namespace GiftCards.Api.Features.GiftCards.GetAll
{
    public record GetAllGiftCardsResponse(Guid Id, string Code, string Message, decimal Balance, bool IsRedeemed);
}
