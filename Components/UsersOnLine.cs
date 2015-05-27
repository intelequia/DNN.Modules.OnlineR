using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Christoc.Modules.OnlineR.Components
{

    public class UsersOnLine : Hub                           // Hub definition
    {
        public static List<string> users=new List<string>();

        public override System.Threading.Tasks.Task OnConnected()
        {
            string clientId = GetClientId();
   
            if (users.IndexOf(clientId)==-1) {               // When a user connect to the page we search in the list his client id
                users.Add(clientId);                         // If not exist in the list we add his id 
            }

            ShowUsersOnLine();

            return base.OnConnected();
        }

        public override System.Threading.Tasks.Task OnReconnected()
        {
            string clientId = GetClientId();
            if (users.IndexOf(clientId) == -1)             // Same as before
            {
                users.Add(clientId);
            }

            ShowUsersOnLine();
            return base.OnReconnected();
        }

        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            string clientId = GetClientId();
            
            if (users.IndexOf(clientId) > -1)            // When the user disconects if exist in the list 
            {
                users.Remove(clientId);                  // Then remove it
            }

            ShowUsersOnLine();

            return base.OnDisconnected(stopCalled);
        }


        private string GetClientId() {                   // Method that returns the id of the client
            string clientId = "";
            if (!(Context.QueryString["clientId"] == null))
            {
                clientId = Context.QueryString["clientId"].ToString();
            }

            if (string.IsNullOrEmpty(clientId.Trim()))
            {
                clientId = Context.ConnectionId;
            }

            return clientId;
        
        }

        public void ShowUsersOnLine()                 // Send the list count to all clients
        {
            Clients.All.showUsersOnLine(users.Count);
        }
    }
}

  

