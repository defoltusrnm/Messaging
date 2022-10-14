using Messaging.Domain.Messages.Interfaces;

namespace Messaging.Domain.Packages.Interface;

public interface IPackageProcessor
{
    IEnumerable<IMessageFactory>? MessageFactories { get; }
    IPackage Construct(string content);
    string Deconsturct(IPackage package);
}
