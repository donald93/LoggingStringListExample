// See https://aka.ms/new-console-template for more information

using LoggingStringListExample;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

ServiceProvider serviceProvider = new ServiceCollection()
    .AddLogging((loggingBuilder) => loggingBuilder
        .SetMinimumLevel(LogLevel.Trace)
        .AddConsole()
    )
    .BuildServiceProvider();

var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger<SampleLogger>();

var sampleLogger = new SampleLogger(logger);

sampleLogger.LogLists(new [] { "List1" }, new [] { "List2" });
