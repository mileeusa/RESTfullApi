using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Azure.Messaging.EventGrid;
using System.Text.Json;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;

namespace AzureEventOps.src
{
    /// <summary>
    /// The Azure Function class to listen for Event Grid events and processes them.
    /// </summary>
    public class EventGridTriggerFunction
    {
        private readonly ILogger _logger;

        public EventGridTriggerFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<EventGridTriggerFunction>();
        }

        [Function("EventGridTriggerFunction")]
        public void Run([EventGridTrigger] EventGridEvent eventGridEvent)
        {
            _logger.LogInformation($"📩 Event received: {eventGridEvent.EventType}");
            _logger.LogInformation($"Subject: {eventGridEvent.Subject}");

            // Deserialize event data
            var json = eventGridEvent.Data.ToString();
            _logger.LogInformation($"Data: {json}");

            // Optional: parse to a known type
            try
            {
                var order = JsonSerializer.Deserialize<OrderData>(json);
                _logger.LogInformation($"Order {order?.OrderId} from {order?.Customer}, total ${order?.Total}");
            }
            catch
            {
                _logger.LogWarning("Could not deserialize event data.");
            }
        }

        private record OrderData(int OrderId, string Customer, double Total);
    }
}

