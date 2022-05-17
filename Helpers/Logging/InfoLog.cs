using System.Text;

namespace Helpers.Logging
{
    public class InfoLog : Log
    {
        Logs log = InfoMessage;
        StringBuilder Info = new StringBuilder(LogLevel.INFO.ToString());

        public override string LogMessage(string message)
        {
            return $"{Info}: {log(message)}";
        }

        public static string InfoMessage(string message)
        {
            StringBuilder sb = new StringBuilder(message);
            return sb.ToString();
        }

        
    }
}
