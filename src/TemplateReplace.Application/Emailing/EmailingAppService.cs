using System.Threading.Tasks;
using TemplateReplace.Application.Contracts.Emailing;
using TemplateReplace.Domain.Emailing;

namespace TemplateReplace.Application.Emailing
{
  public class EmailingAppService : TemplateReplaceAppService, IEmailingAppService
  {
    private readonly EmailService _emailService;

    public EmailingAppService(EmailService emailService)
    {
      _emailService = emailService;
    }


    public async Task SendDefaultEmail()
    {
      try
      {
        await _emailService.SendAsync("bartvanhoey@hotmail.com");
      }
      catch (System.Exception ex)
      {
        var msg = ex.Message;
        throw;
      }

    }

    public async Task SendHelloGermanyEmail()
    {
      await _emailService.SendHelloGermanyAsync("bartvanhoey@hotmail.com", "Bart Van Hoey");
    }

    public async Task SendHelloWorldEmail()
    {
      await _emailService.SendHelloWorldAsync("bartvanhoey@hotmail.com");
    }

    public async Task SendWelcomeEmail()
    {
      await _emailService.SendWelcomeEmail("bartvanhoey@hotmail.com");
    }



  }
}