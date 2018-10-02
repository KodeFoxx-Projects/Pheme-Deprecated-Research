namespace Kodefoxx.Pheme.Shared.Messages
{
    /// <summary>
    /// Converts a given <typeparamref name="TMessage"/> to the <see cref="TTargetMessage"/> format.
    /// </summary>
    /// <typeparam name="TMessage">The standard message sent.</typeparam>
    /// <typeparam name="TTargetMessage">The type used in the concrete implementation.</typeparam>
    public interface IMessageConverter<TMessage, TTargetMessage>
        where TMessage : IMessage
        where TTargetMessage : class
    {
        /// <summary>
        /// Converts a given <paramref name="message"/> to the <see cref="TTargetMessage"/> format.
        /// </summary>
        /// <param name="message">The <typeparamref name="TMessage"/> to convert.</param>
        /// <returns>A <see cref="TTargetMessage"/>.</returns>
        TTargetMessage ConvertToTargetMessage(TMessage message);
    }
}
