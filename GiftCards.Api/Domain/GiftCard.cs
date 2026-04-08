using GiftCards.Api.Domain.Events;

namespace GiftCards.Api.Domain
{
    public class GiftCard : AggregateRoot
    {
        public string Code { get; private set; }
        public string Message { get; private set; }
        public decimal Balance { get; private set; }
        public bool IsRedeemed { get; private set; }

        public void Apply(GiftCardCreated @event)
        {
            Code = @event.Code;
            Message = @event.Message;
        }

        public void Apply(BalanceAdded @event)
        {
            Balance += @event.Amount;
        }

        public void Apply(MessageUpdated @event)
        {
            Message = @event.NewMessage;
        }

        public void Apply(GiftCardRedeemed @event)
        {
            Balance -= @event.RedeemedAmount;
            IsRedeemed = true;
        }
    }
}
