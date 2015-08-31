﻿using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using SendGrid;

namespace Spa.Services
{
    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            await ConfigSendGridasync(message);
        }

        public async Task ConfigSendGridasync(IdentityMessage message)
        {
            var myMessage = new SendGridMessage();

            myMessage.AddTo(message.Destination);
            myMessage.From = new MailAddress("maximustag@gmail.com", "Ivanov Maksim");
            myMessage.Subject = message.Subject;
            myMessage.Text = message.Body;
            myMessage.Html = message.Body;

            var credentials = new NetworkCredential(ConfigurationManager.AppSettings["emailService:Account"],
                                                    ConfigurationManager.AppSettings["emailService:Password"]);

            // Create a Web transport for sending email.
            var transportWeb = new Web(credentials);

            // Send the email.
            if (transportWeb != null)
            {
                await transportWeb.DeliverAsync(myMessage);
            }
            else
            {
                //Trace.TraceError("Failed to create Web transport.");
                await Task.FromResult(0);
            }
        }
    }
}