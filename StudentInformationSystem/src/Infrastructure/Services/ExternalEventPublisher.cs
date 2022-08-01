using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StudentInformationSystem.Application.Common.Interfaces;
using StudentInformationSystem.Domain.Common;

namespace StudentInformationSystem.Infrastructure.Services;

public class ExternalEventPublisher : IExternalEventPublisher
{
    private readonly ILogger<ExternalEventPublisher> _logger;
    public ExternalEventPublisher(ILogger<ExternalEventPublisher> logger)
    {
        _logger = logger;
    }

    public void Publish(IExternalEvent externalEvent)
    {
        _logger.LogInformation($"External event published for: {externalEvent.GetType()}");

        _logger.LogInformation("Published Data - {@Object}", JsonConvert.SerializeObject(externalEvent, Formatting.Indented));
    }
}
