using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace TemplateReplace
{
    [Dependency(ReplaceServices = true)]
    public class TemplateReplaceBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "TemplateReplace";
    }
}
