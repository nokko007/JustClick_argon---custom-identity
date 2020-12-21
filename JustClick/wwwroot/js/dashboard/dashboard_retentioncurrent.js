

function retentioncurrent() {


  //1
  $.ajax(
    {
      url: "/Admin/Dashboard/Getretentioncurrent/",
      datatype: "json",
      success: (function (data1) {
        var row1 = "";
        var totalload = 0;
        var totalload_premium = 0;
        var totalsuccess = 0;
        var totalsuccess_premium = 0;

        var retention = 0;
      


        if (data1.data.length > 0) {


          totalload = data1.data[0].LOADED;
          totalload_premium = data1.data[0].LOADED_PREMIUM;
          totalsuccess = data1.data[0].SUCCESS;
          totalsuccess_premium = data1.data[0].SUCCESS_PREMIUM;


          retention = data1.data[0].RETENTIONPERCENT;
       



          row1 += '                     <div class="row mb-0">';
          row1 += '                         <div class="col mb-0">';
          row1 += '                             <h5 class=" card-title text-uppercase text-muted mb-0">Retention</h5>';
          row1 += '                             <h1 class=" text-green  font-weight-bold mb-0">' + data1.data[0].SOURCE + '</h1>';
          row1 += '                         </div>';
          row1 += '                         <div class="col-auto mb-0">';
          row1 += '                             <div class="h1 icon icon-shape bg-yellow text-white rounded-circle shadow mb-0">' + retention;
          row1 += '                                  <span class="h5 text-white mb-0" >%</span>  ';
          row1 += '                             </div>';
          row1 += '                         </div>';
          row1 += '                     </div>';
          row1 += '                     <div class="row mb-0">';
          row1 += '                         <div class="col mb-0">';
          row1 += '                            <p class="h4  text-blue  font-weight-bold mb-0" > <span> App: ' + totalload.toLocaleString("en-EN") + '</span> / <span class="h3  text-green  font-weight-bold mb-0" > ' + totalsuccess.toLocaleString("en-EN") + '</span> </p> ';
          row1 += '                            <p class="h4  text-blue  font-weight-bold mb-0" > <span> ฿: ' + totalload_premium.toLocaleString("en-EN") + ' </span >/ <span class="h3  text-green  font-weight-bold mb-0" >  ' + totalsuccess_premium.toLocaleString("en-EN") + '</span></p>  ';
          row1 += '                     </div>'
          row1 += '                     </div>'
          ///////////////////////////////////////////////////


        }
        else {


          row1 += ' <div class="row">';
          row1 += ' <div class="col">';
          row1 += '	<h5 class="h2 card-title text-uppercase text-muted mb-0"> - </h5>';
          row1 += '	<span class="h3  text-orange  font-weight-bold mb-0" > App: - </span> /<span class="h2  text-green  font-weight-bold mb-0" > - </span>  ';
          row1 += '<p>	<span class="h3  text-orange  font-weight-bold mb-0" >฿: - </span > /<span class="h2  text-green  font-weight-bold mb-0" > - </span> </p> ';

          row1 += '</div>';
          row1 += '<div class="col-auto">';
          row1 += ' <div class="h1 icon icon-shape bg-green text-white rounded-circle shadow">';

          row1 += '-';


          row1 += ' </div>';
          row1 += ' <div class=" h5 text-center">%</div>';
          row1 += ' </div>';
          row1 += '	 </div>';





        }


        $("#RETENTION-CURRENT").html(row1);
      })
    });
 
}
