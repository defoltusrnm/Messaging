namespace ServerMessaging.Lib.Infrastructure.Interfaces;

public interface ISubscriberHandler
{
    SubscriberInfo SubscriberInfo { get; }

    Task HandleAsync(CancellationToken? cancellationToken = null);
}
