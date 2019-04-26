using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace CouponMerchant.Email
{
    public class EmailSender : IEmailSender
    {
        public EmailOptions Options { get; set; }

        public EmailSender(IOptions<EmailOptions> emailOptions)
        {
            Options = emailOptions.Value;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SendGridClient(Options.SendGridKey);
            var message = new SendGridMessage
            {
                From = new EmailAddress("admin@couponmerchant.com", "Coupon Merchant"),
                Subject = subject,
                PlainTextContent = htmlMessage,
                HtmlContent = htmlMessage
            };

            message.AddTo(new EmailAddress(email));

            try
            {
                return client.SendEmailAsync(message);
            }
            catch (Exception)
            {
            }

            return null;
        }
    }
}
