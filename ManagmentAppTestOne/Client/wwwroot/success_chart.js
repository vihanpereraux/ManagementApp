function SuccessChart(total, state)
{
    am4core.useTheme(am4themes_animated);

    var chart = am4core.create("chartdiv3", am4charts.PieChart);

    // Add data
    chart.data = [{
        "category": "Other",
        "litres": (total - state) / total * 100,
        "color": "#e3e3e3"
    }, {
        "category": "Successful",
        "litres": state / total * 100,
        "color": "#d9ccfc"
    }
    ];

    // Add and configure Series
    var pieSeries = chart.series.push(new am4charts.PieSeries());
    pieSeries.dataFields.value = "litres";
    pieSeries.slices.template.strokeWidth = 2;
    pieSeries.slices.template.propertyFields.fill = "color";
    pieSeries.slices.template.stroke = am4core.color("#fff");
    pieSeries.slices.template.strokeOpacity = 1;
    pieSeries.labels.template.disabled = false;

    // This creates initial animation
    pieSeries.hiddenState.properties.opacity = 1;
    pieSeries.hiddenState.properties.endAngle = -90;
    pieSeries.hiddenState.properties.startAngle = -90;

    chart.hiddenState.properties.radius = am4core.percent(0);

    am4core.addLicense("ch-custom-attribution");
}



