using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionApp
{
    public class BlobTriggerFunction
    {
        private readonly ILogger _logger;
        public BlobTriggerFunction(ILoggerFactory lf) => _logger = lf.CreateLogger<BlobTriggerFunction>();

        [Function(nameof(BlobTriggerFunction))]
        public void Run([BlobTrigger("drone-images/{name}", Connection = "AzureWebJobsStorage")] Stream blob, string name)
        {
            _logger.LogInformation("Blob received: {name}", name);
        }
    }
}