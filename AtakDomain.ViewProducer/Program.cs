using AtakDomain.Common.Models;
using Confluent.Kafka;
using Newtonsoft.Json;

var rootPath = AppContext.BaseDirectory;
var viewFile = rootPath + "product-views.json";
var topicName = "product-views";
var kafkaUrl = "localhost:9092";

var config = new ProducerConfig
{
    BootstrapServers = kafkaUrl
};

if (File.Exists(viewFile))
{
    var lines = File.ReadAllLines(viewFile);
    foreach (var line in lines)
    {
        var _event = JsonConvert.DeserializeObject<ViewEvent>(line);
        _event.Timestamp = DateTime.Now;
        var message = JsonConvert.SerializeObject(_event);

        using var producer = new ProducerBuilder<Null, string>(config).Build();
        producer.Produce(topicName, new Message<Null, string> { Value = message },
            (deliveryReport) =>
            {
                if (deliveryReport.Error.Code != ErrorCode.NoError)
                {
                    Console.WriteLine($"Failed to deliver message: {deliveryReport.Error.Reason}");
                }
                else
                {
                    Console.WriteLine($"Produced message to: {deliveryReport.TopicPartitionOffset}");
                }
            });
        producer.Flush(TimeSpan.FromSeconds(10));
        Thread.Sleep(1000);
    }
}