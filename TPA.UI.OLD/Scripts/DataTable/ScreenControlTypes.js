$(document).ready(function () {
    renderdataTable();
    $('#addbtn').on('click', function () {
        cleartxt();
        $('#addEditModal').modal('show');
    });

    $.searchUserByFilters = function () {
        if (parseInt('0' + $('#DropdownLaborOfficeSearch').val()) == 0 &&
            $("#txtUserId").val() == "" && $("#txtUserNameEnglish").val() == "" && $("#txtUserNameArabic").val() == "") {
            swal.fire("Please select any of the field");
            return;
        }

        renderdataTable();
    }

    $("#txtUserId").add("#txtUserNameEnglish").add("#txtUserNameArabic").on("keydown", function (event) {
        if (event.which == 13) {
            $.searchUserByFilters();
        }
    });

    $("#kt_search").click(function () {
        $.searchUserByFilters();
    });

    $("#kt_reset").click(function () {
        $('#DropdownLaborOfficeSearch').val(0);
        $('#txtUserId').val('');
        $('#txtUserNameEnglish').val('');
        $('#txtUserNameArabic').val('');
        renderdataTable();
    });
});
function cleartxt() {
    $('#popupForm').closest('form').find("input[type=text],input[type=password], textarea").val("");
    $('#percodetxt').prop("readonly", false)
}
function renderdataTable() {
    $('#myDatatable').DataTable({
        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "serverFiltering": true,
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
        "bDestroy": true,
        "ajax": {
            "url": serverUri,
            "type": "Post",
            "datatype": "json"
            //"data": function (d) {
            //    d.searchUserId = $("#txtUserId").val();
            //    d.searchCompanyLaborOffice = parseInt('0' + $('#DropdownLaborOfficeSearch').val());
            //    d.searchUserNameArabic = $("#txtUserNameEnglish").val();
            //    d.searchUserNameEnglish = $("#txtUserNameArabic").val();
            //}
        },
        //search: {
        //    input: $('#txtUserId'),
        //    input: $('#DropdownLaborOfficeSearch'),
        //    input: $('#txtUserNameEnglish'),
        //    input: $('#txtUserNameArabic')
        //},
        "columns": [
            {
                "data": null, render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            { "data": "NAME_ENGLISH", "name": "NAME ENGLISH", "autoWidth": true },
            { "data": "NAME_ARABIC", "name": "NAME ARABIC", "autoWidth": true },
            {
                "data": "SEC_SCREEN_CONTROL_TYPE_ID", "orderable": false, "width": "3%", "render": function (data, type, row) {

                    return '<button id="' + row.User_ID + '" data-id="' + data + '" onclick="editScreenControlType(' + row.SEC_SCREEN_CONTROL_TYPE_ID + ')" class="btn btn-sm btn-clean btn-icon btn-icon-md" data-toggle="tooltip" data-placement="top"  title="Edit"><i class="la la-edit"></i></button>'
                        +
                        '<button id="' + row.SEC_SCREEN_CONTROL_TYPE_ID + '" onclick="deleteEvent(this)" class="btn btn-sm btn-clean btn-icon btn-icon-md" data-toggle="tooltip" data-placement="top"  title="Remove"><i class="fas fa-trash-alt "></i></button>'
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
function updateEvent(obj) {
    var id = $(obj).attr('Id');
    $.ajax({
        url: `${baseurl}/security/applicationuser/GetUserByUserId?userId=${id}`,
        type: 'get',
        cache: false,
        success: function (data) {
            cleartxt();
            $('#hiddenid').val('1');
            $('#percodetxt').val(data.PER_CODE);
            $('#percodetxt').prop("readonly", true)
            $('#pernamearbtxt').val(data.PER_NAME_ARB);
            $('#pernameengtxt').val(data.PER_NAME_ENG);
            $('#addEditModal').modal('show');
        }
    });
}
function deleteEvent(obj) {
    var rowID = $(obj).attr('Id');
    swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        type: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Yes, delete it!',
        focusConfirm: false,
        preConfirm: (login) => {
            return fetch(deleteUri + "?screenControlTypeId=" + rowID)
                .then(response => {
                    if (!response.ok) {
                        throw new Error(response.statusText)
                    }
                    return response.json()
                })
                .catch(error => {
                    Swal.showValidationMessage(
                        `Request failed: ${error}`
                    )
                })
        },
        allowOutsideClick: () => !Swal.isLoading()
    }).then(function (result) {
        if (result.value == true) {
            swal.fire(
                'Deleted!',
                'Your file has been deleted.',
                'success'
            );
            renderdataTable();
        }
    });
    //sessionStorage.setItem("delId", rowID)
    //$('#deleteModal').modal('show');
}
$('#delBtn').on('click', function () {

    $.ajax({
        url: `${baseurl}/Person/Remove/${sessionStorage.getItem("delId")}`,
        type: 'delete',
        cache: false,
        success: function (value) {
            if (value) {
                location.reload();
            } else {
                toastr.warning("can't remove!");
            }
            sessionStorage.removeItem("delId");
        }
    });
});
