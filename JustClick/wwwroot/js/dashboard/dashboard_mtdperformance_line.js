function mtdperformance() {


  $.ajax({
    url: "/Admin/Dashboard/GetmtdPerformance/",
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
      var ctx = document.getElementById('mtd');
      var myChart = new Chart(ctx, {
        type: 'bar',
        data: {
          labels: chartlabel// ['Today-6', 'Today-5', 'Today-4', 'Today-3', 'Today-2', 'Today-1', 'Today'] // [chartlabel]
          ,
          datasets: [{
       
    
            label: 'sale submit ' + totalsale,
            data: chartdata1,
            backgroundColor: '#3bc0f5',
            borderColor: '#3bc0f5',

            //fill: false,
            //borderDash: [5, 5],
            //pointRadius: 5,
            //pointHoverRadius: 10,
          },
            {
              label: 'Approved ' + totalapproved,
              data: chartdata2,
              backgroundColor: '#25f75d',
              borderColor: '#25f75d',
              //fill: false,
              //borderDash: [5, 5],
              //pointRadius: 5,
              //pointHoverRadius: 10,
            }
            ,
            {
              label: 'Not Approved ' + totalnotapproved,
              data: chartdata3,
              backgroundColor: '#ff5e9c',
              borderColor: '#ff5e9c',
              //fill: false,
              //borderDash: [5, 5],
              //pointRadius: 5,
              //pointHoverRadius: 10,
            }

          ]
        },
        options: {


          responsive: true,

          legend: {
            position: 'bottom',
            labels: {
              fontColor: '#ffffff' //set your desired color
            }
       
          },

          hover: {
            mode: 'index'
          },
          scales: {
            xAxes: [{
              barThickness:20,
              stacked: false,
              display: true,
              scaleLabel: {
                display: true,
                labelString: 'tsr',           
                fontColor: '#ffffff',

            
              },
              ticks: {
                fontColor: "white",
                fontSize:12
              }

            }],
            yAxes: [{
              stacked: false,
              display: true,
              scaleLabel: {
                display: true,
                labelString: '',
                fontColor: '#ffffff',
                
              },
              ticks: {
                fontColor: "white",
                fontSize: 12
              }

            }]
          },
          title: {
            display: false,
            text: ''
          }
        }

      });

    })

  });



};
