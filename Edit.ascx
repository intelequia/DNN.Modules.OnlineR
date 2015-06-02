<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Edit.ascx.cs" Inherits="Christoc.Modules.OnlineR.Edit" %>
<script type="text/javascript" src="https://www.google.com/jsapi"></script>
<h2 id="dnnSitePanel-onlineUsersData" class="dnnFormSectionHead">OnlineR Statistics</h2>

<fieldset id="onlinerMaxUsers">
    <p class="nusers">Maximum number of users</p>
    <div class="dnnFormItem">
        <div>This year: <span><%=maxUsersYear %></span></div>
    </div>
    <div class="dnnFormItem">
        <div>This month: <span><%=maxUsersMonth %></span></div>
    </div>
    <div class="dnnFormItem">
        <div>This week: <span><%=maxUsersWeek %></span></div>
    </div>
</fieldset>

<fieldset>
   <div id="dashboard_div">
            <p id="graph" class="nusers"> This Year Statistics</p>
            <div id="chart_div"></div>
            <div id="filter_div"></div>
    </div>
</fieldset>
 

<script type="text/javascript">
    var json = <%=json %>       // Load the json from the server side

    // ================================================================================================= //
    // Google chart creation
    // ================================================================================================= //
    google.load('visualization', '1.1', { packages: ['controls'] });
    google.setOnLoadCallback(drawDashboard);
    function drawDashboard() {
        // Create the data table
        var data = new google.visualization.DataTable();
        data.addColumn('datetime', 'Date');
        data.addColumn('number', 'Online users');

        for (var i = 0; i < json.length; i++) {
            var arrayaux = [new Date(json[i].RegDate), parseInt(json[i].RegOnline)]; // Store the data from the json in a auxiliar array
            data.addRow(arrayaux); // Add the row to the table
        }
        // Create the dashboard
        var dashboard = new google.visualization.Dashboard(
        document.getElementById('dashboard_div'));

        //Create a range slider
        var regRangeSlider = new google.visualization.ControlWrapper({
            'controlType': 'ChartRangeFilter',
            'containerId': 'filter_div',
            'options': {
                'filterColumnLabel': 'Date',
                'height': '200',
                'ui': {
                    'minRangeSize': 3600000
                }
            }
        });
        //Create a wrapper for the elements
        var regChart = new google.visualization.ChartWrapper({
            'chartType': 'Line',
            'containerId': 'chart_div',
            'options': {
                'legend': {
                    'position': 'none'
                }

            }
        });
        // Bind the filter to the chart and draw the data
        dashboard.bind(regRangeSlider, regChart)
        dashboard.draw(data);

    }
</script>