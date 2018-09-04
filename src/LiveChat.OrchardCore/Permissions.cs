using System.Collections.Generic;
using OrchardCore.Security.Permissions;

namespace LiveChat.OrchardCore {
    public class Permissions : IPermissionProvider {
        public static readonly Permission ManageLiveChat = new Permission("ManageLiveChat", "Manage Live Chat");

        public IEnumerable<Permission> GetPermissions() {
            return new[] {ManageLiveChat};
        }

        public IEnumerable<PermissionStereotype> GetDefaultStereotypes() {
            return new[] {
                new PermissionStereotype {
                    Name = "Administrator",
                    Permissions = new[] {ManageLiveChat}
                }
            };
        }
    }
}