namespace Hometask_3._2.GroupMiddlewareFiles
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get => new Random().Next(18, 26); }
    }
}
