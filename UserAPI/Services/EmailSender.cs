using UserAPI.RabbitMq.Models;
using UserAPI.RabbitMq.Sender;
using UserAPI.Services.Interfaces;

namespace UserAPI.Services
{
    public class EmailSender : IEmailSender
    {
        private const string BASE_URL = "http://localhost:3000";
        private readonly IRabbitMqSender _rabbitMqSender;
        public EmailSender(IRabbitMqSender rabbitMqSender)
        {
            _rabbitMqSender = rabbitMqSender;
        }
        public void SendEmail(EmailHeader email, string type)
        {
            EmailHeader emailSender = new EmailHeader();
            emailSender.Email = email.Email;
            emailSender.UserId = email.UserId;
            if (type == "confirm")
            {
                emailSender.Subject = "Confirm your email";
                emailSender.Message = formatVerifyEmail(email.Message);
            }
            else if (type == "reset")
            {
                emailSender.Subject = "Reset your password";
                emailSender.Message = formatResetEmail(email.Message);
            }
            else
            {
                emailSender.Subject = email.Subject;
                emailSender.Message = email.Message;
            }
            _rabbitMqSender.SendMessage(emailSender, "EmailQueue");
        }
        private string formatVerifyEmail(string token)
        {
            string link = BASE_URL + "/user/verify/" + token;
            return "<div style=\"width: 100%; height: 100%; background-color: #f2f2f2; padding: 50px 0;\">" +
                        "<div style=\"width: 100%; max-width: 600px; margin: 0 auto; background-color: #2f2945; padding: 50px 50px;\">" +
                            "<div style=\"position: absolute; width: 200px;\">" +
                                "<img width=\"120px\" src=\"https://res.cloudinary.com/ddd8z6szf/image/upload/v1685300309/Mobox/Picture1_y5vr7g.png\" alt=\"logo\" />" +
                            "</div>"+
                            "<div style=\"width: 100%; text-align: center;\">" +
                                "<h1 style=\"font-size: 30px; font-weight: 600; margin-bottom: 50px; color: #fffdfd;\">Verify your account</h1>" +
                            "</div>" +
                            "<div style=\"width: 100%; text-align: center;\">" +
                                $"<a href=\"{link}\" style=\"font-size: 16px; font-weight: 600; color: #fffdfd; background-color: #6483f3ec; padding: 10px 20px; border-radius: 5px; text-decoration: none;\">Click Here</a>" +
                            "</div>" +
                        "</div>" +
                    "</div>";
        }
        private string formatResetEmail(string token)
        {
            string link = BASE_URL + "/user/reset-password/" + token;
            return "<div style=\"width: 100%; height: 100%; background-color: #f2f2f2; padding: 50px 0;\">" +
                        "<div style=\"width: 100%; max-width: 600px; margin: 0 auto; background-color: #2f2945; padding: 50px 50px;\">" +
                            "<div style=\"position: absolute; width: 200px;\">" +
                                "<img width=\"120px\" src=\"https://res.cloudinary.com/ddd8z6szf/image/upload/v1685300309/Mobox/Picture1_y5vr7g.png\" alt=\"logo\" />" +
                            "</div>" +
                            "<div style=\"width: 100%; text-align: center;\">" +
                                "<h1 style=\"font-size: 30px; font-weight: 600; margin-bottom: 50px; color: #fffdfd;\">Reset your password</h1>" +
                            "</div>" +
                            "<div style=\"width: 100%; text-align: center;\">" +
                                $"<a href=\"{link}\" style=\"font-size: 16px; font-weight: 600; color: #fffdfd; background-color: #6483f3ec; padding: 10px 20px; border-radius: 5px; text-decoration: none;\">Click Here</a>" +
                            "</div>" +
                        "</div>" +
                    "</div>";
        }

    }
}
