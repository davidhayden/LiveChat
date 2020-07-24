using OrchardCore.Deployment;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.DisplayManagement.Views;

namespace LiveChat.OrchardCore.Deployment
{
    public class LiveChatDeploymentStepDriver : DisplayDriver<DeploymentStep, LiveChatDeploymentStep>
    {
        public override IDisplayResult Display(LiveChatDeploymentStep step)
        {
            return
                Combine(
                    View("LiveChatDeploymentStep_Summary", step).Location("Summary", "Content"),
                    View("LiveChatDeploymentStep_Thumbnail", step).Location("Thumbnail", "Content")
                );
        }

        public override IDisplayResult Edit(LiveChatDeploymentStep step)
        {
            return View("LiveChatDeploymentStep_Edit", step).Location("Content");
        }
    }
}