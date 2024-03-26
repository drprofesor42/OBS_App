'use strict';

$(document).ready(function () {

// Line chart
if ($('#apexcharts-area').length > 0) {
    var options = {
        chart: {
            height: 350,
            type: "line",
            toolbar: {
                show: false
            },
        },
        dataLabels: {
            enabled: false
        },
        stroke: {
            curve: "smooth"
        },
        series: [{
            name: "Teachers",
            color: '#3D5EE1',
            data: [45, 60, 75, 51, 42, 42, 30]
        }, {
            name: "Students",
            color: '#70C4CF',
            data: [24, 48, 56, 32, 34, 52, 25]
        }],
        xaxis: {
            categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul'],
        }
    }
    var chart = new ApexCharts(
        document.querySelector("#apexcharts-area"),
        options
    );
    chart.render();
}

// Area chart
if ($('#school-area').length > 0) {
    var options = {
        chart: {
            height: 350,
            type: "area",
            toolbar: {
                show: false
            },
        },
        dataLabels: {
            enabled: false
        },
        stroke: {
            curve: "straight"
        },
        series: [{
            name: "Teachers",
            color: '#3D5EE1',
            data: [45, 60, 75, 51, 42, 42, 30]
        }, {
            name: "Students",
            color: '#70C4CF',
            data: [24, 48, 56, 32, 34, 52, 25]
        }],
        xaxis: {
            categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul'],
        }
    }
    var chart = new ApexCharts(
        document.querySelector("#school-area"),
        options
    );
    chart.render();
}

// Bar chart
if ($('#admin_bar').length > 0) {
    $.ajax({
        type: 'POST',
        url: '/Admin/Admin/Data', // Controller ve Action adý
        contentType: 'application/json',
        dataType: 'json',
        data: JSON.stringify({}),
        success: function (data) {
            // Veri baþarýyla alýndýktan sonra chart'ý güncelle
            chartBar.updateSeries([
                {
                    name: "Erkekler",
                    data: data.maleData
                },
                {
                    name: "Kadinlar",
                    data: data.femaleData
                }
            ]);
        },
        error: function (error) {
            console.log(error);
        }
    });

    var optionsBar = {
        chart: {
            type: 'bar',
            height: 350,
            width: '100%',
            stacked: false,
            toolbar: {
                show: false
            },
        },
        dataLabels: {
            enabled: false
        },
        plotOptions: {
            bar: {
                columnWidth: '55%',
                endingShape: 'rounded'
            },
        },
        stroke: {
            show: true,
            width: 2,
            colors: ['transparent']
        },
        series: [
            {
                name: "Erkekler",
                color: '#005ABC',
                data: [] // Boþ dizi olarak baþlatýlýyor
            },
            {
                name: "Kadinlar",
                color: '#DA009A',
                data: [] // Boþ dizi olarak baþlatýlýyor
            }
        ],
        labels: ["Cinsiyet"],
        xaxis: {
            labels: {
                show: false
            },
            axisBorder: {
                show: false
            },
            axisTicks: {
                show: false
            },
        },
        yaxis: {
            axisBorder: {
                show: false
            },
            axisTicks: {
                show: false
            },
            labels: {
                style: {
                    colors: '#777'
                }
            }
        },
        title: {
            text: '',
            align: 'left',
            style: {
                fontSize: '18px'
            }
        }
    };

    var chartBar = new ApexCharts(document.querySelector('#admin_bar'), optionsBar);
    chartBar.render();
}


// Simple Line
if ($('#s-line').length > 0) {
        var sline = {
            chart: {
                height: 350,
                type: 'line',
                zoom: {
                    enabled: false
                },
                toolbar: {
                    show: false,
                }
            },
            // colors: ['#4361ee'],
            dataLabels: {
                enabled: false
            },
            stroke: {
                curve: 'straight'
            },
            series: [{
                name: "Desktops",
                data: [10, 41, 35, 51, 49, 62, 69, 91, 148]
            }],
            title: {
                text: 'Product Trends by Month',
                align: 'left'
            },
            grid: {
                row: {
                    colors: ['#f1f2f3', 'transparent'], // takes an array which will be repeated on columns
                    opacity: 0.5
                },
            },
            xaxis: {
                categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep'],
            }
        }

        var chart = new ApexCharts(
            document.querySelector("#s-line"),
            sline
        );

        chart.render();
    }

});

