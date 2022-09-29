using Hometask_3._2.GroupMiddlewareFiles;
using System.Collections;
using System.Linq;

namespace Hometask_3._2.TimerMiddlewareFiles
{
    public class GroupMiddleware
    {
        private readonly RequestDelegate _next;

        public GroupMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var students = new List<Student>()
            {
                new Student{ Id = 1, Name = "George" },
                new Student{ Id = 2, Name = "Mia" },
                new Student{ Id = 3, Name = "Mike" },
                new Student{ Id = 4, Name = "Angelo" },
                new Student{ Id = 5, Name = "Victoria" },
                new Student{ Id = 6, Name = "Jim" },
                new Student{ Id = 7, Name = "Helga" }
            };

            var path = context.Request.Path.Value.ToLower();

            if (path == "/students")
            {
                await context.Response.WriteAsync($"Students List: \n");
                for (int i = 0; i < students.Count; i++)
                {
                    await context.Response.WriteAsync(String.Format("Id: {0, 2} | Name: {1, 10} | Age: {2, 3}\n", students[i].Id, students[i].Name, students[i].Age));
                }
            }
            else if (path == "/students-id")
            {
                await context.Response.WriteAsync($"Ids List: \n");
                for (int i = 0; i < students.Count; i++)
                {
                    await context.Response.WriteAsync(String.Format("| {0, 2} |\n", students[i].Id));
                }
            }
            else if (path == "/students-names")
            {
                await context.Response.WriteAsync($"Names List: \n");
                for (int i = 0; i < students.Count; i++)
                {
                    await context.Response.WriteAsync(String.Format("| {0, 10} |\n", students[i].Name));
                }
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
