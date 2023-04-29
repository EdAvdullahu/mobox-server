using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using SongAPI.Services.Interface;
using System.Security.Principal;
using System.DirectoryServices.AccountManagement;

namespace SongAPI.Services
{
    public class Test: ITest
    {

        public async Task TestService()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("SSPMS", "sspms2023@gmail.com"));
            message.To.Add(new MailboxAddress("ME","avdullahuedi@gmail.com"));
            message.Subject = "MOBOX-SERVER Song API";
            var uN = Environment.UserName;
            message.Body = new TextPart("plain") { Text = $"MOBOX - Song Api by {uN}." };

            using var client = new SmtpClient();
            await client.ConnectAsync("smtp.gmail.com", int.Parse("587"), SecureSocketOptions.StartTls);
            await client.AuthenticateAsync("sspms2023@gmail.com", "enhxxekpfzplfywq");
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }

    }
}
