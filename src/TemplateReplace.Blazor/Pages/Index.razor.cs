using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TemplateReplace.Application.Contracts.Emailing;

namespace TemplateReplace.Blazor.Pages
{
    public partial class Index
    {
        [Inject] protected IEmailingAppService EmailinAppService { get; set; }

        private async Task SendEmailAsync()
        {
            await EmailinAppService.SendEmail();
        }
    }
}
