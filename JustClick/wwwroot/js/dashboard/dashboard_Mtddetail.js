

function mtddetail() {


  //1
  $.ajax(
    {
      url: "/Admin/Dashboard/Getmtddetail/",
      datatype: "json",
      success: (function (data1) {
        var row1 = "";
       
        if (data1.data.length > 0) {
      

          row1 += '                     <div class="row mb-0">';
          row1 += '                         <div class="col mb-0">';
          row1 += '                             <h5 class=" card-title text-uppercase text-muted mb-0"> Cut Sale</h5>';
          row1 += '                             <h1 class=" text-green  font-weight-bold mb-0">' + data1.data[0].MONTHLABEL + '</h1>';
          row1 += '                         </div>';
          row1 += '                         <div class="col-auto mb-0">';
          row1 += '                             <div class="h1 icon icon-shape bg-blue text-white rounded-circle shadow mb-0">' + data1.data[0].WORKINGDAY + '  </div> ';
          row1 += '                                  <div class="h5 text-center mb-0" > Days</div > '
          row1 += '                             </div>';
          row1 += '                         </div>';
          row1 += '                     </div>';
          row1 += '                     <div class="row mb-0">';
          row1 += '                         <div class="col-auto  mb-0">';
          row1 += '                            <p class="h4  text-blue  font-weight-bold mb-0" > <span>' + data1.data[0].STARTDATE + ' - ' + data1.data[0].ENDDATE  + '</span> </p> ';
          row1 += '                            <p class="h5  text-white  font-weight-bold mb-0" > <span>-</span></p>  ';
          row1 += '                         </div>';                     
          row1 += '                     </div>';


        }
        else {
          row1 += '	            <div class="col">	';
          row1 += '	                    <div class="row">	';
          row1 += '<div class="col">';

          row1 += '<span class="h1  text-green  font-weight-bold mb-0">-</span>  ';
          row1 += '</div>';
          row1 += '	                    </div>	';
          row1 += '	                    <div class="row">	';
          row1 += '	                <div class="col">	';
          row1 += '	                        <p class="mt-3 mb-0 text-muted text-sm">	';
          row1 += '	                             <span class="h3 text-blue   mb-0" text-nowrap"> - to - </span>';
          row1 += '	                        </p>	';
          row1 += '	                    </div>	';
          row1 += '	                    </div>	';
          row1 += '	                </div>	';
          row1 += '	                <div class="col-auto">	';
          row1 += '<div class=" h1  icon icon-shape bg-info text-white rounded-circle shadow">';
          row1 += '-'
          row1 += '</div> <div class=" h5 text-center">Working</div>';
          row1 += ' <div class="h5 text-center">days</div>';
          row1 += '	                </div>	';


        }


        $("#MTDDETAIL").html(row1);
      })
    });
 
}
