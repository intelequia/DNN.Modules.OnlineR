/*
' Copyright (c) 2015  Christoc.com
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using System;
using DotNetNuke.Services.Exceptions;
using System.Collections.Generic;
using Microsoft.AspNet.SignalR;
using Christoc.Modules.OnlineR.Components;
using System.Linq;
using Newtonsoft.Json;
namespace Christoc.Modules.OnlineR
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The EditOnlineR class is used to manage content
    /// 
    /// Typically your edit control would be used to create new content, or edit existing content within your module.
    /// The ControlKey for this control is "Edit", and is defined in the manifest (.dnn) file.
    /// 
    /// Because the control inherits from OnlineRModuleBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// 
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class Edit : OnlineRModuleBase
    {
        public int maxUsersYear;
        public int maxUsersMonth;
        public int maxUsersWeek;
        public string json;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                RegUsersOnLineController rc = new RegUsersOnLineController(); // Create the controller object
                List<int> resultYear = rc.GetMaxUsersYear().ToList();         // Convert Ienumerable in a list<int> 
                maxUsersYear = resultYear.First();                            // Extract from the list the first value
                List<int> resultMonth = rc.GetMaxUsersMonth().ToList();         // Convert Ienumerable in a list<int> 
                maxUsersMonth = resultMonth.First();
                List<int> resultWeek = rc.GetMaxUsersWeek().ToList();         // Convert Ienumerable in a list<int> 
                maxUsersWeek = resultWeek.First();
                List<RegUsersOnLine> resultdata = rc.GetUsersThisDay().ToList();
                json = JsonConvert.SerializeObject(resultdata, Formatting.Indented); // Convert the List into a Json that will be used in the client side
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }
    }
}