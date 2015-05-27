using Christoc.Modules.OnlineR.Components;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.AspNet.SignalR;
using Owin;
using System;
using System.Timers;
using System.Web.UI;

[assembly: OwinStartup(typeof(Startup))]

namespace Christoc.Modules.OnlineR.Components
{
    public class Startup
    {
        public string ouTimer = string.Empty;
        public void Configuration(IAppBuilder app)
        {
            System.Net.ServicePointManager.DefaultConnectionLimit = 7;  // Allows 7 conections from the same host
            ValidationSettings.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None; // Permits the use of settings 
            app.MapSignalR();         // Maps the SignalR hubs
            //----------------------------------------------------------------------------------------------------//
            //                                  Saves online users data in the database                           //                                    
            //----------------------------------------------------------------------------------------------------//
            System.Timers.Timer t = new System.Timers.Timer(TimeSpan.FromMinutes(5).TotalMilliseconds); // Set the timer
            t.AutoReset = true;
            t.Elapsed += new System.Timers.ElapsedEventHandler(saveUsersReg);
            t.Start();
        }
        // Function that creates and save the users online number in the db
        private void saveUsersReg(object sender, ElapsedEventArgs e)
        {
            RegUsersOnLine onlineUsers = new RegUsersOnLine();                               // Create the regusersonline object
            onlineUsers.RegOnline = UsersOnLine.users.Count.ToString();
            onlineUsers.RegDate = onlineUsers.RegDate = DateTime.Now;   // Set the parameters
            RegUsersOnLineController rc = new RegUsersOnLineController();
            rc.CreateReg(onlineUsers);            // Uses the function from RegUsersOnLineController to create the reg in the db
        }
    }
}
