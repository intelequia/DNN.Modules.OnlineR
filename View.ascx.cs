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
using System.Timers;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Localization;
using Christoc.Modules.OnlineR.Components;
using Microsoft.AspNet.SignalR;

namespace Christoc.Modules.OnlineR
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The View class displays the content
    /// 
    /// Typically your view control would be used to display content or functionality in your module.
    /// 
    /// View may be the only control you have in your project depending on the complexity of your module
    /// 
    /// Because the control inherits from OnlineRModuleBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// 
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class View : OnlineRModuleBase, IActionable
    {
        public string onlinerTitle = string.Empty;
        public string primaryColor = string.Empty;         
        public string selectedSkin = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try //Load Resources, if they don't exist, load default settings
            {
                onlinerTitle = Settings.Contains("onlinerTitle") ? Settings["onlinerTitle"].ToString() : Localization.GetString("onlinerTitle", LocalResourceFile);
                if (String.IsNullOrEmpty(onlinerTitle))
                    onlinerTitle = "Online Users";
                primaryColor = Settings.Contains("primaryColor") ? Settings["primaryColor"].ToString() : Localization.GetString("primaryColor", LocalResourceFile);
                if (String.IsNullOrEmpty(primaryColor))
                    primaryColor = "#009688";
                selectedSkin = Settings.Contains("selectedSkin") ? Settings["selectedSkin"].ToString() : Localization.GetString("selectedSkin", LocalResourceFile);
                if (String.IsNullOrEmpty(selectedSkin))
                    selectedSkin = "Material.css";
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        public ModuleActionCollection ModuleActions
        {
            get
            {
                var actions = new ModuleActionCollection
                    {
                        {
                            GetNextActionID(), Localization.GetString("EditModule", LocalResourceFile), "", "", "",
                            EditUrl(), false, SecurityAccessLevel.Edit, true, false
                        }
                    };
                return actions;
            }
        }
    }
}