using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EventHubSpammer
{
    public class EventHubSpammerFunction
    {
        private IEventHubService _eventHubService;

        public EventHubSpammerFunction(IEventHubService eventHubService)
        {
            _eventHubService = eventHubService ?? throw new ArgumentNullException(nameof(eventHubService));
        }
        
        [FunctionName("EventHubSpammer")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                log.LogInformation("C# HTTP trigger function processed a request.");

                string eventHubConnectionString = Environment.GetEnvironmentVariable("EventHubConnectionString");

                for (int i = 0; i < 10000; i++)
                {
                    await _eventHubService.SendDataAsync($"Here be some data{i}", "test-connections", eventHubConnectionString);
                }

                return (ActionResult)new OkObjectResult("Consider your event hub spammed");
            }
            catch (Exception ex)
            {
                log.LogError(ex, $"An exception occurred {ex.Message}");
                return new BadRequestObjectResult("Function run failed");
            }
           
        }
    }
}
