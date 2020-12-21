

function dailysalebytsr() {

  $.ajax(
    {
      url: "/Admin/Dashboard/Getdailysalebytsr/",
      datatype: "json",
      success: (function (data1) {
        var row1 = "";

        for (i = 0; i < data1.data.length; i++) {
          var sales = 0;
          var newsales = 0;
          var renewsales = 0;

          sales = + data1.data[i].sales.replace(",", "");
          newsales = + data1.data[i].sales.replace(",", "");
          renewsales = + data1.data[i].renewsales.replace(",", "");

          row1 += '<tr> <td> <span class="avatar avatar-sm rounded-circle">  <a href = "/Admin/Dashboard/Profile/' + data1.data[i].Id + '" > <img src="/img/Users/' + data1.data[i].tsr_picture + '">  </a> </span> </td>';
          row1 += '<td>' + data1.data[i].tsr + '</td>';
          row1 += '<td>' + sales + '</td>';
          row1 += '<td>' + newsales + '</td>';
          row1 += '<td>' + renewsales + '</td>';
          if (data1.data[i].bounce == "UP") {
            row1 += '<td> <i class="fas fa-arrow-up text-success mr-3"></i></td></tr>'
          }
          else { row1 += '<td><i class="fas fa-arrow-down text-warning mr-3"></i></td></tr>' }
        }
        $("#PID").html(row1);


      })

    });
}
