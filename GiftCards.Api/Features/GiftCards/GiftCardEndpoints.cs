using GiftCards.Api.Features.GiftCards.AddBalance;
using GiftCards.Api.Features.GiftCards.Create;
using GiftCards.Api.Features.GiftCards.GetAll;
using GiftCards.Api.Features.GiftCards.GetById;
using GiftCards.Api.Features.GiftCards.Redeem;
using GiftCards.Api.Features.GiftCards.UpdateMessage;

namespace GiftCards.Api.Features.GiftCards
{
    public static class GiftCardEndpoints
    {
        public static RouteGroupBuilder MapGiftCardEndpoints(this RouteGroupBuilder group)
        {
            group.MapCreateGiftCard();

            group.MapGetGiftCardById();

            group.MapGetAllGiftCards();

            group.MapAddBalance();

            group.MapUpdateMessage();

            group.MapRedeemGiftCard();

            return group;
        }
    }
}
