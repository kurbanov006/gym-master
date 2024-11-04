using System.Diagnostics;

public class RequestMidlleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestMidlleware> _logger;
    public RequestMidlleware(RequestDelegate next, ILogger<RequestMidlleware> logger)
    {
        _next = next;
        _logger = logger;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        var stopWatch = Stopwatch.StartNew();

        _logger.LogInformation("Request: {Method} {Path}", context.Request.Method, context.Request.Path);

        await _next(context);

        stopWatch.Stop();

        _logger.LogInformation("Finish Request. StatusCode = {StatusCode}, Time = {ElapsedMilliseconds} ms",
        context.Response.StatusCode, stopWatch.ElapsedMilliseconds);
    }
}