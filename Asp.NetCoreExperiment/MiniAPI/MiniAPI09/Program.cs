
using NLog;
using NLog.Web;

//������־
var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");
try
{
    var builder = WebApplication.CreateBuilder(args);
    //������־
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Host.UseNLog();

    var app = builder.Build();
    //ʹ����־
    app.MapGet("/logtest", () =>
    {
        app.Logger.LogTrace("LogTrace");
        app.Logger.LogDebug("LogDebug");
        app.Logger.LogWarning("LogWarning");
        app.Logger.LogInformation("LogInformation");
        app.Logger.LogError("LogError");
        app.Logger.LogCritical(new Exception("eLogCritical"), "LogCritical");
        return "logtest";
    });

    app.MapGet("/myvalue", MyService.GetMyValue);

    app.Run();
}
catch (Exception exception)
{
    //�쳣ʱ������־
    logger.Fatal(exception, "Stopped program because of exception");
}
finally
{
    NLog.LogManager.Shutdown();
}

class MyService
{
    public static string GetMyValue(ILogger<MyService> logger)
    {
        logger.LogInformation("TestService.GetMyValue");
        return "MyValue";
    }
}