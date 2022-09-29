namespace Hometask_3._2.ComputerInfoMiddlewareFiles
{
    public class ComputerInfoMiddleware
    {
        private readonly RequestDelegate _next;

        public ComputerInfoMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.Value.ToLower();
            if (path == "/info")
            {
                await context.Response.WriteAsync($"Username: {Environment.UserName}, OS Version: {Environment.OSVersion} (Proccess Id: {Environment.ProcessId})");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
