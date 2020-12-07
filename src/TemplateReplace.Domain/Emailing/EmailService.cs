using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Emailing;
using Volo.Abp.Emailing.Templates;
using Volo.Abp.TextTemplating;

namespace TemplateReplace.Domain.Emailing
{
    public class EmailService : ITransientDependency
    {
        private readonly IEmailSender _emailSender;
        private readonly ITemplateRenderer _templateRenderer;
        public EmailService(IEmailSender emailSender, ITemplateRenderer templateRenderer)
        {
            _templateRenderer = templateRenderer;
            _emailSender = emailSender;
        }

        public async Task SendAsync(string targetEmail)
        {
            var emailBody = await _templateRenderer
                .RenderAsync(StandardEmailTemplates.Message,
                    new { message = "ABP Framework provides IEmailSender service that is used to send emails." });
       
            await _emailSender.SendAsync(targetEmail, "Subject", emailBody);
        }
    }
}