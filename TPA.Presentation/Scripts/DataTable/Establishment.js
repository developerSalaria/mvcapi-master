$(document).ready(function () {
    renderdataTable();
});

function renderdataTable() {
    $('#myDatatable').DataTable({
        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "filter": false, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once          
        "language": {
            "loadingRecords": "&nbsp;",
            "sProcessing": "<i class='fas fa-spinner fa-2x text-success fa-spin'></i>",
            "emptyTable": "No data available in table",
            "info": "Showing _START_ to _END_ of _TOTAL_ entries",
            "infoEmpty": "Showing 0 to 0 of 0 entries",
            "infoFiltered": "(filtered from _MAX_ total entries)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Show _MENU_ entries",
            "loadingRecords": "Loading...",
            "processing": "Processing...",
            "search": "Search:",
            "zeroRecords": "No matching records found",
            "paginate": {
                "first": "First",
                "last": "Last",
                "next": "Next",
                "previous": "Previous"
            },
            "aria": {
                "sortAscending": ": activate to sort column ascending",
                "sortDescending": ": activate to sort column descending"
            }
        },
        "ajax": {
            "url": serverUri,
            "type": "Post",
            "datatype": "json",
            "data": model
        },
        "columns": [
           
            { "data": "COM_COMPANY_CODE", "name": "COM_COMPANY_CODE", "autoWidth": true },
            { "data": "COM_NAME_ARB", "name": "COM_NAME_ARB", "autoWidth": true },
            { "data": "COM_NAME_ENG", "name": "COM_NAME_ENG", "autoWidth": true },
            { "data": "GET_CATEGORY", "name": "GET_CATEGORY", "autoWidth": true },
            { "data": "GET_NATIONALITY_NAME", "name": "GET_NATIONALITY_NAME", "autoWidth": true },
            {
                "data": "COM_COMPANY_CODE", "orderable": false, "width": "3%", "render": function (data, type, row) {

                    return '<button id="' + row.COM_COMPANY_CODE + '" data-id="' + data + '" onclick="updateEvent(' + row.OM_COMPANY_CODE+')" class="btn btn-link btn-Update  text-primary" data-toggle="tooltip" data-placement="top"  title="Edit"><i class="fas fa-edit"></i></button>'
                        ;
                }
            }

        ],
        "initComplete": function () {
            $('[data-toggle="tooltip"]').tooltip();

        }
    }).on('draw', function () {
        $('[data-toggle="tooltip"]').tooltip();

    });
}

