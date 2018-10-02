using System;
using Kodefoxx.Pheme.Shared.Messages;
using Kodefoxx.Pheme.Shared.Targets;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kodefoxx.Pheme.Slack
{
    /// <summary>
    /// Holds extensions for use on <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds and configures the <see cref="MessageToSlackMessageTarget"/>.
        /// </summary>
        /// <typeparam name="TMessage">The type of message to handle.</typeparam>
        /// <param name="serviceCollection">The <see cref="IServiceCollection"/> to add and configure slack to.</param>
        /// <param name="messageConverterFactory">The <see cref="IMessageConverter{TMessage,TTargetMessage}"/> to be used.</param>
        /// <param name="configuration">The pre-built configuration.</param>
        public static IServiceCollection AddAndConfigureSlackTarget<TMessage>(
            this IServiceCollection serviceCollection, Func<IMessageConverter<TMessage, SlackMessage>> messageConverterFactory, IConfiguration configuration
        ) where TMessage : IMessage
            => serviceCollection
                .AddTransient(typeof(ITarget<TMessage>), typeof(MessageToSlackMessageTarget))
                .AddTransient(typeof(IMessageConverter<TMessage, SlackMessage>), messageConverterFactory().GetType())
                .AddSingleton<SlackWebHookClient>()
                .Configure<SlackWebHookClientOptions>(configuration.GetSection(nameof(SlackWebHookClientOptions)))
                .AddOptions()                
        ;
    }
}
