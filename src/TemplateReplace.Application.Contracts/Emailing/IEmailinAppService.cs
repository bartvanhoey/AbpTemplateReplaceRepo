using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace TemplateReplace.Application.Contracts.Emailing
{
    public interface IEmailinAppService  : IApplicationService
    {
         Task SendEmail();
    }
}