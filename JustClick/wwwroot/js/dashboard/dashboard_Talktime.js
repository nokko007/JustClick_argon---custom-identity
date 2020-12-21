

function talktime() {


  //1
  $.ajax(
    {
      url: "/Admin/Dashboard/GetTalktime/",
      datatype: "json",
      success: (function (data1) {
        var row1 = "";
       
        if (data1.data.length > 0) {
         

          row1 += '                     <div class="row mb-0">';
          row1 += '                         <div class="col mb-0">';
          row1 += '                             <h5 class=" card-title text-uppercase text-muted mb-0">Talktime</h5>';
          row1 += '                             <h1 class=" text-green  font-weight-bold mb-0">Avg ' + data1.data[0].AVGCALL+ '</h1>';
          row1 += '                         </div>';
          row1 += '                        <div class="col-auto mb-0">';
          row1 += '                             <div class="h1 icon icon-shape bg-red text-white rounded-circle shadow mb-0">' + data1.data[0].NOTSR + '  </div> ';
          row1 += '                                  <div class="h5 text-center mb-0" > Tsr.</div > '
          row1 += '                             </div>';
          row1 += '                         </div>';
          row1 += '                     </div>';
          row1 += '                     <div class="row mb-0">';
          row1 += '                         <div class="col mb-0">';
          row1 += '                            <p class="h4  text-blue  font-weight-bold mb-0" > <span> Total '+ data1.data[0].SALECALL + '</span> </p> ';
          row1 += '                            <p class="h5  text-nowrap text-muted  mb-0" > <span>Max ' + data1.data[0].MAXCALL + '/Min ' + data1.data[0].MINCALL + '/Out ' + data1.data[0].OUTCALL; '</span> </p> ';
          row1 += '                     </div>'
          row1 += '                     </div>'
        }
        else {
          row1 += '                     <div class="row mb-0">';
          row1 += '                         <div class="col mb-0">';
          row1 += '                             <h5 class=" card-title text-uppercase text-muted mb-0">Talktime</h5>';
          row1 += '                             <h1 class=" text-green  font-weight-bold mb-0">Avg 0:00:00</h1>';
          row1 += '                         </div>';
          row1 += '                        <div class="col-auto mb-0">';
          row1 += '                             <div class="h1 icon icon-shape bg-red text-white rounded-circle shadow mb-0">-  </div> ';
          row1 += '                                  <div class="h5 text-center mb-0" > Tsr.</div > '
          row1 += '                             </div>';
          row1 += '                         </div>';
          row1 += '                     </div>';
          row1 += '                     <div class="row mb-0">';
          row1 += '                         <div class="col mb-0">';
          row1 += '                            <p class="h4  text-blue  font-weight-bold mb-0" > <span> Total 0:00:00</span> </p> ';
          row1 += '                            <p class="h5  text-nowrap text-muted   mb-0" > <span>Max 0:00:00/Min 0:00:00/Out 0:00:00</span> </p> ';
          row1 += '                     </div>'
          row1 += '                     </div>'


        }


        $("#TALKTIME").html(row1);
      })
    });
 
}
