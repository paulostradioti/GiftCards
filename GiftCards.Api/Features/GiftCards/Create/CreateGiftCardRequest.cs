namespace GiftCards.Api.Features.GiftCards.Create
{
    public class CreateGiftCardRequest
    {
        public string Code { get; set; } = default!;
        public string Message { get; set; } = default!;
    }
}
