using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionApp
{
    public class QueueTriggerFunction
    {
        private readonly ILogger _logger;
        public QueueTriggerFunction(ILoggerFactory lf) => _logger = lf.CreateLogger<QueueTriggerFunction>();

        [Function(nameof(QueueTriggerFunction))]
        public void Run([QueueTrigger("irrigation-commands", Connection = "AzureWebJobsStorage")] string message)
        {
            _logger.LogInformation("Irrigation command: {msg}", message);
        }
    }
}