using AtakDomain.Common.Entities;
using AtakDomain.Common.Models;
using AtakDomain.StreamReader;
using Confluent.Kafka;
using Newtonsoft.Json;

var topicName = "product-views";
var kafkaUrl = "localhost:9092";

var config = new ConsumerConfig
{
    BootstrapServers = kafkaUrl,
    GroupId = "product-views-group",
    AutoOffsetReset = AutoOffsetReset.Earliest
};

using (var consumer = new ConsumerBuilder<Null, string>(config).Build())
{
    consumer.Subscribe(topicName);
    var cancelToken = new CancellationTokenSource();

    try
    {
        while (true)
        {
            var consumeResult = consumer.Consume(cancelToken.Token);

            var _event = JsonConvert.DeserializeObject<ViewEvent>(consumeResult.Message.Value);
            if (_event != null)
            {
                //var product = new Product(_event.Properties.ProductId);
                //DbWriter.WriteProduct(product);

                //var user = new User(_event.UserId);
                //DbWriter.WriteUser(user);

                var history = new History(_event.UserId, _event.Properties.ProductId, _event.Timestamp);
                DbWriter.WriteHistory(history);
            }

            Console.WriteLine($"Consumed message '{consumeResult.Message.Value}' at: '{consumeResult.TopicPartitionOffset}'");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}