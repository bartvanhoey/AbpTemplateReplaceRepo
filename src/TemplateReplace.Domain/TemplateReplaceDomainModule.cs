﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TemplateReplace.Localization;
using TemplateReplace.MultiTenancy;
using Volo.Abp;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Emailing;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.IdentityServer;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement.Identity;
using Volo.Abp.PermissionManagement.IdentityServer;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.VirtualFileSystem;

namespace TemplateReplace
{
    [DependsOn(
        typeof(TemplateReplaceDomainSharedModule),
        typeof(AbpAuditLoggingDomainModule),
        typeof(AbpBackgroundJobsDomainModule),
        typeof(AbpFeatureManagementDomainModule),
        typeof(AbpIdentityDomainModule),
        typeof(AbpPermissionManagementDomainIdentityModule),
        typeof(AbpIdentityServerDomainModule),
        typeof(AbpPermissionManagementDomainIdentityServerModule),
        typeof(AbpSettingManagementDomainModule),
        typeof(AbpTenantManagementDomainModule),
        typeof(AbpEmailingModule)
    )]
    public class TemplateReplaceDomainModule : AbpModule
    {
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            // var settingManager = context.ServiceProvider.GetService<SettingManager>();
            // settingManager.SetGlobalAsync(EmailSettingNames.Smtp.Host, "smtp.gmail.com");
            // settingManager.SetGlobalAsync(EmailSettingNames.Smtp.Port, "587");
            // settingManager.SetGlobalAsync(EmailSettingNames.Smtp.UserName, "bartvanhoey@gmail.com" );
            // settingManager.SetGlobalAsync(EmailSettingNames.Smtp.Password, "" );
            // settingManager.SetGlobalAsync(EmailSettingNames.Smtp.EnableSsl, "true");
            // settingManager.SetGlobalAsync(EmailSettingNames.Smtp.UseDefaultCredentials, "false");
        }
        
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpMultiTenancyOptions>(options =>
            {
                options.IsEnabled = MultiTenancyConsts.IsEnabled;
            });

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<TemplateReplaceDomainModule>("TemplateReplace");
            });

  

// #if DEBUG
//             context.Services.Replace(ServiceDescriptor.Singleton<IEmailSender, NullEmailSender>());
// #endif
        }
    }
}
