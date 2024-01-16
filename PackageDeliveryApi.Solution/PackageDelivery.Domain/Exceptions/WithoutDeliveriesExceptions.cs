namespace PackageDelivery.Domain.Exceptions
{
    public class WithoutDeliveriesExceptions : Exception
    {
        public WithoutDeliveriesExceptions() : base()
        {
        }

        public WithoutDeliveriesExceptions(string? message) : base(message)
        {
        }

        public WithoutDeliveriesExceptions(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}