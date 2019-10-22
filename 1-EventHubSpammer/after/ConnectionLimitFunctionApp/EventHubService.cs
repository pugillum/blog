using Microsoft.Azure.EventHubs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionLimitFunctionApp
{
    public abstract class EventHubService
    {
        private readonly ILogger _logger;
        private EventHubClient _eventHubClient;

        public EventHubService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(typeof(EventHubService));
        }

        protected void Initialize(string eventHubName, string connectionString)
        {
            var connectionStringBuilder = new EventHubsConnectionStringBuilder(connectionString)
            {
                EntityPath = eventHubName
            };

            _eventHubClient = EventHubClient.CreateFromConnectionString(connectionStringBuilder.ToString());
        }

        public async Task SendDataAsync(string data)
        {

            var eventData = new EventData(Encoding.UTF8.GetBytes(data));
            
            await _eventHubClient.SendAsync(eventData);

            _logger.LogInformation("Data sent to event hub");
        }
    }
}
