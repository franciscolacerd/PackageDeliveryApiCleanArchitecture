namespace PackageDelivery.Domain.Exceptions
{
    public class NullCreateDeliverytRequestException : Exception
    {
        public NullCreateDeliverytRequestException() : base()
        {
        }

        public NullCreateDeliverytRequestException(string? message) : base(message)
        {
        }

        public NullCreateDeliverytRequestException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}