﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Core.Repositories;
using Vehicle.Core.ViewModels;

namespace Vehicle.Core.Services
{
    public class EmailService : IEmailService
    {
        #region Methods

        public async Task SendEmailAsync(EmailModel email)
        {
            MailMessage mail = new MailMessage()
            {
                From = new MailAddress("amirtahakazemtabarzahraei@gmail.com", "Display Name"),
                To = { email.To },
                Subject = email.Subject,
                Body = email.Body,
                IsBodyHtml = true,
            };
            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com", 587) // Host => forExample smtp.gmail.com
            {
                UseDefaultCredentials = true,
                Credentials = new System.Net.NetworkCredential("amirtahakazemtabarzahraei@gmail.com", "amirtahafilm"), // Email  , Password
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
            smtpServer.Send(mail);
            await Task.CompletedTask;
        }

        #endregion
    }
}
