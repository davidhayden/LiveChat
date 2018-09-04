using System;
using LiveChat.OrchardCore.Drivers;
using Microsoft.Extensions.Localization;
using OrchardCore.Environment.Navigation;

namespace LiveChat.OrchardCore {
    public class AdminMenu : INavigationProvider {
        public AdminMenu(IStringLocalizer<AdminMenu> localizer) {
            T = localizer;
        }

        public IStringLocalizer T { get; set; }

        public void BuildNavigation(string name, NavigationBuilder builder) {
            if (!String.Equals(name, "admin", StringComparison.OrdinalIgnoreCase)) {
                return;
            }

            builder
                .Add(T["Configuration"], configuration => configuration
                    .Add(T["Settings"], settings => settings
                        .Add(T["Live Chat"], T["Live Chat"], chat => chat
                            .Action("Index", "Admin",
                                new {area = "OrchardCore.Settings", groupId = LiveChatSettingsDisplayDriver.GroupId})
                            .Permission(Permissions.ManageLiveChat)
                            .LocalNav()
                        )));
        }
    }
}