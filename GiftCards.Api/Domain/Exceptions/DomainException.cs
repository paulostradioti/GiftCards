namespace GiftCards.Api.Domain.Exceptions
{
    public sealed class DomainException : Exception
    {
        public DomainException(string message) : base(message) { }
    }

    public sealed class ConcurrencyException : Exception
    {
        public ConcurrencyException(string message) : base(message) { }
    }

    public sealed class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }
}
