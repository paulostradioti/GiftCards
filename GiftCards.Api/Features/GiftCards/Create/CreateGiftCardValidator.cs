using FluentValidation;

namespace GiftCards.Api.Features.GiftCards.Create
{
    public class CreateGiftCardValidator : AbstractValidator<CreateGiftCardCommand>
    {
        public CreateGiftCardValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("The Gift Card ID must be provided");

            RuleFor(x => x.Code)
                .Length(5)
                .WithMessage("The Gift Card Code must have 5 digits");
        }
    }
}
