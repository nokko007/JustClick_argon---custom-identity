var dataTable;




$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {


    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Callback/GetAll",
          
                },
                "columns": [
                    { "data": "project_code", "width": "30%" },
                    { "data": "callbackreason", "width": "40%" },
                    { "data": "needterminate", "width": "20%" },
                    {
                        "data": "callbackcode",
                        "render": function (data) {
                            return `
                          

                                          <td class="text-right">
                                                <div class="dropdown">
                                                    <a class="btn btn-sm btn-icon-only text-light" href="#" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                        <i class="fas fa-ellipsis-v"></i>
                                                    </a>
                                                    <div class="dropdown-menu dropdown-menu-xl dropdown-menu-arrow">
                                                        <a href= "/Admin/Callback/Upsert/${data}" class="dropdown-item">Edit</a>
                                                        <a onclick=Delete("/Admin/Callback/Delete/${data}") class="dropdown-item">Delete</a>
                                                    </div>
                                                </div>
                                            </td>



                                   `;
                        },


                        "width": "10%"
                    }
        ]
    });
}



function Delete(url) {
    swal({
        title: "Are you sure you want to Delete?",
        text: "You will not be able to restore the data!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}
;


