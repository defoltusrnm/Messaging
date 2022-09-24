﻿namespace ServerMessaging.Lib.Infrastructure.Interfaces;

public interface IMessagingBehaviour : IDisposable
{
    Task SendAsync<TData>(IMessage<TData> message, CancellationToken? cancellationToken = null)
        where TData : class;
}
