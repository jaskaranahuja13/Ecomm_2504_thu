var dataTable

$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Product/GetAll"
        },
        "columns": [
            { "data": "title", "width": "15%" },
            { "data": "description", "width": "25%" },
            { "data": "author", "width": "15%" },
            { "data": "isbn", "width": "15%" },
            { "data": "price", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
<div class="text-center">
<a class="btn btn-success" href="/Admin/Product/Upsert/${data}">
<i class="fas fa-edit"></i>
</a>
<a class="btn btn-danger" onclick=Delete("/Admin/Product/Delete/${data}")>
<i class="fas fa-trash-alt"></i>
</a>
</div>
`;
                }
            }
        ]
    })
}
function Delete(url) {
    swal({
        title: "Want to Delete data?",
        text: "Data will be deleted!!!",
        icon: "warning",
        buttons: true, dangerModel: true
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