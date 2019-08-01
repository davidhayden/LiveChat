using System.Threading.Tasks;
using LiveChat.OrchardCore.Models;
using LiveChat.OrchardCore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using OrchardCore.DisplayManagement.Entities;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.Settings;

namespace LiveChat.OrchardCore.Drivers {
    public class LiveChatSettingsDisplayDriver : SectionDisplayDriver<ISite, LiveChatSettings> {
        public const string GroupId = "chat";
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthorizationService _authorizationService;

        public LiveChatSettingsDisplayDriver(
            IHttpContextAccessor httpContextAccessor,
            IAuthorizationService authorizationService) {
            _httpContextAccessor = httpContextAccessor;
            _authorizationService = authorizationService;
        }

        public override async Task<IDisplayResult> EditAsync(LiveChatSettings settings, BuildEditorContext context) {
            var user = _httpContextAccessor.HttpContext?.User;

            if (!await _authorizationService.AuthorizeAsync(user, Permissions.ManageLiveChat)) {
                return null;
            }

            return Initialize<LiveChatSettingsViewModel>("LiveChatSettings_Edit", m => {
                m.Enable = settings.Enable;
                m.Text = settings.Text;
            }).Location("Content:1").OnGroup(GroupId);
        }

        public override async Task<IDisplayResult> UpdateAsync(LiveChatSettings settings, BuildEditorContext context) {
            var user = _httpContextAccessor.HttpContext?.User;

            if (!await _authorizationService.AuthorizeAsync(user, Permissions.ManageLiveChat)) {
                return null;
            }

            if (context.GroupId == GroupId) {
                var model = new LiveChatSettingsViewModel();

                await context.Updater.TryUpdateModelAsync(model, Prefix);

                settings.Enable = model.Enable;
                settings.Text = model.Text;
            }

            return await EditAsync(settings, context);
        }
    }
}