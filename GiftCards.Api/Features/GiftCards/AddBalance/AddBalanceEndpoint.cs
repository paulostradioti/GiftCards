using MediatR;

namespace GiftCards.Api.Features.GiftCards.AddBalance
{
    public static class AddBalanceEndpoint
    {
        public static RouteGroupBuilder MapAddBalance(this RouteGroupBuilder group)
        {
            group.MapPost("/{id:guid}/balance", async (Guid id, AddBalanceRequest request, ISender sender, CancellationToken ct) =>
            {
                var command = new AddBalanceCommand(id, request.Amount);
                var result = await sender.Send(command, ct);

                return result.IsSuccess
                    ? Results.Ok(new { id = result.Value })
                    : Results.BadRequest(new { error = result.Error });
            })
                .WithName("AddBalance")
                .WithSummary("Adds balance to a Gift Card")
                .WithTags("Commands");

            return group;
        }
    }
}
