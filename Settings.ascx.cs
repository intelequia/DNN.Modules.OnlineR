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
using Christoc.Modules.OnlineR.Components;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;

namespace Christoc.Modules.OnlineR
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The Settings class manages Module Settings
    /// 
    /// Typically your settings control would be used to manage settings for your module.
    /// There are two types of settings, ModuleSettings, and TabModuleSettings.
    /// 
    /// ModuleSettings apply to all "copies" of a module on a site, no matter which page the module is on. 
    /// 
    /// TabModuleSettings apply only to the current module on the current page, if you copy that module to
    /// another page the settings are not transferred.
    /// 
    /// If you happen to save both TabModuleSettings and ModuleSettings, TabModuleSettings overrides ModuleSettings.
    /// 
    /// Below we have some examples of how to access these settings but you will need to uncomment to use.
    /// 
    /// Because the control inherits from OnlineRSettingsBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class Settings : OnlineRModuleSettingsBase
    {
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// LoadSettings loads the settings from the Database and displays them
        /// </summary>
        /// -----------------------------------------------------------------------------
         public override void LoadSettings()
         {
             try
             {
                 if (Page.IsPostBack == false)
                 {
                     //Check for existing settings and use those on this page               
                     txtTitle.Text = Settings.Contains("onlinerTitle") ? Settings["onlinerTitle"].ToString() : Localization.GetString("onlinerTitle", "/DesktopModules/OnlineR/App_LocalResources/Settings.ascx.resx");
                     txtPrimaryColor.Text = Settings.Contains("primaryColor") ? Settings["primaryColor"].ToString() : Localization.GetString("primaryColor", "/DesktopModules/OnlineR/App_LocalResources/Settings.ascx.resx");
                     String selectedSkin = Settings.Contains("selectedSkin") ? Settings["selectedSkin"].ToString() : Localization.GetString("selectedSkin", "/DesktopModules/OnlineR/App_LocalResources/Settings.ascx.resx");
                     for (int i = 0; i<ddlSelectedSkin.Items.Count; i++)
                     {
                         if (ddlSelectedSkin.Items[i].Value == selectedSkin)
                         {
                             ddlSelectedSkin.SelectedIndex = i;
                         }
                     }
                 }
             }
             catch (Exception exc) //Module failed to load
             {
                 Exceptions.ProcessModuleLoadException(this, exc);
             }
         }

         /// -----------------------------------------------------------------------------
         /// <summary>
         /// UpdateSettings saves the modified settings to the Database
         /// </summary>
         /// -----------------------------------------------------------------------------
         public override void UpdateSettings()
         {
             try
             {
                 var modules = new ModuleController();
                 modules.UpdateModuleSetting(ModuleId, "onlinerTitle", txtTitle.Text);
                 modules.UpdateModuleSetting(ModuleId, "primaryColor", txtPrimaryColor.Text); // Update this settings in the local resorce (App_LocalResources)
                 modules.UpdateModuleSetting(ModuleId, "selectedSkin", ddlSelectedSkin.SelectedValue);
             }
             catch (Exception exc) //Module failed to load
             {
                 Exceptions.ProcessModuleLoadException(this, exc);
             }
         }
    }
}