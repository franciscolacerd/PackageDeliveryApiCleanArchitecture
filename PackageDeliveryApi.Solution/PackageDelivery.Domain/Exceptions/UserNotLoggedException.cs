namespace PackageDelivery.Domain.Exceptions
{
    public class UserNotLoggedException : Exception
    {
        public UserNotLoggedException() : base()
        {
        }

        public UserNotLoggedException(string? message) : base(message)
        {
        }

        public UserNotLoggedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}