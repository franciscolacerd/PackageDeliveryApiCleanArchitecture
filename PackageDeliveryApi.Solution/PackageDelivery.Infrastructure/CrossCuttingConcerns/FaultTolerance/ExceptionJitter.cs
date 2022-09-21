using Polly.Contrib.WaitAndRetry;

namespace PackageDelivery.Infrastructure.CrossCuttingConcerns.FaultTolerance
{
    public static class ExceptionJitter
    {
        public static IEnumerable<TimeSpan> Get5RetryCount()
        {
            return Backoff.DecorrelatedJitterBackoffV2(
              medianFirstRetryDelay: TimeSpan.FromSeconds(1),
              retryCount: 5,
              seed: 100);
        }

        public static IEnumerable<TimeSpan> Get1RetryCount()
        {
            return Backoff.DecorrelatedJitterBackoffV2(
              medianFirstRetryDelay: TimeSpan.FromSeconds(1),
              retryCount: 1,
              seed: 100);
        }
    }
}