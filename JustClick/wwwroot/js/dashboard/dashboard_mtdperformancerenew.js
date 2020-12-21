function mtdperformancerenew() {


  $.ajax({
    url: "/Admin/Dashboard/GetmtdPerformancerenew/",
    datatype: "json",
    success: (function (data) {
      //debugger;
      var chartlabel = [];
      var chartdata1 = [];
      var chartdata2 = [];
      var chartdata3 = [];
      var totalsale = 0;
      var totalapproved = 0;
      var totalnotapproved = 0;

      for (var i = 0; i< data.data.length; i++) {
        chartlabel.push(data.data[i].tsr);
        chartdata1.push(data.data[i].salesubmit);
        chartdata2.push(data.data[i].approved);
        chartdata3.push(data.data[i].notapproved);


        totalsale = totalsale + data.data[i].salesubmit;
        totalapproved = totalapproved + data.data[i].approved;
        totalnotapproved = totalnotapproved + data.data[i].notapproved;
        }

      //totalnewsales = System.out.format("%,8d%n", totalnewsales);



    
      

      //totalsales = 'Total Premium ' + totalsales;

      //debugger;
      var ctx = document.getElementById('mtdrenew');
      var myChart = new Chart(ctx, {
        type: 'line',
        data: {
          labels: chartlabel
          ,
          datasets: [{


            label: 'Sale submit: ' + totalsale.toLocaleString("en-EN"),
            data: chartdata1,
            backgroundColor: '#3bc0f5',
            borderColor: '#3bc0f5',

            fill: false,
            borderDash: [15, 5],
            pointRadius: 5,
            pointHoverRadius: 10,
          },
          {
            label: 'Approved: ' + totalapproved.toLocaleString("en-EN"),
            data: chartdata2,
            backgroundColor: '#25f75d',
            borderColor: '#25f75d',
            fill: false,
            borderDash: [15, 5],
            pointRadius: 5,
            pointHoverRadius: 10,
          }
            ,
          {
            label: 'Not Approved: ' + totalnotapproved.toLocaleString("en-EN"),
            data: chartdata3,
            backgroundColor: '#ff5e9c',
            borderColor: '#ff5e9c',
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
                var yLabel = item.yLabel.toLocaleString("en-EN"); ;
                var n = label.indexOf(":");
                var res = label.substring(0, n - 1);

                var content = '';

                if (data.datasets.length > 1) {
                  content += '<span class="popover-body-label mr-auto">' + res + '</span> ';
                }

                content += ' <span class="popover-body-value"> '  + yLabel  + '</span>';

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
        //      barThickness:16,
        //      stacked: true,
        //      display: true,
        //      scaleLabel: {
        //        display: true,
        //        labelString: 'tsr',           
        //        fontColor: '#ffffff',

            
        //      },
        //      ticks: {
        //        fontColor: "white",
        //        fontSize:12
        //      }

        //    }],
        //    yAxes: [{
        //      stacked: true,
        //      display: true,
        //      scaleLabel: {
        //        display: true,
        //        labelString: '',
        //        fontColor: '#ffffff',
                
        //      },
        //      ticks: {
        //        fontColor: "white",
        //        fontSize: 12
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
