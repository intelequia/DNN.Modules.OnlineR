<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Edit.ascx.cs" Inherits="Christoc.Modules.OnlineR.Edit" %>
<script type="text/javascript" src="https://www.google.com/jsapi"></script>
<h2 id="dnnSitePanel-onlineUsersData" class="dnnFormSectionHead">OnlineR Statistics</h2>

<fieldset id="onlinerMaxUsers">
    <p id="nusers">Maximum number of users</p>
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
 <script type="text/javascript">
     var json = <%=json %>       // Load the json from the server side
     google.load('visualization', '1.1', { packages: ['line'] });
     google.setOnLoadCallback(drawChart);

     function drawChart() {
         var data = new google.visualization.DataTable();
         data.addColumn('datetime', 'Day hours');
         data.addColumn('number', 'Online Users Today');

         for (var i = 0; i < json.length; i++) {
             var arrayaux = [new Date(json[i].RegDate), parseInt(json[i].RegOnline)]; // Store the data from the json in a auxiliar array
             data.addRow(arrayaux); // Add the row to the chart data
         }
         var options = {
             timeline: {
                groupByRowLabel: true
             },
             chart: {
                title: 'Graphical user traffic on the present day',
                subtitle: 'Indicates the number of users online every 5 minutes.'
            },
         };

     var chart = new google.charts.Line(document.getElementById("chart_div"));
     chart.draw(data, options);
     }
</script>
    <div id="chart_div"></div>
</fieldset>