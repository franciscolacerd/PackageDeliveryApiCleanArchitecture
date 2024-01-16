namespace PackageDelivery.Domain.Constants
{
    public static class ExceptionMessages
    {
        public static readonly string InvalidUserException = "Invalid user is logged.";

        public static readonly string UserNotLoggedException = "User not logged.";

        public static readonly string NullConfigurationException = "Configuration is null.";

        public static string WithoutDeliveriesExceptions = $"UserId {0} without deliveries.";
    }
}