using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace FunctionApp
{
    public class HttpPostFunction
    {
        private readonly ILogger _logger;
        public HttpPostFunction(ILoggerFactory lf) => _logger = lf.CreateLogger<HttpPostFunction>();

        [Function(nameof(HttpPostFunction))]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            var response = req.CreateResponse(System.Net.HttpStatusCode.OK);
            response.WriteString("Irrigation command received");
            return response;
        }
    }
}