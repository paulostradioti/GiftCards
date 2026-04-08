using MediatR;

namespace GiftCards.Api.Features.GiftCards.Redeem
{
    public static class RedeemGiftCardEndpoint
    {
        public static RouteGroupBuilder MapRedeemGiftCard(this RouteGroupBuilder group)
        {
            group.MapPost("/{id:guid}/redeem", async (Guid id, ISender sender, CancellationToken ct) =>
            {
                var command = new RedeemGiftCardCommand(id);
                var result = await sender.Send(command, ct);

                return result.IsSuccess
                    ? Results.Ok(new { id = result.Value })
                    : Results.BadRequest(new { error = result.Error });
            })
                .WithName("RedeemGiftCard")
                .WithSummary("Redeems a Gift Card, marking it as used")
                .WithTags("Commands");

            return group;
        }
    }
}
