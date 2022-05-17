using System.Text;

namespace Helpers.Logging
{
    public class ErrorLog : Log
    {
        StringBuilder Error = new StringBuilder(LogLevel.ERROR.ToString());
        public override string LogMessage(string message)
        {
            return $"{Error}: {message}";
        }
    }
}
