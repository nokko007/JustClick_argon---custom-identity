

function secondsale() {


  //1
  $.ajax(
    {
      url: "/Admin/Dashboard/GetsecondSalenewMTD/",
      datatype: "json",
      success: (function (data1) {
        var row1 = "";


        if (data1.data.length > 0) {
          row1 += '	            <div class="col">	';
          row1 += '	                <div class="col">	';
          row1 += '	                    <div class="row">	';
        row1 += '	                            <span class="text-gray "><i class="fa fa-trophy fa-1x"></i> </span>	';
          for (i = 0; i < data1.data.length; i++) {
            if (i > 0) {
              row1 += '	                        <h5 class="card-title text-uppercase text-muted mb-0"> / ' + data1.data[i].tsr + '</h5>	';
            }
            else {
              row1 += '	                        <h5 class="card-title text-uppercase text-muted mb-0"> ' + data1.data[i].tsr + '</h5>	';
            }

          }
          row1 += '	                    </div>	';
          row1 += '	                    <div class="row">	';
          row1 += '	                        <span class="h1  text-blue  font-weight-bold mb-0">' + data1.data[0].sales + '</span>	';
          row1 += '	                    </div>	';
          row1 += '	                    </div>	';
          //row1 += '	                    <div class="row">	';
          //row1 += '	                <div class="col">	';
          //row1 += '	                        <p class="mt-3 mb-0 text-muted text-sm">	';
  
          //row1 += '	                            <span class="text-nowrap">NEW  /  Top sale MTD</span>	';
          //row1 += '	                        </p>	';
          //row1 += '	                    </div>	';
          //row1 += '	                    </div>	';
          row1 += '	                </div>	';
          row1 += '	                <div class="col-auto">	';
          row1 += '	                    <div class="avatar-group">	';
          for (i = 0; i < data1.data.length; i++) {
            row1 += '	                        <a href="/Admin/Dashboard/Profile/' + data1.data[i].Id + '"" class="avatar avatar-lg rounded-circle">  <img src="/img/Users/' + data1.data[i].tsr_picture + '" >  </a>	';
          }
          row1 += '	                    </div>	';
          row1 += '	                </div>	';


        }

        else {
          row1 += '	            <div class="col">	';
          row1 += '	                <div class="col">	';
          row1 += '	                    <div class="row">	';
          row1 += '	                        <h5 class="card-title text-uppercase text-muted mb-0">-</h5>	';
          row1 += '	                    </div>	';
          row1 += '	                    <div class="row">	';
          row1 += '	                        <span class="h1  text-blue  font-weight-bold mb-0">-</span>	';
          row1 += '	                    </div>	';
          row1 += '	                    </div>	';
          row1 += '	                    <div class="row">	';
          row1 += '	                <div class="col">	';
          row1 += '	                        <p class="mt-3 mb-0 text-muted text-sm">	';
          row1 += '	                            <span class="text-gray "><i class="fa fa-trophy fa-2x"></i> </span>	';
          row1 += '	                            <span class="text-nowrap">NEW/   Top sale MTD</span>	';
          row1 += '	                        </p>	';
          row1 += '	                    </div>	';
          row1 += '	                    </div>	';
          row1 += '	                </div>	';
          row1 += '	                <div class="col-auto">	';
          row1 += '	                    <div class="avatar-group">	';
          row1 += '	                        <a href="" class="avatar avatar-lg rounded-circle">  <img src="/img/Users/no-image.jpg" >  </a>	';
          row1 += '	                    </div>	';
          row1 += '	                </div>	';


        }
        $("#SECOND1").html(row1);
      })
    });
  //2


  $.ajax(
    {
      url: "/Admin/Dashboard/GetsecondSalenewTODAY/",
      datatype: "json",
      success: (function (data1) {
        var row1 = "";


        if (data1.data.length > 0) {
          row1 += '	            <div class="col">	';
          row1 += '	                <div class="col">	';
          row1 += '	                    <div class="row">	';

          for (i = 0; i < data1.data.length; i++) {
            if (i > 0) {
              row1 += '	                        <h5 class="card-title text-uppercase text-muted mb-0">/' + data1.data[i].tsr + '</h5>	';
            }
            else {
              row1 += '	                        <h5 class="card-title text-uppercase text-muted mb-0">' + data1.data[i].tsr + '</h5>	';
            }

          }
          row1 += '	                    </div>	';
          row1 += '	                    <div class="row">	';
          row1 += '	                        <span class="h1  text-blue  font-weight-bold mb-0">' + data1.data[0].sales + '</span>	';
          row1 += '	                    </div>	';
          row1 += '	                    </div>	';
          row1 += '	                    <div class="row">	';
          row1 += '	                <div class="col">	';
          row1 += '	                        <p class="mt-3 mb-0 text-muted text-sm">	';
          row1 += '	                            <span class="text-gray "><i class="fa fa-trophy fa-2x"></i> </span>	';
          row1 += '	                            <span class="text-nowrap">NEW/Top sale Today</span>	';
          row1 += '	                        </p>	';
          row1 += '	                    </div>	';
          row1 += '	                    </div>	';
          row1 += '	                </div>	';
          row1 += '	                <div class="col-auto">	';
          row1 += '	                    <div class="avatar-group">	';
          for (i = 0; i < data1.data.length; i++) {
            row1 += '	                        <a href="/Admin/Dashboard/Profile/' + data1.data[i].Id + '"" class="avatar avatar-lg rounded-circle">  <img src="/img/Users/' + data1.data[i].tsr_picture + '" >  </a>	';
          }
          row1 += '	                    </div>	';
          row1 += '	                </div>	';


        }

        else {
          row1 += '	            <div class="col">	';
          row1 += '	                <div class="col">	';
          row1 += '	                    <div class="row">	';
          row1 += '	                        <h5 class="card-title text-uppercase text-muted mb-0">-</h5>	';
          row1 += '	                    </div>	';
          row1 += '	                    <div class="row">	';
          row1 += '	                        <span class="h1  text-blue  font-weight-bold mb-0">-</span>	';
          row1 += '	                    </div>	';
          row1 += '	                    </div>	';
          row1 += '	                    <div class="row">	';
          row1 += '	                <div class="col">	';
          row1 += '	                        <p class="mt-3 mb-0 text-muted text-sm">	';
          row1 += '	                            <span class="text-gray "><i class="fa fa-trophy fa-2x"></i> </span>	';
          row1 += '	                            <span class="text-nowrap">NEW/Top sale Today</span>	';
          row1 += '	                        </p>	';
          row1 += '	                    </div>	';
          row1 += '	                    </div>	';
          row1 += '	                </div>	';
          row1 += '	                <div class="col-auto">	';
          row1 += '	                    <div class="avatar-group">	';
          row1 += '	                        <a href="" class="avatar avatar-lg rounded-circle">  <img src="/img/Users/no-image.jpg" >  </a>	';
          row1 += '	                    </div>	';
          row1 += '	                </div>	';

        }
        $("#SECOND2").html(row1);
      })
    });

  //3

  $.ajax(
    {
      url: "/Admin/Dashboard/GetsecondSalerenewMTD/",
      datatype: "json",
      success: (function (data1) {
        var row1 = "";


        if (data1.data.length > 0) {
          row1 += '	            <div class="col">	';
          row1 += '	                <div class="col">	';
          row1 += '	                    <div class="row">	';

          for (i = 0; i < data1.data.length; i++) {
            if (i > 0) {
              row1 += '	                        <h5 class="card-title text-uppercase text-muted mb-0">/' + data1.data[i].tsr + '</h5>	';
            }
            else {
              row1 += '	                        <h5 class="card-title text-uppercase text-muted mb-0">' + data1.data[i].tsr + '</h5>	';
            }

          }
          row1 += '	                    </div>	';
          row1 += '	                    <div class="row">	';
          row1 += '	                        <span class="h1  text-blue  font-weight-bold mb-0">' + data1.data[0].sales + '</span>	';
          row1 += '	                    </div>	';
          row1 += '	                    </div>	';
          row1 += '	                    <div class="row">	';
          row1 += '	                <div class="col">	';
          row1 += '	                        <p class="mt-3 mb-0 text-muted text-sm">	';
          row1 += '	                            <span class="text-gray "><i class="fa fa-trophy fa-2x"></i> </span>	';
          row1 += '	                            <span class="text-nowrap">RENEW/Top sale MTD</span>	';
          row1 += '	                        </p>	';
          row1 += '	                    </div>	';
          row1 += '	                    </div>	';
          row1 += '	                </div>	';
          row1 += '	                <div class="col-auto">	';
          row1 += '	                    <div class="avatar-group">	';
          for (i = 0; i < data1.data.length; i++) {
            row1 += '	                        <a href="/Admin/Dashboard/Profile/' + data1.data[i].Id + '"" class="avatar avatar-lg rounded-circle">  <img src="/img/Users/' + data1.data[i].tsr_picture + '" >  </a>	';
          }
          row1 += '	                    </div>	';
          row1 += '	                </div>	';


        }

        else {
          row1 += '	            <div class="col">	';
          row1 += '	                <div class="col">	';
          row1 += '	                    <div class="row">	';
          row1 += '	                        <h5 class="card-title text-uppercase text-muted mb-0">-</h5>	';
          row1 += '	                    </div>	';
          row1 += '	                    <div class="row">	';
          row1 += '	                        <span class="h1  text-blue  font-weight-bold mb-0">-</span>	';
          row1 += '	                    </div>	';
          row1 += '	                    </div>	';
          row1 += '	                    <div class="row">	';
          row1 += '	                <div class="col">	';
          row1 += '	                        <p class="mt-3 mb-0 text-muted text-sm">	';
          row1 += '	                            <span class="text-gray "><i class="fa fa-trophy fa-2x"></i> </span>	';
          row1 += '	                            <span class="text-nowrap">RENEW/Top sale MTD</span>	';
          row1 += '	                        </p>	';
          row1 += '	                    </div>	';
          row1 += '	                    </div>	';
          row1 += '	                </div>	';
          row1 += '	                <div class="col-auto">	';
          row1 += '	                    <div class="avatar-group">	';
          row1 += '	                        <a href="" class="avatar avatar-lg rounded-circle">  <img src="/img/Users/no-image.jpg" >  </a>	';
          row1 += '	                    </div>	';
          row1 += '	                </div>	';

        }
        $("#SECOND3").html(row1);
      })
    });

  //4

  $.ajax(
    {
      url: "/Admin/Dashboard/GetsecondSalerenewTODAY/",
      datatype: "json",
      success: (function (data1) {
        var row1 = "";


        if (data1.data.length > 0) {
          row1 += '	            <div class="col">	';
          row1 += '	                <div class="col">	';
          row1 += '	                    <div class="row">	';

          for (i = 0; i < data1.data.length; i++) {
            if (i > 0) {
              row1 += '	                        <h5 class="card-title text-uppercase text-muted mb-0">/' + data1.data[i].tsr + '</h5>	';
            }
            else {
              row1 += '	                        <h5 class="card-title text-uppercase text-muted mb-0">' + data1.data[i].tsr + '</h5>	';
            }

          }
          row1 += '	                    </div>	';
          row1 += '	                    <div class="row">	';
          row1 += '	                        <span class="h1  text-blue  font-weight-bold mb-0">' + data1.data[0].sales + '</span>	';
          row1 += '	                    </div>	';
          row1 += '	                    </div>	';
          row1 += '	                    <div class="row">	';
          row1 += '	                <div class="col">	';
          row1 += '	                        <p class="mt-3 mb-0 text-muted text-sm">	';
          row1 += '	                            <span class="text-gray "><i class="fa fa-trophy fa-2x"></i> </span>	';
          row1 += '	                            <span class="text-nowrap">RENEW/Top sale Today</span>	';
          row1 += '	                        </p>	';
          row1 += '	                    </div>	';
          row1 += '	                    </div>	';
          row1 += '	                </div>	';
          row1 += '	                <div class="col-auto">	';
          row1 += '	                    <div class="avatar-group">	';
          for (i = 0; i < data1.data.length; i++) {
            row1 += '	                        <a href="/Admin/Dashboard/Profile/' + data1.data[i].Id + '"" class="avatar avatar-lg rounded-circle">  <img src="/img/Users/' + data1.data[i].tsr_picture + '" >  </a>	';
          }
          row1 += '	                    </div>	';
          row1 += '	                </div>	';


        }

        else {
          row1 += '	            <div class="col">	';
          row1 += '	                <div class="col">	';
          row1 += '	                    <div class="row">	';
          row1 += '	                        <h5 class="card-title text-uppercase text-muted mb-0">-</h5>	';
          row1 += '	                    </div>	';
          row1 += '	                    <div class="row">	';
          row1 += '	                        <span class="h1  text-blue  font-weight-bold mb-0">-</span>	';
          row1 += '	                    </div>	';
          row1 += '	                    </div>	';
          row1 += '	                    <div class="row">	';
          row1 += '	                <div class="col">	';
          row1 += '	                        <p class="mt-3 mb-0 text-muted text-sm">	';
          row1 += '	                            <span class="text-gray "><i class="fa fa-trophy fa-2x"></i> </span>	';
          row1 += '	                            <span class="text-nowrap">RENEW/Top sale Today</span>	';
          row1 += '	                        </p>	';
          row1 += '	                    </div>	';
          row1 += '	                    </div>	';
          row1 += '	                </div>	';
          row1 += '	                <div class="col-auto">	';
          row1 += '	                    <div class="avatar-group">	';
          row1 += '	                        <a href="" class="avatar avatar-lg rounded-circle">  <img src="/img/Users/no-image.jpg" >  </a>	';
          row1 += '	                    </div>	';
          row1 += '	                </div>	';

        }
        $("#SECOND4").html(row1);
      })
    });
}
