using Microsoft.AspNet.Identity;
using SendGrid;
using System.Net.Mail;
using System.Configuration;
using System.Net;
using System.Threading.Tasks;

namespace CoachingPlan.Infraestructure.Identity.Services
{
    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            await configSendGridasync(message);
        }

        // Use NuGet to install SendGrid (Basic C# client lib) 
        private async Task configSendGridasync(IdentityMessage message)
        {
            MailMessage msg = new MailMessage();
            msg.To.Add(message.Destination);
            msg.Subject = message.Subject;
            msg.Body = message.Body;
            msg.IsBodyHtml = true;
            msg.From = new MailAddress("contato@coachingplan.com");

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("coachingplansystem@gmail.com", "system2015");

            smtp.Send(msg);

                await Task.FromResult(0);
        }
    }
}
