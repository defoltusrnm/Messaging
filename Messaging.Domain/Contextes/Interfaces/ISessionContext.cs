using Messaging.Domain.Packages.Interface;
using System.Net;
using System.Text;

namespace Messaging.Domain.Contextes.Interfaces;

public interface ISessionContext
{
    string RawText { get; }

    IPackage PreparedPackage { get; }
    
    EndPoint ClientEndPoint { get; }

    Encoding Encoding { get; }
    
    Task WriteAsync(string rawText, CancellationToken cancellationToken = default);
}
