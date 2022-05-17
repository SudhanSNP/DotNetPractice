using System.Text;

namespace Helpers.Logging
{
    public class ErrorLog : Log
    {
        Logs log = ErrorMessage;
        StringBuilder Error = new StringBuilder(LogLevel.ERROR.ToString());

        public override string LogMessage(string message)
        {
            return $"{Error}: {log(message)}";
        }

        public static string ErrorMessage(string message)
        {
            StringBuilder sb = new StringBuilder(message);
            return sb.ToString();
        }
    }
}
