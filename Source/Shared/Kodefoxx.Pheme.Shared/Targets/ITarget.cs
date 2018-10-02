using System.Threading.Tasks;
using Kodefoxx.Pheme.Shared.Messages;

namespace Kodefoxx.Pheme.Shared.Targets
{
    /// <summary>
    /// Defines a target client, able to process messages.
    /// </summary>
    /// <typeparam name="TMessage">The type of <see cref="IMessage"/> used.</typeparam>
    public interface ITarget<in TMessage>
        where TMessage : IMessage
    {
        /// <summary>
        /// Publishes the given message to the target.
        /// </summary>
        /// <param name="message">The message to be published.</param>        
        Task PublishMessage(TMessage message);
    }
}
