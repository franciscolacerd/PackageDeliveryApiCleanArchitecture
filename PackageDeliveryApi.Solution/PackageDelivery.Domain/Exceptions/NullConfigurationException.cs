namespace PackageDelivery.Domain.Exceptions
{
    public class NullConfigurationException : Exception
    {
        public NullConfigurationException() : base()
        {
        }

        public NullConfigurationException(string? message) : base(message)
        {
        }

        public NullConfigurationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}