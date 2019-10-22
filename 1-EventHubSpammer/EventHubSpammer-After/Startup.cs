using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

[assembly: FunctionsStartup(typeof(EventHubSpammer.Startup))]
namespace EventHubSpammer
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.Services.AddSingleton<ISpecificEventHubService, SpecificEventHubService>();
        }
    }
}
