﻿using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PeachTree.EmailAPI.Models.DTOs;
using PeachTree.EmailAPI.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Channels;

namespace PeachTree.EmailAPI.Messaging
{
    public class RabbitMQCartConsumer : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly EmailService _emailService;
        private IConnection _connection;
        private IModel _channel;

        public RabbitMQCartConsumer(IConfiguration configuration, EmailService emailService)
        {
            _configuration = configuration;
            _emailService = emailService;

            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                Password = "guest",
                UserName = "guest"

            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(_configuration.GetValue<string>("TopicAndQueueNames:EmailShoppingCartQueue"), false, false, false, null);
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                CartDTO cartDTO = JsonConvert.DeserializeObject<CartDTO>(content);
                HandleMessage(cartDTO).GetAwaiter().GetResult();

                _channel.BasicAck(ea.DeliveryTag, false);
            };

            _channel.BasicConsume(_configuration.GetValue<string>("TopicAndQueueNames:EmailShoppingCartQueue"), false, consumer);

            return Task.CompletedTask;
        }

        private async Task HandleMessage(CartDTO cartDTO)
        {
            _emailService.EmailCartAndLog(cartDTO).GetAwaiter()
                .GetResult();
   
        }
    }
}
