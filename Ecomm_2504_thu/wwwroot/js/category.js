﻿var dataTable

$(document).ready(function () {
    loadDataTable();
})
function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Category/GetAll"
        },
        "columns": [
            { "data": "name", "width": "70%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
<div class="text-center">
<a class="btn btn-success" href="/Admin/Category/Upsert/${data}">
<i class="fas fa-edit"></i>
</a>
<a class="btn btn-danger" onclick=Delete("/Admin/Category/Delete/${data}")>
<i class="fas fa-trash-alt"></i>
</a>
`
                }
            }
            ]
                
            
            
        })
}
function Delete(url) {
    swal({
        title: "Want To Delete Data?",
        text: "DATA WILL BE DELETED!!!",
        icon: "warning",
        buttons: true,
        dangerModel: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                url: url,
                type: "DELETE",
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
                })
        }
    })
}