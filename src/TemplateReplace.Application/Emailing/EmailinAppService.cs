using System.Threading.Tasks;
using TemplateReplace.Application.Contracts.Emailing;
using TemplateReplace.Domain.Emailing;

namespace TemplateReplace.Application.Emailing
{
    public class EmailinAppService : TemplateReplaceAppService, IEmailinAppService
    {
        private readonly EmailService _emailService;

        public EmailinAppService(EmailService emailService)
        {
            _emailService = emailService;

        }
        public async Task SendEmail()
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
    }
}