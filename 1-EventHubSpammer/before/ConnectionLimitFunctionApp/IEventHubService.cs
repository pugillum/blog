using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionLimitFunctionApp
{
    public interface IEventHubService
    {
        Task SendDataAsync(string data, string eventHubName, string eventHubConnectionString);
    }
}
