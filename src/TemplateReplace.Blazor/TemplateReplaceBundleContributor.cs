using Volo.Abp.Bundling;

namespace TemplateReplace.Blazor
{
    public class TemplateReplaceBundleContributor : IBundleContributor
    {
        public void AddScripts(BundleContext context)
        {
        }

        public void AddStyles(BundleContext context)
        {
            context.Add("main.css");
        }
    }
}
