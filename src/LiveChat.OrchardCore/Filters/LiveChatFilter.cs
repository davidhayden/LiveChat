using LiveChat.OrchardCore.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OrchardCore.Admin;
using OrchardCore.Entities;
using OrchardCore.ResourceManagement;
using OrchardCore.Settings;

namespace LiveChat.OrchardCore.Filters {
    public class LiveChatFilter : IResultFilter {
        private readonly IResourceManager _resourceManager;
        private readonly ISiteService _siteService;

        public LiveChatFilter(IResourceManager resourceManager, ISiteService siteService) {
            _resourceManager = resourceManager;
            _siteService = siteService;
        }

        public async void OnResultExecuting(ResultExecutingContext filterContext) {
            var siteSettings = await _siteService.GetSiteSettingsAsync();
            var settings = siteSettings.As<LiveChatSettings>();

            // Display only when enabled
            if (settings == null || !settings.Enable) {
                return;
            }

            // Don't display on admin pages
            if (AdminAttribute.IsApplied(filterContext.HttpContext)) {
                return;
            }

            // Should only run on a full view rendering result
            if (!(filterContext.Result is ViewResult)) {
                return;
            }

            var content = new HtmlString(settings.Text);

            _resourceManager.RegisterFootScript(content);
        }

        public void OnResultExecuted(ResultExecutedContext filterContext) { }
    }
}