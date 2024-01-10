using MightyXOR.Common.Logging;
using NUnit.Framework;

namespace MightyXOR.UnitTests.Common.Logging;

public class SetupLogger
{
    private const bool LoggingEnabled = false;

    [Test, Order(1)]
    public void Setup()
    {
        if (LoggingEnabled)
        {
            Logger.Initialize("log4net_tests.config");
            Logger.LogLevel = LogLevel.Diagnostic;
        }

        Assert.Pass();
    }
}