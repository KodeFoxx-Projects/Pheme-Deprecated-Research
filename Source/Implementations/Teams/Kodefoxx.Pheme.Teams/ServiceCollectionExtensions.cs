using System;
using Kodefoxx.Pheme.Shared.Messages;
using Kodefoxx.Pheme.Shared.Targets;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kodefoxx.Pheme.Teams
{
    /// <summary>
    /// Holds extensions for use on <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds and configures the <see cref="MessageToTeamsMessageTarget"/>.
        /// </summary>
        /// <typeparam name="TMessage">The type of message to handle.</typeparam>
        /// <param name="serviceCollection">The <see cref="IServiceCollection"/> to add and configure teams to.</param>
        /// <param name="messageConverterFactory">The <see cref="IMessageConverter{TMessage,TTargetMessage}"/> to be used.</param>
        /// <param name="configuration">The pre-built configuration.</param>
        public static IServiceCollection AddAndConfigureTeamsWebHookTarget<TMessage>(
            this IServiceCollection serviceCollection, Func<IMessageConverter<TMessage, TeamsMessage>> messageConverterFactory, IConfiguration configuration
        ) where TMessage : IMessage
            => serviceCollection
                .AddTransient(typeof(ITarget<TMessage>), typeof(MessageToTeamsMessageTarget))
                .AddTransient(typeof(IMessageConverter<TMessage, TeamsMessage>), messageConverterFactory().GetType())
                .AddSingleton<TeamsWebHookClient>()
                .Configure<TeamsWebHookClientOptions>(configuration.GetSection(nameof(TeamsWebHookClientOptions)))
                .AddOptions()
        ;
    }
}
