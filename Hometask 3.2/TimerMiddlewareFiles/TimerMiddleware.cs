namespace Hometask_3._2.TimerMiddlewareFiles
{
    public class TimerMiddleware
    {
        private readonly RequestDelegate _next;
        TimeService _timeService;

        public TimerMiddleware(RequestDelegate next, TimeService timeService)
        {
            _next = next;
            _timeService = timeService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.Value.ToLower() == "/time")
            {
                    await context.Response.WriteAsync($"Current Time: {_timeService?.Time}");
                    await context.Response.WriteAsync($"\nCurrent Date: {DateTime.Today.ToString("dd/MM/yyyy")}");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
