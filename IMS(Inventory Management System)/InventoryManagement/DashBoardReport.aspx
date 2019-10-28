<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DashBoardReport.aspx.cs" Inherits="DashBoardReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-3.4.1.js"></script>
    <script src="Scripts/metro.js"></script>
    <link href="Content/metro.css" rel="stylesheet" />
    <link href="Content/metro-icons.css" rel="stylesheet" />
    <link href="Content/metro-all.css" rel="stylesheet" />
    <link href="Content/metro-colors.css" rel="stylesheet" />


<script src="https://code.highcharts.com/highcharts.js"></script>
<script src="https://code.highcharts.com/modules/exporting.js"></script>
<script src="https://code.highcharts.com/modules/export-data.js"></script>

  <script src="https://code.jquery.com/jquery-3.1.1.min.js"></script>
<script src="https://code.highcharts.com/highcharts.js"></script>
<script src="https://code.highcharts.com/highcharts-more.js"></script>
<script src="https://code.highcharts.com/modules/exporting.js"></script>

<style>
    #container2{
        min-width:320px;
        max-width:600px;
        margin:0 auto;
    }

    #container3{
    height: 300px;
	min-width: 310px;
	max-width: 800px;
    margin: 0 auto;
    }
</style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div class="float-left"> 
                <div>
                    <div id="container" class="bg-white p-6 mx-auto border bd-default win-shadow cell mt-4 ml-8-xl">
                </div>
                </div>     
            </div>

          
            <div class="float-right">
                <div>
                    <div id="container1" class="bg-white p-6 mx-auto border bd-default win-shadow cell mt-4 ml-8-xl">

                </div>
                </div>
                
            </div>

        </div>

        <div class="row">
            <div id="container2" class="float-left bg-white p-6 mx-auto border bd-default win-shadow cell mt-4 ml-8-xl">

            </div>
            <div id="container3" class=" flot-right bg-white p-6 mx-auto border bd-default win-shadow cell mt-4 ml-8-xl" >


            </div>

        </div>
       
        <script>
    Highcharts.chart('container', {
    chart: {
        type: 'line'
    },
    title: {
        text: 'Monthly Average Orders'
    },
    subtitle: {
        text: 'Per Component'
    },
    xAxis: {
        categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']
    },
    yAxis: {
        title: {
            text: 'Quantity'
        }
    },
    plotOptions: {
        line: {
            dataLabels: {
                enabled: true
            },
            enableMouseTracking: false
        }
    },
    series: [{
        name: 'Satisfy orders',
        data: [7.0, 6.9, 9.5, 14.5, 18.4, 21.5, 25.2, 26.5, 23.3, 18.3, 13.9, 9.6]
    }, {
        name: 'Cancel orders',
        data: [3.9, 4.2, 5.7, 8.5, 11.9, 15.2, 17.0, 16.6, 14.2, 10.3, 6.6, 4.8]
    }]
            });

 //Build the Pie Chart
            // Radialize the colors
Highcharts.setOptions({
    colors: Highcharts.map(Highcharts.getOptions().colors, function (color) {
        return {
            radialGradient: {
                cx: 0.5,
                cy: 0.3,
                r: 0.7
            },
            stops: [
                [0, color],
                [1, Highcharts.Color(color).brighten(-0.3).get('rgb')] // darken
            ]
        };
    })
});

// Build the chart
Highcharts.chart('container1', {
    chart: {
        plotBackgroundColor: null,
        plotBorderWidth: null,
        plotShadow: false,
        type: 'pie'
    },
    title: {
        text: 'Most Popular Component'
    },
    tooltip: {
        pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
    },
    plotOptions: {
        pie: {
            allowPointSelect: true,
            cursor: 'pointer',
            dataLabels: {
                enabled: true,
                format: '<b>{point.name}</b>: {point.percentage:.1f} %',
                connectorColor: 'silver'
            }
        }
    },
    series: [{
        name: 'Share',
        data: [
            { name: 'Chrome', y: 61.41 },
            { name: 'Internet Explorer', y: 11.84 },
            { name: 'Firefox', y: 10.85 },
            { name: 'Edge', y: 4.67 },
            { name: 'Safari', y: 4.18 },
            { name: 'Other', y: 7.05 }
        ]
    }]
            });


//Build LinterCharts
            var chart = Highcharts.chart('container2', {

    title: {
        text: 'Stock Levels'
    },

    subtitle: {
        text: ''
    },

    xAxis: {
        categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']
    },

    series: [{
        type: 'column',
        colorByPoint: true,
        data: [29.9, 71.5, 106.4, 129.2, 144.0, 176.0, 135.6, 148.5, 216.4, 194.1, 95.6, 54.4],
        showInLegend: false
    }]

});

$('#inverted').click(function () {
    chart.update({
        chart: {
            inverted: true,
            polar: false
        },
        subtitle: {
            text: 'Inverted'
        }
    });
});

$('#polar').click(function () {
    chart.update({
        chart: {
            inverted: false,
            polar: true
        },
        subtitle: {
            text: 'Polar'
        }
    });
            });


//Responsive Chart
            var chart = Highcharts.chart('container3', {

    chart: {
        type: 'column'
    },

    title: {
        text: 'View Most Ordered Components'
    },

    subtitle: {
        text: 'Component or Components that are most order by clients'
    },

    legend: {
        align: 'right',
        verticalAlign: 'middle',
        layout: 'vertical'
    },

    xAxis: {
        categories: ['Apples', 'Oranges', 'Bananas'],
        labels: {
            x: -10
        }
    },

    yAxis: {
        allowDecimals: false,
        title: {
            text: 'Amount'
        }
    },

    series: [{
        name: 'Christmas Eve',
        data: [1, 4, 3]
    }, {
        name: 'Christmas Day before dinner',
        data: [6, 4, 2]
    }, {
        name: 'Christmas Day after dinner',
        data: [8, 4, 3]
    }],

    responsive: {
        rules: [{
            condition: {
                maxWidth: 500
            },
            chartOptions: {
                legend: {
                    align: 'center',
                    verticalAlign: 'bottom',
                    layout: 'horizontal'
                },
                yAxis: {
                    labels: {
                        align: 'left',
                        x: 0,
                        y: -5
                    },
                    title: {
                        text: null
                    }
                },
                subtitle: {
                    text: null
                },
                credits: {
                    enabled: false
                }
            }
        }]
    }
});

document.getElementById('small').addEventListener('click', function () {
    chart.setSize(400);
});

document.getElementById('large').addEventListener('click', function () {
    chart.setSize(600);
});

document.getElementById('auto').addEventListener('click', function () {
    chart.setSize(null);
});


        </script>
    </form>
</body>
</html>
