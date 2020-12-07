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