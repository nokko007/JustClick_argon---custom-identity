

function logoutagent() {

  $.ajax(
    {
      url: "/Admin/Dashboard/Getlogoutagent/",
      datatype: "json",
      success: (function (data1) {
        var row1 = "";

        for (i = 0; i < data1.data.length; i++) {

          if  (data1.data[i].tsr_picture == "") {
            row1 += '<tr> <th scope="row"> <span class="avatar avatar-sm rounded-circle">  <a href = "/Admin/Dashboard/Profile/' + data1.data[i].Id + '" > <img src="/img/Users/no-image.jpg">  </a> </span> </th>';

          }
          else {
        row1 += '<tr> <th scope="row"> <span class="avatar avatar-sm rounded-circle">  <a href = "/Admin/Dashboard/Profile/' + data1.data[i].Id + '" > <img src="/img/Users/' + data1.data[i].tsr_picture + '">  </a> </span> </th>';

          }

        row1 += '<td>' + data1.data[i].tsr + '</td>';
        row1 += '<td>' + data1.data[i].PROJECT + '</td>';
          row1 += '<td>' + data1.data[i].LASTLOGOUT + '</td></tr>';
 
        }
          $("#LASTLOGOUT").html(row1);


        })

    });
}
