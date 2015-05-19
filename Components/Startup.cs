using Christoc.Modules.OnlineR.Components;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.UI;

[assembly: OwinStartup(typeof(Startup))]

namespace Christoc.Modules.OnlineR.Components
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            System.Net.ServicePointManager.DefaultConnectionLimit = 7;  // Allows 7 conections from the same host
            ValidationSettings.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None; // Permits the use of settings 
            app.MapSignalR();         // Maps the SignalR hubs
        }

    }
}
