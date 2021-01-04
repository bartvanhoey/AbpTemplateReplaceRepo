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
      await EmailinAppService.SendEmailAsync();
    }

    private async Task SendDefaultEmailAsync()
    {
      await EmailinAppService.SendDefaultEmail();
    }

    private async Task SendHelloGermanyEmailAsync()
    {
      await EmailinAppService.SendHelloGermanyEmail();
    }

    private async Task SendHelloWorldEmailAsync()
    {
      await EmailinAppService.SendHelloWorldEmail();
    }

    private async Task SendWelcomeEmailAsync()
    {
      await EmailinAppService.SendWelcomeEmail();
    }
  }
}
