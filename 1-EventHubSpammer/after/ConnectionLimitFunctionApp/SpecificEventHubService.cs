using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace ConnectionLimitFunctionApp
{
    public class SpecificEventHubService : EventHubService, ISpecificEventHubService
    {
        public SpecificEventHubService(ILoggerFactory loggerFactory) : base(loggerFactory)
        {
            var eventHubConnectionString = Environment.GetEnvironmentVariable("EventHubConnectionString");
            Initialize("test-connections", eventHubConnectionString);
        }
    }
}
