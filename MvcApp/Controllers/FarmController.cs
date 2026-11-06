using Azure.Storage.Blobs;
using Azure.Storage.Queues;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace MvcApp.Controllers
{
    public class FarmController : Controller
    {
        private readonly IConfiguration _config;
        public FarmController(IConfiguration config) => _config = config;

        [HttpGet]
        public IActionResult Upload() => View();

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0) return View();

            var conn = _config["Storage:ConnectionString"];
            var containerName = _config["Storage:BlobContainer"];

            var blobService = new BlobServiceClient(conn);
            var container = blobService.GetBlobContainerClient(containerName);
            await container.CreateIfNotExistsAsync();

            var blob = container.GetBlobClient(file.FileName);
            using var stream = file.OpenReadStream();
            await blob.UploadAsync(stream, overwrite: true);

            ViewBag.Message = "Image uploaded successfully!";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TriggerIrrigation(string deviceId)
        {
            var conn = _config["Storage:ConnectionString"];
            var queueName = _config["Storage:QueueName"];

            var queueService = new QueueServiceClient(conn);
            var queue = queueService.GetQueueClient(queueName);
            await queue.CreateIfNotExistsAsync();

            var message = JsonSerializer.Serialize(new { DeviceId = deviceId, Command = "StartIrrigation", Time = DateTime.UtcNow });
            await queue.SendMessageAsync(message);

            return RedirectToAction("Index", "Home");
        }
    }
}