// Simple Line Area
if ($('#s-line-area').length > 0) {
    var sLineArea = {
        chart: {
            height: 350,
            type: 'area',
            toolbar: {
                show: false,
            }
        },
        // colors: ['#4361ee', '#888ea8'],
        dataLabels: {
            enabled: false
        },
        stroke: {
            curve: 'smooth'
        },
        series: [{
            name: 'series1',
            data: [31, 40, 28, 51, 42, 109, 100]
        }, {
            name: 'series2',
            data: [11, 32, 45, 32, 34, 52, 41]
        }],

        xaxis: {
            type: 'datetime',
            categories: ["2018-09-19T00:00:00", "2018-09-19T01:30:00", "2018-09-19T02:30:00", "2018-09-19T03:30:00", "2018-09-19T04:30:00", "2018-09-19T05:30:00", "2018-09-19T06:30:00"],
        },
        tooltip: {
            x: {
                format: 'dd/MM/yy HH:mm'
            },
        }
    }

    var chart = new ApexCharts(
        document.querySelector("#s-line-area"),
        sLineArea
    );

    chart.render();
}

// Simple Column
if ($('#s-col').length > 0) {
    var sCol = {
        chart: {
            height: 350,
            type: 'bar',
            toolbar: {
                show: false,
            }
        },
        plotOptions: {
            bar: {
                horizontal: false,
                columnWidth: '55%',
                endingShape: 'rounded'
            },
        },
        // colors: ['#888ea8', '#4361ee'],
        dataLabels: {
            enabled: false
        },
        stroke: {
            show: true,
            width: 2,
            colors: ['transparent']
        },
        series: [{
            name: 'Net Profit',
            data: [44, 55, 57, 56, 61, 58, 63, 60, 66]
        }, {
            name: 'Revenue',
            data: [76, 85, 101, 98, 87, 105, 91, 114, 94]
        }],
        xaxis: {
            categories: ['Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct'],
        },
        yaxis: {
            title: {
                text: '$ (thousands)'
            }
        },
        fill: {
            opacity: 1

        },
        tooltip: {
            y: {
                formatter: function (val) {
                    return "$ " + val + " thousands"
                }
            }
        }
    }

    var chart = new ApexCharts(
        document.querySelector("#s-col"),
        sCol
    );

    chart.render();
}

// Simple Column Stacked
if ($('#s-col-stacked').length > 0) {
    $.ajax({
        type: "POST",
        url: "/Ogretmen/Ogretmen/DersBasarisi", // Ders baþarýsý hesaplayan methodun URL'si
        success: function (data) {
            if (data.length > 0) {
                var categories = [];
                var gecenOgrenciData = [];
                var kalanOgrenciData = [];

                // Verileri çýkartma
                data.forEach(function (ders) {
                    categories.push(ders.dersAdi);
                    gecenOgrenciData.push(ders.gecenOgrenciSayisi);
                    kalanOgrenciData.push(ders.kalanOgrenciSayisi);
                });

                console.log(gecenOgrenciData)

                var sColStacked = {
                    chart: {
                        height: 350,
                        type: 'bar',
                        stacked: true,
                        toolbar: {
                            show: false,
                        }
                    },
                    xaxis: {
                        categories: categories,
                    },
                    series: [{
                        name: 'Gecen Ogrenci',
                        color: '#6BBC00',
                        data: gecenOgrenciData
                    }, {
                        name: 'Kalan Ogrenci',
                        color: '#BC0000',
                        data: kalanOgrenciData
                    }],
                    plotOptions: {
                        bar: {
                            horizontal: false,
                        },
                    },
                    legend: {
                        position: 'right',
                        offsetY: 40
                    },
                    fill: {
                        opacity: 1
                    },
                };

                var chart = new ApexCharts(
                    document.querySelector("#s-col-stacked"),
                    sColStacked
                );

                chart.render();
            }
        }
    });
}

