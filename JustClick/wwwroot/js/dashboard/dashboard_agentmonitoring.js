

function agentmonitoring() {

  $.ajax(
    {
      url: "/Admin/Dashboard/Getagentmonitoring/",
      datatype: "json",
      success: (function (data1) {
        var row1 = "";

        for (i = 0; i < data1.data.length; i++) {

          var str = data1.data[i].SCREEN;

          if (str == "") {
            row1 += '<tr bgcolor="#e3e8e5">'
          }
          else {
            if (str.includes("Select", 0) > 0) {
              row1 += '<tr bgcolor="#ffffff">'
            }
            else if (str.includes("Success", 0) > 0) {
              row1 += '<tr bgcolor="#b5f0ff">'
            }
            else if (str.includes("SUCCESS", 0) > 0) {
              row1 += '<tr bgcolor="#b5f0ff">'
            }

            else if (str.includes("Inbound", 0) > 0) {
              row1 += '<tr bgcolor="#ffdcb5">'
            }
            else if (str.includes("รายงาน", 0) > 0) {
              row1 += '<tr bgcolor="#ffd4eb">'
            }
            else if (str.includes("Report", 0) > 0) {
              row1 += '<tr bgcolor="#ffd4eb">'
            }
            else if (str.includes("Re", 0) > 0) {
              row1 += '<tr bgcolor="#feffa6">'
            }
            else {
              row1 += '<tr bgcolor="#a1ffba">'
            }
          }
          row1 += '<td> <span class="avatar avatar-sm rounded-circle">  <a href="/Admin/Dashboard/Profile/' + data1.data[i].Id + '" > <img src="/img/Users/' + data1.data[i].tsr_picture + '">  </a> </span> </td>';
          row1 += '<td>' + data1.data[i].tsr + '</td>';
          row1 += '<td>' + data1.data[i].PROJECT + '</td>';
          row1 += '<td>' + data1.data[i].STARTCALLTIME + '</td>';
          row1 += '<td>' + data1.data[i].TALKTIME + '</td>';
          row1 += '<td>' + data1.data[i].SCREEN + '</td>';
          row1 += '<td>' + data1.data[i].CUSTOMER + '</td></tr>';


        }
        $("#MON").html(row1);


      })

    });
}
