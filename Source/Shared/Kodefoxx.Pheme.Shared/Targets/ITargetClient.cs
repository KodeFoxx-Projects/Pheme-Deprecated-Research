using System.Threading.Tasks;
using Kodefoxx.Pheme.Shared.Messages;

namespace Kodefoxx.Pheme.Shared.Targets
{
    /// <summary>
    /// Defines a target client, able to process messages.
    /// </summary>
    public interface ITargetClient
    {
        Task ProcessMessage(IMessage message);
    }
}
