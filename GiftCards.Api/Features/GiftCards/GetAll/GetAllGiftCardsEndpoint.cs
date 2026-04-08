using MediatR;

namespace GiftCards.Api.Features.GiftCards.GetAll
{
    public static class GetAllGiftCardsEndpoint
    {
        public static RouteGroupBuilder MapGetAllGiftCards(this RouteGroupBuilder group)
        {
            group.MapGet("/", GetAllGiftCards)
                .WithName(nameof(GetAllGiftCards))
                .WithTags("Queries");

            return group;
        }

        public static async Task<IResult> GetAllGiftCards(ISender sender, CancellationToken ct)
        {
            var result = await sender.Send(new GetAllGiftCardsQuery(), ct);

            return result.IsSuccess
                ? Results.Ok(result.Value)
                : Results.BadRequest(new { error = result.Error });
        }
    }
}
