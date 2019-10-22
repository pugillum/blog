using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventHubSpammer
{
    public interface ISpecificEventHubService
    {
        Task SendDataAsync(string data);
    }
}
