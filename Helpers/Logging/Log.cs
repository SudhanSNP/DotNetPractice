namespace Helpers.Logging
{
    public abstract class Log
    {
        public static void PrintLog(string message)
        {
            Console.WriteLine(message);
        }
        public abstract string LogMessage(string message);
    }
}
