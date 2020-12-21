function weeklysale() {


  $.ajax({
    url: "/Admin/Dashboard/Getweekly/",
    datatype: "json",
    success: (function (data) {
      //debugger;
      var chartlabel = [];
      var chartdata1 = [];
      var chartdata2 = [];
      var chartdata3 = [];
      var totalnewsales = 0;
      var totalrenewsales = 0;
      var totalsales = 0;

      for (var i = 0; i < 7; i++) {
        chartlabel.push(data.data[i].ddate);
        chartdata1.push(data.data[i].newsales);
        chartdata2.push(data.data[i].renewsales);
        chartdata3.push(data.data[i].totalsales);


        totalnewsales = totalnewsales + data.data[i].newsales;
        totalrenewsales = totalrenewsales + data.data[i].renewsales;
        totalsales = totalsales + data.data[i].totalsales;
        }

      //totalnewsales = System.out.format("%,8d%n", totalnewsales);



    
      

      //totalsales = 'Total Premium ' + totalsales;

      //debugger;
      var ctx = document.getElementById('myChart');
      var myChart = new Chart(ctx, {
        type: 'line',
        data: {
          labels: chartlabel// ['Today-6', 'Today-5', 'Today-4', 'Today-3', 'Today-2', 'Today-1', 'Today'] // [chartlabel]
          ,
          datasets: [{
            label: 'New : ' + totalnewsales.toLocaleString("en-EN"),
            data: chartdata1,
            backgroundColor: '#ff5e9c',
            borderColor: '#ff5e9c',
            fill: false,
            borderDash: [15, 5],
            pointRadius: 5,
            pointHoverRadius: 10,
          },
            {
              label: 'ReNew : ' + totalrenewsales.toLocaleString("en-EN"),
              data: chartdata2,
              backgroundColor: '#3bc0f5',
              borderColor: '#3bc0f5',
              fill: false,
              borderDash: [15, 5],
              pointRadius: 5,
              pointHoverRadius: 10,
            }
            ,
            {
              label: 'Total : ' + totalsales.toLocaleString("en-EN"),
              data: chartdata3,
              backgroundColor: '#25f75d',
              borderColor: '#25f75d',
              fill: false,
              borderDash: [15, 5],
              pointRadius: 5,
              pointHoverRadius: 10,
            }

          ]
        },

        options: {


          scales: {
            yAxes: [{
              ticks: {
                callback: function (value) {
                  if (!(value % 10)) {
                    return '฿' + value / 1000 + 'k'
                    //return value
                  }
                }
              }
            }]
          },
          tooltips: {
            callbacks: {
              label: function (item, data) {
                var label = data.datasets[item.datasetIndex].label || '';
                var yLabel = item.yLabel.toLocaleString("en-EN");;
                var n = label.indexOf(":");
                var res = label.substring(0, n - 1);

                var content = '';

                if (data.datasets.length > 1) {
                  content += '<span class="popover-body-label mr-auto">' + res + '</span> ';
                }

                content += ' <span class="popover-body-value"> ' + yLabel + '</span>';

                return content;
              }
            }
          }
        },
        //options: {
        //  responsive: true,
        //  legend: {
        //    position: 'bottom',
        //    labels: {
        //      fontColor: '#ffffff' //set your desired color
        //    }
       
        //  },

        //  hover: {
        //    mode: 'index'
        //  },
        //  scales: {
        //    xAxes: [{
        //      display: true,
        //      scaleLabel: {
        //        display: true,
        //        labelString: 'Day',           
        //        fontColor: '#ffffff'
        //      },
        //      ticks: {
        //        fontColor: "white"
        //      }

        //    }],
        //    yAxes: [{
        //      display: true,
        //      scaleLabel: {
        //        display: true,
        //        labelString: '',
        //        fontColor: '#ffffff'
        //      },
        //      ticks: {
        //        fontColor: "white"
        //      }

        //    }]
        //  },
        //  title: {
        //    display: false,
        //    text: ''
        //  }
        //}

      });

    })

  });



};
