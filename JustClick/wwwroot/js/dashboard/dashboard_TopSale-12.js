

function topsale12() {

  $.ajax(
    {
      url: "/Admin/Dashboard/GetTopSalenewMTD/",
      datatype: "json",
      success: (function (data1) {
        var row1 = "";

        if (data1.data.length > 0) {

          row1 += '<tr><td><i class=" text-yellow fa fa-trophy fa-2x"></i> </i></td>'

          row1 += ' <td>   <div class="avatar-group">';
          for (i = 0; i < data1.data.length; i++) {
            row1 += '  <a href="/Admin/Dashboard/Profile/' + data1.data[i].Id + '"  class="avatar avatar-xl"  > <img src="/img/Users/' + data1.data[i].tsr_picture + '" class="rounded-circle">  </a> ';
          }
          row1 += '</div></td>';

          row1 += '<td>';

          for (i = 0; i < data1.data.length; i++) {

            if (i > 0) {
              row1 += '<h5 class="card-title text-uppercase text-muted mb-0"> / ' + data1.data[i].tsr + '</h5>	';
            }
            else {
              row1 += '<h5 class="card-title text-uppercase text-muted mb-0"> ' + data1.data[i].tsr + '</h5>	';
            }
          }
          row1 += '</td>';

          row1 += '<td class="h1  text-blue  font-weight-bold mb-0">' + data1.data[0].sales + '</td></tr>';

        }

        else {
        }
       
     


      //////////////

        $.ajax(
          {
            url: "/Admin/Dashboard/GetsecondSalenewMTD/",
            datatype: "json",
            success: (function (data2) {
              //var row1 = "";

              if (data2.data.length > 0) {

                row1 += '<td><i class="text-gray fa fa-trophy fa-1x"></i> </i></td>'

                row1 += ' <td>   <div class="avatar-group">';
                for (i = 0; i < data2.data.length; i++) {
                  row1 += '  <a href="/Admin/Dashboard/Profile/' + data2.data[i].Id + '"  class="avatar avatar-xl"  > <img src="/img/Users/' + data2.data[i].tsr_picture + '" class="rounded-circle">  </a> ';
                }
                row1 += '</div></td>';

                row1 += '<td>';

                for (i = 0; i < data2.data.length; i++) {

                  if (i > 0) {
                    row1 += '<h5 class="card-title text-uppercase text-muted mb-0"> / ' + data2.data[i].tsr + '</h5>	';
                  }
                  else {
                    row1 += '<h5 class="card-title text-uppercase text-muted mb-0"> ' + data2.data[i].tsr + '</h5>	';
                  }
                }
                row1 += '</td>';

                row1 += '<td class="h1  text-blue  font-weight-bold mb-0">' + data2.data[0].sales + '</td></tr>';

              }

              else {
              }

              //$("#PID").html(row1);


            })




          });


      ////////////
        $("#topsale12").html(row1);
      })


    });


}
