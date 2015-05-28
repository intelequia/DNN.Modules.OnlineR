<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="Christoc.Modules.OnlineR.View" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" %>
<%@ Import Namespace="DotNetNuke.Services.Localization" %>
<dnn:DnnJsInclude runat="server" FilePath="~/DesktopModules/OnlineR/Scripts/jquery.signalR-2.2.0.min.js" Priority="10" />
<dnn:DnnJsInclude runat="server" FilePath="/DesktopModules/OnlineR/Scripts/odometer.js" Priority="50" />
<dnn:DnnJsInclude runat="server" FilePath="~/signalr/hubs" Priority="100" />

<head>
    <title>SignalR Counter</title>
    <link rel="stylesheet" type="text/css" href="/DesktopModules/OnlineR/Odometer.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="/DesktopModules/OnlineR/Skins/<%=selectedSkin%>" media="screen" />
</head>

<body>
    <div class="innerwrapper">
        <div class="usericon grey">
            <img src="/DesktopModules/OnlineR/images/fa-user.png">
        </div>
        <h2 class="widget-title grey"><%=onlinerTitle%></h2>
        <div class="odometer odometer-theme-minimal fontgrey" id="counter"></div>
    </div>
    <script type="text/javascript">
        $(function () {
            var usr = $.connection.usersOnLine;
            usr.client.showUsersOnLine = function (data) {  
                // Change styles depend of the style selected
                if ('<%=this.selectedSkin %>' == 'Tile.css') {
                    if (data > 4) 
                        $('.innerwrapper').css("background-color", '<%=this.primaryColor %>');
                    else
                        $('.innerwrapper').css("background-color", "#BDBDBD");
                }
                else if ('<%=this.selectedSkin %>' == 'OnlyNumber.css') {
                    if (data > 4) 
                        $('.odometer').css("background-color", '<%=this.primaryColor %>');
                    else 
                        $('.odometer').css("background-color", "#BDBDBD");
                }
                else if ('<%=this.selectedSkin %>' == 'Social.css') {
                    if (data > 4) 
                        $('.usericon').css("background-color", '<%=this.primaryColor %>');
                    else 
                        $('.usericon').css("background-color", "#BDBDBD");
                }
                else
                {
                    if (data > 4) {
                        $('.usericon').css("background-color", '<%=this.primaryColor %>');
                        $('.widget-title').css("background-color", '<%=this.primaryColor %>');
                        $('.odometer').css("color", '<%=this.primaryColor %>');
                    }
                    else {
                            $('.usericon').css("background-color", "#BDBDBD");
                            $('.widget-title').css("background-color", "#BDBDBD");
                            $('.odometer').css("color", "#BDBDBD");
                    }
                }
                $('.odometer').html(data)
            };
            $.connection.hub.start(); // Starts the connection to the hub
        });
    </script>
</body>