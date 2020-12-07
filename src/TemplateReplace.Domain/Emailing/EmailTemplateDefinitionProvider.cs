using Volo.Abp.DependencyInjection;
using Volo.Abp.Emailing.Templates;
using Volo.Abp.TextTemplating;

namespace TemplateReplace.Domain.Emailing
{
  public class EmailTemplateDefinitionProvider : TemplateDefinitionProvider, ITransientDependency
  {
    public override void Define(ITemplateDefinitionContext context)
    {
      // default template
      var emailLayoutTemplate = context.GetOrNull(StandardEmailTemplates.Message);
      emailLayoutTemplate.WithVirtualFilePath("/Emailing/Templates/EmailTemplate.tpl", isInlineLocalized: true);

      // context.Add(
      //        new TemplateDefinition("WelcomeEmail", defaultCultureName: "en")
      //        .WithVirtualFilePath("/Emailing/WelcomeEmail/Templates", isInlineLocalized: false));

      //TODO application throws Exception because doesn't find the template for the specific language

      context.Add(new TemplateDefinition("EmailLayout", isLayout: true)
        .WithVirtualFilePath("/Emailing/EmailLayout/EmailLayout.tpl", isInlineLocalized: true ));

      context.Add(new TemplateDefinition(name: "WelcomeEmail", defaultCultureName: "en", layout: "EmailLayout" )
        .WithVirtualFilePath("/Emailing/WelcomeEmail/Templates", isInlineLocalized: false));

      context.Add(
        new TemplateDefinition("HelloWorld")
          .WithVirtualFilePath("/Emailing/Templates/HelloWorldTemplate.tpl", isInlineLocalized: true));

      context.Add(
        new TemplateDefinition("HelloGermany")
          .WithVirtualFilePath("/Emailing/Templates/HelloGermanyTemplate.tpl", isInlineLocalized: true));


    }
  }
}