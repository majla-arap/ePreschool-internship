using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePreschool.Shared.Services.Email
{
    public class Email :IEmail
    {
        private readonly string _apiKey;
        private readonly SendGridClient _client;
        private readonly EmailAddress _fromAddress;

        public Email()
        {
            _apiKey = "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";
            _client = new SendGridClient(_apiKey);
            _fromAddress = new EmailAddress("majla.arap@edu.fit.ba", "Majla");
        }
        public async Task Send(string subject, string body, string toAddress, string name)
        {
            var to = new EmailAddress(toAddress, name);
            var plainTextContent = "and easy to do anywhere, even with C#";
            var msg = MailHelper.CreateSingleEmail(_fromAddress, to, subject, plainTextContent, body);
            await _client.SendEmailAsync(msg).ConfigureAwait(false);
        }
    }
}
