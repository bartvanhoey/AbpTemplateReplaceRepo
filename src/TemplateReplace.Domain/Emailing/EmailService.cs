using System.Globalization;
using System.Threading.Tasks;
using TemplateReplace.Domain.Emailing.Models;
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

    public async Task SendEmailToVerifyEmailAddressAfterRegistration()
    {
         await _emailSender.SendAsync(
          "bartvanhoey@hotmail.com",     // target email address
          "Email subject",         // subject
          "This is email body..."  // email body
      );
    }

    public async Task SendAsync(string targetEmail)
    {
      var emailBody = await _templateRenderer
          .RenderAsync(StandardEmailTemplates.Message,
              new { message = "ABP Framework provides IEmailSender service that is used to send emails." });

      await _emailSender.SendAsync(targetEmail, "Subject", emailBody);
    }

    public async Task SendHelloWorldAsync(string targetEmail)
    {
      var emailBody = await _templateRenderer
          .RenderAsync("HelloWorld",
              new { message = "ABP Framework provides IEmailSender service that is used to send emails." });

      await _emailSender.SendAsync(targetEmail, "Hello World", emailBody);
    }

    public async Task SendHelloGermanyAsync(string targetEmail, string name)
    {
      var emailBody = await _templateRenderer
          .RenderAsync("HelloGermany",
              new HelloGermanyModel { Name = name });

      await _emailSender.SendAsync(targetEmail, "Hello Germany", emailBody);
    }


    public async Task SendWelcomeEmail(string targetEmail)
    {
      var culture = CultureInfo.CurrentUICulture.Name;
      var emailBody = await _templateRenderer.RenderAsync("WelcomeEmail", cultureName: culture);

      await _emailSender.SendAsync(targetEmail, "WelcomeEmail", emailBody);
    }

  }
}