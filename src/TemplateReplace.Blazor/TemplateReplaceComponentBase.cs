using TemplateReplace.Localization;
using Volo.Abp.AspNetCore.Components;

namespace TemplateReplace.Blazor
{
    public abstract class TemplateReplaceComponentBase : AbpComponentBase
    {
        protected TemplateReplaceComponentBase()
        {
            LocalizationResource = typeof(TemplateReplaceResource);
        }
    }
}
