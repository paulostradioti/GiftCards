using GiftCards.Api.Features.GiftCards.GetById;
using MediatR;

namespace GiftCards.Api.Features.GiftCards.Create
{
    public static class CreateGiftCardEndpoint
    {
        public static RouteGroupBuilder MapCreateGiftCard(this RouteGroupBuilder group)
        {
            group.MapPost("/", async (CreateGiftCardRequest request, ISender sender, CancellationToken ct) =>
            {
                var command = new CreateGiftCardCommand(Guid.NewGuid(), request.Code, request.Message);
                var result = await sender.Send(command, ct);

                return result.IsSuccess
                    ? Results.CreatedAtRoute(nameof(GetGiftCardByIdEndpoint.GetGiftCardById), new { id = result.Value })
                    : Results.BadRequest(new { error = result.Error });
            })
                .WithName("CreateGiftCard")
                .WithSummary("Creates a new Gift Card")
                .WithTags("Commands");

            return group;
        }
    }
}
