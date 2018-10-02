using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Kodefoxx.Pheme.ConsoleWriter.Infrastructure.ServiceCollection
{
    /// <summary>
    /// Holds extension methods to be used for configuring the <see cref="IServiceCollection"/> of this application.
    /// </summary>
    public static partial class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds and configures logging.
        /// </summary>
        /// <param name="serviceCollection">The <see cref="IServiceCollection"/> to add and configure logging to.</param>
        public static IServiceCollection AddAndConfigureLogging(this IServiceCollection serviceCollection)
        {
            // Configuration
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console()
                .CreateLogger()
            ;

            return serviceCollection
                .AddLogging(configure => configure
                    .AddSerilog()
                )
            ;
        }
    }
}
