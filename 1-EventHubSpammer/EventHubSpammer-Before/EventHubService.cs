using Microsoft.Azure.EventHubs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventHubSpammer
{
    public class EventHubService : IEventHubService
    {
        private readonly ILogger _logger;

        public EventHubService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(typeof(EventHubService));
        }

        public async Task SendDataAsync(string data, string eventHubName, string eventHubConnectionString)
        {

            var eventData = new EventData(Encoding.UTF8.GetBytes(data));

            var connectionStringBuilder = new EventHubsConnectionStringBuilder(eventHubConnectionString)
            {
                EntityPath = eventHubName
            };
            
            var eventHubClient = EventHubClient.CreateFromConnectionString(connectionStringBuilder.ToString());
            await eventHubClient.SendAsync(eventData);

            _logger.LogInformation("Data sent to event hub");
        }
    }
}
