using Azure;
using Azure.Messaging.EventGrid;
using AzureEventOps.src;

namespace AzureEventOps
{
    public class Program
    {
        // publish an event to Azure Event Grid
        static async Task Main()
        {
            string topicEndpoint = "https://<your-topic-name>.<region>-1.eventgrid.azure.net/api/events";
            string topicKey = "<your-access-key>";

            var client = new EventGridPublisherClient(
                new Uri(topicEndpoint),
                new AzureKeyCredential(topicKey)
            );

            var events = new List<EventGridEvent>
        {
            new EventGridEvent(
                subject: "order/new",
                eventType: "Order.Created",
                dataVersion: "1.0",
                data: new { OrderId = 1234, Customer = "Jane Doe", Total = 199.99 }
            )
        };

            await client.SendEventsAsync(events);

            Console.WriteLine("✅ Event sent to Azure Event Grid!");
        }
    }
}