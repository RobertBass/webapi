public class Time
{
    readonly RequestDelegate next;

    public Time(RequestDelegate nextRequest)
    {
        next = nextRequest;
    }

    public async Task Invoke(Microsoft.AspNetCore.Http.HttpContext context)
    {
        
        await next(context);

        if(context.Request.Query.Any(p => p.Key == "time"))
        {
            await context.Response.WriteAsync(DateTime.Now.ToString());
        }
    }
}

public static class TimeExtensions
    {
        public static IApplicationBuilder UseTime(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Time>();
        }
    }