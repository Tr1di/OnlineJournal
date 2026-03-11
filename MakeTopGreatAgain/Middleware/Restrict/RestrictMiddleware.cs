using System.Net;

namespace MakeTopGreatAgain.Middleware.Restrict;

public class RestrictMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        var endpoint = context.GetEndpoint();
        var restrict = endpoint?.Metadata.GetMetadata<RestrictAttribute>();

        if (restrict == null)
        {
            await next(context);
            return;
        }

        var allowed = restrict.Allowed.Contains(context.Connection.RemoteIpAddress);

        if (!allowed)
        {
            context.Response.Clear();
            context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            await context.Response.WriteAsync("Unauthorized");
            return;
        }
        
        await next(context);
    }
}