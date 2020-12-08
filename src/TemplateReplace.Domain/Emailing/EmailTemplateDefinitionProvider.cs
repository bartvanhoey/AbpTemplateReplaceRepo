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

      // TODO: Why does it not find the specific template for a given culture     
      // When you click on the WelcomeEmail button the application throws exception below
      // Volo.Abp.AbpException: Could not find a file/folder at the location: /Emailing/WelcomeEmail/Templates

      context.Add(
              new TemplateDefinition("WelcomeEmail", defaultCultureName: "en")
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