<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Settings.ascx.cs" Inherits="Christoc.Modules.OnlineR.Settings" %>


<!-- uncomment the code below to start using the DNN Form pattern to create and update settings -->
 

<%@ Register TagName="label" TagPrefix="dnn" Src="~/controls/labelcontrol.ascx" %>

	<h2 id="dnnSitePanel-BasicSettings" class="dnnFormSectionHead"><a href="" class="dnnSectionExpanded"><%=LocalizeString("BasicSettings")%></a></h2>
	<fieldset>
        <div class="dnnFormItem">
            <dnn:Label ID="lblTitle" runat="server" /> 
            <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
        </div>
    </fieldset>
    <fieldset>
        <div class="dnnFormItem">
            <dnn:Label ID="lblPrimaryColor" runat="server" />
            <asp:TextBox ID="txtPrimaryColor" runat="server"></asp:TextBox>
        </div>
    </fieldset>
    <fieldset>
    <div class="dnnFormItem">
        <dnn:Label ID="lblSelectedSkin" runat="server" />
        <asp:DropDownList runat="server" ID="ddlSelectedSkin" DataTextField="skinName" DataValueField="skinFile">
            <asp:ListItem Value="Material.css">Material</asp:ListItem>
            <asp:ListItem Value="Tile.css">Tile</asp:ListItem>
            <asp:ListItem Value="Social.css">Social</asp:ListItem>
            <asp:ListItem Value="Minimalist.css">Minimalist</asp:ListItem>
            <asp:ListItem Value="OnlyNumber.css">OnlyNumber</asp:ListItem>
        </asp:DropDownList>
    </div>
    </fieldset>
