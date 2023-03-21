using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

namespace Common.Logger
{
    public static class LogScopeExtention
    {
        public static LogScope BeginLogScope(this ILogger logger,
            [CallerMemberName] string methodName = "",
            params object[] methodParams)
        {
            return new LogScope(logger, methodName, methodParams);
        }
    }
}
