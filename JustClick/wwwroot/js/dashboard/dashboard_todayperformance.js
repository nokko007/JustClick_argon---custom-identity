function todayperformance() {


  $.ajax({
    url: "/Admin/Dashboard/Getdailysalebytsr/",
    datatype: "json",
    success: (function (data) {
      //debugger;
      var chartlabel = [];
      var chartdata1 = [];
      var chartdata2 = [];
      var chartdata3 = [];
      var totalsales = 0;
      var totalnewsales = 0;
      var totalrenewsales = 0;

      for (var i = 0; i< data.data.length; i++) {
        chartlabel.push(data.data[i].tsr_loginname);
        
        chartdata1.push(Number(data.data[i].newsales.replace(",", "")));
        chartdata2.push(Number(data.data[i].renewsales.replace(",", "")));
        chartdata3.push(Number(data.data[i].sales.replace(",", "")));


        totalsales = totalsales + Number(data.data[i].sales.replace(",", "")); 
        totalnewsales = totalnewsales + Number(data.data[i].newsales.replace(",", ""));
        totalrenewsales = totalrenewsales + Number(data.data[i].renewsales.replace(",", ""));
        }

      //totalnewsales = System.out.format("%,8d%n", totalnewsales);



    
      

      //totalsales = 'Total Premium ' + totalsales;

      //debugger;
      var ctx = document.getElementById('todaychart');
      var myChart = new Chart(ctx, {
        type: 'line',
        data: {
          labels: chartlabel
          ,
          datasets: [
            
          {
            label: 'New : ' + totalnewsales.toLocaleString("en-EN"),
            data: chartdata1,
            backgroundColor: '#ff5e9c',
            borderColor: '#ff5e9c',
            fill: false,
            borderDash: [15, 5],
            pointRadius: 5, 
            pointHoverRadius: 10,
          }
            ,
          {
            label: 'Renew : ' + totalrenewsales.toLocaleString("en-EN"),
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
            },
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
