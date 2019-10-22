using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionLimitFunctionApp
{
    public interface ISpecificEventHubService
    {
        Task SendDataAsync(string data);
    }
}
