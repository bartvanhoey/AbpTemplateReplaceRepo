using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace TemplateReplace.Application.Contracts.Emailing
{
    public interface IEmailingAppService  : IApplicationService
    {
         Task SendDefaultEmail();
         Task SendHelloWorldEmail();
         Task SendHelloGermanyEmail();
         Task SendWelcomeEmail();
    }
}