using MediatR;

namespace GiftCards.Api.Features.GiftCards.GetById
{
    public static class GetGiftCardByIdEndpoint
    {
        public static RouteGroupBuilder MapGetGiftCardById(this RouteGroupBuilder group)
        {
            group.MapGet("/{id:guid}", GetGiftCardById)
                .WithName(nameof(GetGiftCardById))
                .WithTags("Queries");

            return group;
        }

        public static async Task<IResult> GetGiftCardById(Guid id, ISender sender, HttpContext httpContext, CancellationToken ct)
        {
            var result = await sender.Send(new GetGiftCardByIdQuery(id), ct);

            return result.IsSuccess
                ? Results.Ok(result.Value)
                : Results.Problem(
                    title: "Gift card não encontrado",
                    detail: result.Error,
                    statusCode: StatusCodes.Status404NotFound,
                    extensions: new Dictionary<string, object?>
                    {
                        ["traceId"] = httpContext.TraceIdentifier
                    });
        }
    }
}