// Simple Bar
if ($('#s-bar').length > 0) {
    $.ajax({
        type: 'POST',
        url: '/Admin/Admin/Data', // Controller ve Action adý
        contentType: 'application/json',
        dataType: 'json',
        data: JSON.stringify({}),
        success: function (data) {
            // Veri baþarýyla alýndýktan sonra chart'ý güncelle
            var categories = [];
            var seriesData = [];
            data.bolumOgrenciSayilari.forEach(function (item) {
                categories.push(item.bolumAd);
                seriesData.push(item.ogrenciSayisi);
            });
            chartBar.updateOptions({
                xaxis: {
                    categories: categories
                }
            });
            chartBar.updateSeries([{
                name: "Ogrenci Sayisi",
                data: seriesData
            }]);
        },
        error: function (error) {
            console.log(error);
        }
    });

    var chartBar = new ApexCharts(
        document.querySelector("#s-bar"),
        {
            chart: {
                height: 350,
                type: 'bar',
                toolbar: {
                    show: false,
                }
            },
            plotOptions: {
                bar: {
                    horizontal: true,
                }
            },
            dataLabels: {
                enabled: false
            },
            xaxis: {
                categories: [],
            },
            series: [{
                name: "Ogrenci Sayisi",
                data: []
            }],
        }
    );

    chartBar.render();
}


// Mixed Chart
if ($('#mixed-chart').length > 0) {
    var options = {
        chart: {
            height: 350,
            type: 'line',
            toolbar: {
                show: false,
            }
        },
        // colors: ['#4361ee', '#888ea8'],
        series: [{
            name: 'Website Blog',
            type: 'column',
            data: [440, 505, 414, 671, 227, 413, 201, 352, 752, 320, 257, 160]
        }, {
            name: 'Social Media',
            type: 'line',
            data: [23, 42, 35, 27, 43, 22, 17, 31, 22, 22, 12, 16]
        }],
        stroke: {
            width: [0, 4]
        },
        title: {
            text: 'Traffic Sources'
        },
        labels: ['01 Jan 2001', '02 Jan 2001', '03 Jan 2001', '04 Jan 2001', '05 Jan 2001', '06 Jan 2001', '07 Jan 2001', '08 Jan 2001', '09 Jan 2001', '10 Jan 2001', '11 Jan 2001', '12 Jan 2001'],
        xaxis: {
            type: 'datetime'
        },
        yaxis: [{
            title: {
                text: 'Website Blog',
            },

        }, {
            opposite: true,
            title: {
                text: 'Social Media'
            }
        }]

    }

    var chart = new ApexCharts(
        document.querySelector("#mixed-chart"),
        options
    );

    chart.render();
}

// Donut Chart

if ($('#donut-chart').length > 0) {
    var donutChart = {
        chart: {
            height: 350,
            type: 'donut',
            toolbar: {
                show: false,
            }
        },
        // colors: ['#4361ee', '#888ea8', '#e3e4eb', '#d3d3d3'],
        series: [44, 55, 41, 17],
        responsive: [{
            breakpoint: 480,
            options: {
                chart: {
                    width: 200
                },
                legend: {
                    position: 'bottom'
                }
            }
        }]
    }

    var donut = new ApexCharts(
        document.querySelector("#donut-chart"),
        donutChart
    );

    donut.render();
}

if ($('#radial-chart').length > 0) {
    $.ajax({
        type: 'POST',
        url: '/Ogrenci/Ogrenci/Chart', // Controller ve Action adý
        contentType: 'application/json',
        dataType: 'json',
        data: JSON.stringify({}),
        success: function (data) {
            var radialChartOptions = {
                chart: {
                    height: 350,
                    type: 'radialBar',
                    toolbar: {
                        show: false,
                    }
                },
                plotOptions: {
                    radialBar: {
                        dataLabels: {
                            name: {
                                fontSize: '22px',
                            },
                            value: {
                                fontSize: '16px',
                            },
                            total: {
                                show: true,
                                label: 'Not Ortalamalari',
                                color: '#4361ee'
                            }
                        },
                        // Dilim üzerine gelindiðinde etiketlerin görünmesi
                        value: {
                            show: true
                        }
                    }
                },
                series: data.ortalamaNotlar,
                labels: data.dersler,
            };

            var radialChart = new ApexCharts(document.querySelector("#radial-chart"), radialChartOptions);
            radialChart.render();
        },
    });
}


