using LiveChat.OrchardCore.Deployment;
using LiveChat.OrchardCore.Drivers;
using LiveChat.OrchardCore.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Deployment;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.Navigation;
using OrchardCore.Modules;
using OrchardCore.Security.Permissions;
using OrchardCore.Settings;

namespace LiveChat.OrchardCore {
    public class Startup : StartupBase {
        public override void ConfigureServices(IServiceCollection services) {
            services.AddScoped<IDisplayDriver<ISite>, LiveChatSettingsDisplayDriver>();
            services.AddScoped<IPermissionProvider, Permissions>();
            services.AddScoped<INavigationProvider, AdminMenu>();

            services.AddTransient<IDeploymentSource, LiveChatDeploymentSource>();
            services.AddSingleton<IDeploymentStepFactory>(new DeploymentStepFactory<LiveChatDeploymentStep>());
            services.AddScoped<IDisplayDriver<DeploymentStep>, LiveChatDeploymentStepDriver>();

            services.Configure<MvcOptions>((options) => { options.Filters.Add(typeof(LiveChatFilter)); });
        }
    }
}