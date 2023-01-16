using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp;
using Abp.Extensions;
using Abp.Notifications;
using Abp.Timing;
using Abp.Web.Security.AntiForgery;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using YuanTu.Platform.Configuration;
using YuanTu.Platform.Controllers;

namespace YuanTu.Platform.Web.Host.Controllers
{
    public class HomeController : PlatformControllerBase
    {
        private readonly INotificationPublisher _notificationPublisher;
        private readonly IConfigurationRoot _appConfiguration;

        public HomeController(INotificationPublisher notificationPublisher, IWebHostEnvironment env)
        {
            _notificationPublisher = notificationPublisher;
            _appConfiguration = env.GetAppConfiguration();
        }

        public IActionResult Index()
        {
            if (_appConfiguration["Swagger:IsEnabled"] == null || (bool.TryParse(_appConfiguration["Swagger:IsEnabled"], out var flag) && flag))
                return Redirect("/swagger");
            return Content("Hello World!");
        }

        /// <summary>
        /// This is a demo code to demonstrate sending notification to default tenant admin and host admin uers.
        /// Don't use this code in production !!!
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public ActionResult TestNotification(string message = "")
        {
            return new EmptyResult();
            //if (message.IsNullOrEmpty())
            //{
            //    message = "This is a test notification, created at " + Clock.Now;
            //}

            //var defaultTenantAdmin = new UserIdentifier(1, 2);
            //var hostAdmin = new UserIdentifier(null, 1);

            //await _notificationPublisher.PublishAsync(
            //    "App.SimpleMessage",
            //    new MessageNotificationData(message),
            //    severity: NotificationSeverity.Info,
            //    userIds: new[] { defaultTenantAdmin, hostAdmin }
            //);

            //return Content("Sent notification: " + message);
        } 
    }
}
