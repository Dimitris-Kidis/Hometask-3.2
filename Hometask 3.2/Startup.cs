using Hometask_3._2.ComputerInfoMiddlewareFiles;
using Hometask_3._2.TimerMiddlewareFiles;

namespace Hometask_3._2
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<TimeService>();
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<TimerMiddleware>();
            app.UseMiddleware<GroupMiddleware>();
            app.UseMiddleware<ComputerInfoMiddleware>();
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
