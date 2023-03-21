using Microsoft.Extensions.Logging;

namespace Common.Logger
{
    public class LogScope : IDisposable
    {
        private readonly ILogger _logger;
        private readonly string _methodName;
        private string _returnValue = "void";

        public LogScope(ILogger logger, string methodName, params object[] methodParams)
        {
            _logger = logger;
            _methodName = methodName;
            _logger.LogTrace("{MethodName} has started with parameters: {MethodParameters}", methodName, methodParams);
        }

        public T ReturnItem<T>(T item)
        {
            _returnValue = item?.ToString() ?? "Null";
            return item;
        }

        public void Dispose()
        {
            _logger.LogTrace("{MethodName} finished and returned: {ReturnValue}", _methodName, _returnValue);
        }
    }
}
