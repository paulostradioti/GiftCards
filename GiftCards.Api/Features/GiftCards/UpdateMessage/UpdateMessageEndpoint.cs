using MediatR;

namespace GiftCards.Api.Features.GiftCards.UpdateMessage
{
    public static class UpdateMessageEndpoint
    {
        public static RouteGroupBuilder MapUpdateMessage(this RouteGroupBuilder group)
        {
            group.MapPost("/{id:guid}/message", async (Guid id, UpdateMessageRequest request, ISender sender, CancellationToken ct) =>
            {
                var command = new UpdateMessageCommand(id, request.NewMessage);
                var result = await sender.Send(command, ct);

                return result.IsSuccess
                    ? Results.Ok(new { id = result.Value })
                    : Results.BadRequest(new { error = result.Error });
            })
                .WithName("UpdateMessage")
                .WithSummary("Updates the message of a Gift Card")
                .WithTags("Commands");

            return group;
        }
    }
}
