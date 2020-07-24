using System.Threading.Tasks;
using LiveChat.OrchardCore.Models;
using Newtonsoft.Json.Linq;
using OrchardCore.Deployment;
using OrchardCore.Entities;
using OrchardCore.Settings;

namespace LiveChat.OrchardCore.Deployment {
    public class LiveChatDeploymentSource : IDeploymentSource {
        private readonly ISiteService _siteService;

        public LiveChatDeploymentSource(ISiteService siteService) {
            _siteService = siteService;
        }

        public async Task ProcessDeploymentStepAsync(DeploymentStep step, DeploymentPlanResult result) {
            var liveChatState = step as LiveChatDeploymentStep;

            if (liveChatState == null) {
                return;
            }

            var siteSettings = await _siteService.GetSiteSettingsAsync();

            // Adding Layer settings
            result.Steps.Add(new JObject(
                new JProperty("name", "Settings"),
                new JProperty("LiveChatSettings", JObject.FromObject(siteSettings.As<LiveChatSettings>()))
            ));
        }
    }
}