using System.Text;

namespace Helpers.Logging
{
    public class InfoLog : Log
    {
        StringBuilder Info = new StringBuilder(LogLevel.INFO.ToString());
        public override string LogMessage(string message)
        {
            return $"{Info}: {message}";
        }
    }
}
