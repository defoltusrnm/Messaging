using System.Diagnostics.CodeAnalysis;

namespace ServerMessaging.Lib.Infrastructure.Interfaces;

public struct SubscriberInfo
{
    public string Address { get; init; }

    public int Port { get; init; }

    public override string ToString()
        => $"{Address}:{Port}";

    public static bool operator ==(SubscriberInfo a, SubscriberInfo b) => a.GetHashCode() == b.GetHashCode();

    public static bool operator !=(SubscriberInfo a, SubscriberInfo b) => a.GetHashCode() != b.GetHashCode();

    public override int GetHashCode()
    {
        HashCode hashCode = new();
        hashCode.Add(Address);
        hashCode.Add(Port);

        return hashCode.ToHashCode();
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        if (obj == null)
        {
            return false;
        }

        return GetHashCode() == obj.GetHashCode();
    }
}
