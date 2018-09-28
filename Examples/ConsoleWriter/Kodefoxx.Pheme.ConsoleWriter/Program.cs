using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Kodefoxx.Pheme.ConsoleWriter
{
    class Program
    {        
        /// <summary>
        /// Entry point for the application,
        /// Bootstraps it all.
        /// </summary>
        /// <param name="args">The command line arguments.</param>
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection
                .AddSingleton<Program>()
                .BuildServiceProvider()
            ;


            var program = serviceProvider.GetService<Program>();
            program.Run();
        }

        /// <summary>
        /// Configure services.
        /// </summary>        
        private static void ConfigureServices(ServiceCollection serviceCollection)
        {            
        }

        /// <summary>
        /// Holds a reference to the logger instance.
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Creates a new <see cref="Program"/> instance.
        /// </summary>
        /// <param name="logger"></param>
        public Program(ILogger<Program> logger)
            => _logger = logger
        ;        

        /// <summary>
        /// Runs the example.
        /// </summary>
        public void Run()
        {
            _logger.LogInformation($"Entered {nameof(Run)}");
            _logger.LogDebug($"Exited {nameof(Run)}");
        }
    }
}
