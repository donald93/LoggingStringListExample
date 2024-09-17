using Microsoft.Extensions.Logging;

namespace LoggingStringListExample;

public class SampleLogger
{
    private readonly ILogger<SampleLogger> logger;
    
    private readonly Action<ILogger, IEnumerable<string>, IEnumerable<string>, Exception?> stringListLogAction;

    public SampleLogger(ILogger<SampleLogger> logger)
    {
        this.logger = logger;
        
        this.stringListLogAction = LoggerMessage.Define<IEnumerable<string>, IEnumerable<string>>(
            LogLevel.Error,
            0,
            "[List 1: {CorrelationIds}, List 2: {MessageKeys}] both of these lists should be printed out!");
    }
    
    public void LogLists(IEnumerable<string> list1, IEnumerable<string> list2) => stringListLogAction(this.logger, list1, list2, null);
}