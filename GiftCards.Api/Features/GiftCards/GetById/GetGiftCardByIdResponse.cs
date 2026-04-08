namespace GiftCards.Api.Features.GiftCards.GetById
{
    public sealed record GetGiftCardByIdResponse(string Code, string Message, decimal Balance, bool IsRedeemed);
}
