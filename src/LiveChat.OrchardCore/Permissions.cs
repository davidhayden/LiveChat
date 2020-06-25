using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrchardCore.Security.Permissions;

namespace LiveChat.OrchardCore {
    public class Permissions : IPermissionProvider {
        public static readonly Permission ManageLiveChat = new Permission("ManageLiveChat", "Manage Live Chat");

        public Task<IEnumerable<Permission>> GetPermissionsAsync() {
            return Task.FromResult(new[] {
                ManageLiveChat
            }.AsEnumerable());
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