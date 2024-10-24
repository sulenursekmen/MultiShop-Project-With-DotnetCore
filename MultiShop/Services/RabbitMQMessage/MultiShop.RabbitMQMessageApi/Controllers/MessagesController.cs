using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace MultiShop.RabbitMQMessageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateMessage()
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost",
            };
            var connection = connectionFactory.CreateConnection();

            var channel = connection.CreateModel();

            channel.QueueDeclare("Queue2", false, false, false, arguments: null);

            var messageContent = "Test Message RabbitMQ 2.40";

            var byteMessageContent = Encoding.UTF8.GetBytes(messageContent);

            channel.BasicPublish(exchange: "", routingKey: "Queue2", basicProperties: null, body: byteMessageContent);

            return Ok("Created message");
        }

        [HttpGet]
        public IActionResult ReadMessage()
        {
            string message = "";
            var connectionFactory = new ConnectionFactory() { HostName = "localhost" };

            using (var connection = connectionFactory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                // get message from queue
                var result = channel.BasicGet(queue: "Queue2", autoAck: false); // 'autoAck' ile otomatik onaylama

                if (result != null)
                {
                    var byteMessage = result.Body.ToArray();
                    message = Encoding.UTF8.GetString(byteMessage);
                }
                else
                {
                    message = "No messages in the queue";
                }
            }

            return Ok(message);
        }
        #region different method ReadMessage
        //[HttpGet]
        //public IActionResult ReadMessage()
        //{
        //    string message = "";
        //    var connectionFactory = new ConnectionFactory() { HostName = "localhost" };

        //    var connection = connectionFactory.CreateConnection();
        //    var channel = connection.CreateModel();

        //    // Kuyruktan mesajı çek
        //    var result = channel.BasicGet(queue: "Queue2", autoAck: true); // 'autoAck' ile otomatik onaylama

        //    if (result != null)
        //    {
        //        var byteMessage = result.Body.ToArray();
        //        message = Encoding.UTF8.GetString(byteMessage);
        //    }
        //    else
        //    {
        //        message = "No messages in the queue";
        //    }

        //    // Bağlantı ve kanal kapatılıyor
        //    channel.Close();
        //    connection.Close();

        //    return Ok(message);
        //}
        #endregion

    }
}
