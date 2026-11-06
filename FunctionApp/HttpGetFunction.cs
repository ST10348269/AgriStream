using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace FunctionApp
{
    public class HttpGetFunction
    {
        private readonly ILogger _logger;
        public HttpGetFunction(ILoggerFactory lf) => _logger = lf.CreateLogger<HttpGetFunction>();

        [Function(nameof(HttpGetFunction))]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
        {
            var response = req.CreateResponse(System.Net.HttpStatusCode.OK);
            response.WriteString("Telemetry data would be here");
            return response;
        }
    }
}