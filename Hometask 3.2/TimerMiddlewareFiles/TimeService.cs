namespace Hometask_3._2.TimerMiddlewareFiles
{
    public class TimeService
    {
        public TimeService()
        {
            Time = DateTime.Now.ToString("hh:mm:ss");
        }

        public string Time { get; }
    }
}
