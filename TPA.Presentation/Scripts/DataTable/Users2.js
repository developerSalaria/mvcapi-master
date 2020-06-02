"use strict";
// Class definition

var KTDatatableRemoteAjaxDemo = function () {
    // Private functions

    // basic demo
    var demo = function () {

        var datatable = $('.kt-datatable').KTDatatable({
            // datasource definition
            data: {
                type: 'remote',
                source: {
                    read: {
                        url: serverUri,
                        // sample custom headers
                        headers: { 'x-my-custokt-header': 'some value', 'x-test-header': 'the value' },
                        map: function (raw) {
                            // sample data mapping
                            var dataSet = raw;
                            if (typeof raw.data !== 'undefined') {
                                dataSet = raw.data;
                            }
                            return dataSet;
                        },
                    },
                },
                pageSize: 10,
                serverPaging: true,
                serverFiltering: true,
                serverSorting: true,
            },

            // layout definition
            layout: {
                scroll: false,
                footer: false,
            },

            // column sorting
            sortable: true,

            pagination: true,

            search:
                {
                    input: $('#txtUserId'),
                    input2: $('#txtUserNameEnglish'),
                },
                //{
                //    input: $('#txtUserNameEnglish'),
                //    //input: $('#txtUserNameEnglish'),
                //}
            //],

            // columns definition
            columns: [
                {
                    field: 'User_ID',
                    title: 'User ID',
                    //width: 30,
                    type: 'number',
                    template: function (row) {
                        return row.User_ID;
                    },
                },
                {
                     field: 'User_Name_ARB',
                     title: 'Name Arabic',
                },
                {
                    field: 'User_Name_ENG',
                    title: 'Name English',
                },
                {
                    field: 'Actions',
                    title: 'Actions',
                    sortable: false,
                    width: 110,
                    overflow: 'visible',
                    autoHide: false,
                    template: function () {
                        return '\
						<div class="dropdown">\
							<a href="javascript:;" class="btn btn-sm btn-clean btn-icon btn-icon-sm" data-toggle="dropdown">\
                                <i class="flaticon2-gear"></i>\
                            </a>\
						  	<div class="dropdown-menu dropdown-menu-right">\
						    	<a class="dropdown-item" href="#"><i class="la la-edit"></i> Edit Details</a>\
						    	<a class="dropdown-item" href="#"><i class="la la-leaf"></i> Update Status</a>\
						    	<a class="dropdown-item" href="#"><i class="la la-print"></i> Generate Report</a>\
						  	</div>\
						</div>\
						<a href="javascript:;" class="btn btn-sm btn-clean btn-icon btn-icon-sm" title="Edit details">\
							<i class="flaticon2-paper"></i>\
						</a>\
						<a href="javascript:;" class="btn btn-sm btn-clean btn-icon btn-icon-sm" title="Delete">\
							<i class="flaticon2-trash"></i>\
						</a>\
					';
                    },
                }],

        });

        $('#kt_form_status').on('change', function () {
            datatable.search($(this).val().toLowerCase(), 'Status');
        });

        $('#kt_form_type').on('change', function () {
            datatable.search($(this).val().toLowerCase(), 'Type');
        });

        $('#kt_form_status,#kt_form_type').selectpicker();

    };

    return {
        // public functions
        init: function () {
            demo();
        },
    };
}();

jQuery(document).ready(function () {
    KTDatatableRemoteAjaxDemo.init();
});
//__________________________________________LAST____________________________________________________
//"use strict";
// Class definition

//var KTDefaultDatatableDemo = function () {
//    // Private functions

//    // basic demo
//    var demo = function () {

//        var options = {
//            // datasource definition
//            data: {
//                type: 'remote',
//                source: {
//                    read: {
//                        url: serverUri,
//                    },
//                },
//                pageSize: 10, // display 20 records per page
//                serverPaging: true,
//                serverFiltering: true,
//                serverSorting: true,
//            },

//            // layout definition
//            layout: {
//                scroll: false, // enable/disable datatable scroll both horizontal and vertical when needed.
//                height: 550, // datatable's body's fixed height
//                footer: false, // display/hide footer
//            },

//            // column sorting
//            sortable: true,

//            pagination: true,

//            search: {
//                input: $('#txtUserId'),
//                input: $('#DropdownLaborOfficeSearch'),
//                input: $('#txtUserNameEnglish'),
//                input: $('#txtUserNameArabic')
//            },

//            // columns definition
//            columns: [
//                //{
//                //    "data": "User_ID", "orderable": false, "width": "3%", "render": function (data, type, row) {

//                //        return '<button id="' + row.User_ID + '" data-id="' + data + '" onclick="updateEvent(this)" class="btn btn-link btn-Update  text-primary" data-toggle="tooltip" data-placement="top"  title="Edit"><i class="fas fa-edit"></i></button>'
//                //            +
//                //            '<button id="' + row.User_ID + '" onclick="deleteEvent(this)" class="btn btn-link btn-Delete  text-danger" data-toggle="tooltip" data-placement="top"  title="Remove"><i class="fas fa-trash-alt "></i></button>'
//                //            ;
//                //    }
//                //},
//                 {
//                    field: 'User_ID',
//                    title: 'User ID',
//                    width: 30,
//                    type: 'number',
//                    template: function (row) {
//                        return row.User_ID;
//                    },
//                },
//                {
//                     field: 'User_Name_ARB',
//                     title: 'Name Arabic',
//                },
//                {
//                    field: 'User_Name_ENG',
//                    title: 'Name English',
//                },
//                {
//                    field: 'Actions',
//                    title: 'Actions',
//                    sortable: false,
//                    width: 110,
//                    overflow: 'visible',
//                    autoHide: false,
//                    template: function () {
//                        return '\
//						<div class="dropdown">\
//							<a href="javascript:;" class="btn btn-sm btn-clean btn-icon btn-icon-md" data-toggle="dropdown">\
//                                <i class="la la-ellipsis-h"></i>\
//                            </a>\
//						  	<div class="dropdown-menu dropdown-menu-right">\
//						    	<a class="dropdown-item" href="#"><i class="la la-edit"></i> Edit Details</a>\
//						    	<a class="dropdown-item" href="#"><i class="la la-leaf"></i> Update Status</a>\
//						    	<a class="dropdown-item" href="#"><i class="la la-print"></i> Generate Report</a>\
//						  	</div>\
//						</div>\
//						<a href="javascript:;" class="btn btn-sm btn-clean btn-icon btn-icon-md" title="Edit details">\
//							<i class="la la-edit"></i>\
//						</a>\
//						<a href="javascript:;" class="btn btn-sm btn-clean btn-icon btn-icon-md" title="Delete">\
//							<i class="la la-trash"></i>\
//						</a>\
//					';
//                    },
//                }
//            ],

//        };

//        var datatable = $('.kt-datatable').KTDatatable(options);

//        // both methods are supported
//        // datatable.methodName(args); or $(datatable).KTDatatable(methodName, args);

//        $('#kt_datatable_destroy').on('click', function () {
//            // datatable.destroy();
//            $('.kt-datatable').KTDatatable('destroy');
//        });

//        $('#kt_datatable_init').on('click', function () {
//            datatable = $('.kt-datatable').KTDatatable(options);
//        });

//        $('#kt_datatable_reload').on('click', function () {
//            // datatable.reload();
//            $('.kt-datatable').KTDatatable('reload');
//        });

//        $('#kt_datatable_sort_asc').on('click', function () {
//            datatable.sort('Status', 'asc');
//        });

//        $('#kt_datatable_sort_desc').on('click', function () {
//            datatable.sort('Status', 'desc');
//        });

//        // get checked record and get value by column name
//        $('#kt_datatable_get').on('click', function () {
//            // select active rows
//            datatable.rows('.kt-datatable__row--active');
//            // check selected nodes
//            if (datatable.nodes().length > 0) {
//                // get column by field name and get the column nodes
//                var value = datatable.columns('CompanyName').nodes().text();
//                console.log(value);
//            }
//        });

//        // record selection
//        $('#kt_datatable_check').on('click', function () {
//            var input = $('#kt_datatable_check_input').val();
//            datatable.setActive(input);
//        });

//        $('#kt_datatable_check_all').on('click', function () {
//            // datatable.setActiveAll(true);
//            $('.kt-datatable').KTDatatable('setActiveAll', true);
//        });

//        $('#kt_datatable_uncheck_all').on('click', function () {
//            // datatable.setActiveAll(false);
//            $('.kt-datatable').KTDatatable('setActiveAll', false);
//        });

//        $('#kt_datatable_hide_column').on('click', function () {
//            datatable.columns('ShipDate').visible(false);
//        });

//        $('#kt_datatable_show_column').on('click', function () {
//            datatable.columns('ShipDate').visible(true);
//        });

//        $('#kt_datatable_remove_row').on('click', function () {
//            datatable.rows('.kt-datatable__row--active').remove();
//        });

//        $('#kt_form_status,#kt_form_type').selectpicker();

//    };

//    return {
//        // public functions
//        init: function () {
//            demo();
//        },
//    };
//}();

//jQuery(document).ready(function () {
//    KTDefaultDatatableDemo.init();
//});

////"use strict";
//var KTDatatablesSearchOptionsAdvancedSearch = function () {

//    //$.fn.dataTable.Api.register('column().title()', function () {
//    //    return $(this.header()).text().trim();
//    //});

//    var initTable1 = function () {
//        // begin first table
//        var table = $('#kt_table_1').DataTable({
//            responsive: true,
//            // Pagination settings
//            dom: `<'row'<'col-sm-12'tr>>
//			<'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7 dataTables_pager'lp>>`,
//            // read more: https://datatables.net/examples/basic_init/dom.html

//            lengthMenu: [5, 10, 25, 50],

//            pageLength: 10,

//            language: {
//                'lengthMenu': 'Display _MENU_',
//            },

//            searchDelay: 500,
//            processing: true,
//            serverSide: true,
//            ajax: {
//                url: serverUri,
//                type: 'POST',
//                //data: {
//                //    // parameters for custom backend script demo
//                //    columnsDef: [
//                //        'RecordID', 'OrderID', 'Country', 'ShipCity', 'CompanyAgent',
//                //        'ShipDate', 'Status', 'Type', 'Actions',],
//                //},
//            },
//            columns: [
//                {
//                    "data": null, render: function (data, type, row, meta) {
//                        return meta.row + meta.settings._iDisplayStart + 1;
//                    }
//                },
//                { "data": "User_ID", "name": "User_ID", "autoWidth": true },
//                { "data": "User_Name_ARB", "name": "User_Name_ARB", "autoWidth": true },
//                { "data": "User_Name_ENG", "name": "User_Name_ENG", "autoWidth": true },
//                {
//                    "data": "User_ID", "orderable": false, "width": "3%", "render": function (data, type, row) {

//                        return '<button id="' + row.User_ID + '" data-id="' + data + '" onclick="updateEvent(this)" class="btn btn-link btn-Update  text-primary" data-toggle="tooltip" data-placement="top"  title="Edit"><i class="fas fa-edit"></i></button>'
//                            +
//                            '<button id="' + row.User_ID + '" onclick="deleteEvent(this)" class="btn btn-link btn-Delete  text-danger" data-toggle="tooltip" data-placement="top"  title="Remove"><i class="fas fa-trash-alt "></i></button>'
//                            ;
//                    }
//                }
//                //{ data: 'Actions', responsivePriority: -1 },
//            ],

//            initComplete: function () {
//                //this.api().columns().every(function () {
//                //    var column = this;

//                //    switch (column.title()) {
//                //        case 'Country':
//                //            column.data().unique().sort().each(function (d, j) {
//                //                $('.kt-input[data-col-index="2"]').append('<option value="' + d + '">' + d + '</option>');
//                //            });
//                //            break;

//                //        case 'Status':
//                //            var status = {
//                //                1: { 'title': 'Pending', 'class': 'kt-badge--brand' },
//                //                2: { 'title': 'Delivered', 'class': ' kt-badge--danger' },
//                //                3: { 'title': 'Canceled', 'class': ' kt-badge--primary' },
//                //                4: { 'title': 'Success', 'class': ' kt-badge--success' },
//                //                5: { 'title': 'Info', 'class': ' kt-badge--info' },
//                //                6: { 'title': 'Danger', 'class': ' kt-badge--danger' },
//                //                7: { 'title': 'Warning', 'class': ' kt-badge--warning' },
//                //            };
//                //            column.data().unique().sort().each(function (d, j) {
//                //                $('.kt-input[data-col-index="6"]').append('<option value="' + d + '">' + status[d].title + '</option>');
//                //            });
//                //            break;

//                //        case 'Type':
//                //            var status = {
//                //                1: { 'title': 'Online', 'state': 'danger' },
//                //                2: { 'title': 'Retail', 'state': 'primary' },
//                //                3: { 'title': 'Direct', 'state': 'success' },
//                //            };
//                //            column.data().unique().sort().each(function (d, j) {
//                //                $('.kt-input[data-col-index="7"]').append('<option value="' + d + '">' + status[d].title + '</option>');
//                //            });
//                //            break;
//                //    }
//                //});
//            },

//            //columnDefs: [
//            //    {
//            //        targets: -1,
//            //        title: 'Actions',
//            //        orderable: false,
//            //        render: function (data, type, full, meta) {
//            //            return `
//            //            <span class="dropdown">
//            //                <a href="#" class="btn btn-sm btn-clean btn-icon btn-icon-md" data-toggle="dropdown" aria-expanded="true">
//            //                  <i class="la la-ellipsis-h"></i>
//            //                </a>
//            //                <div class="dropdown-menu dropdown-menu-right">
//            //                    <a class="dropdown-item" href="#"><i class="la la-edit"></i> Edit Details</a>
//            //                    <a class="dropdown-item" href="#"><i class="la la-leaf"></i> Update Status</a>
//            //                    <a class="dropdown-item" href="#"><i class="la la-print"></i> Generate Report</a>
//            //                </div>
//            //            </span>
//            //            <a href="#" class="btn btn-sm btn-clean btn-icon btn-icon-md" title="View">
//            //              <i class="la la-edit"></i>
//            //            </a>`;
//            //        },
//            //    },
//            //    {
//            //        targets: 6,
//            //        render: function (data, type, full, meta) {
//            //            var status = {
//            //                1: { 'title': 'Pending', 'class': 'kt-badge--brand' },
//            //                2: { 'title': 'Delivered', 'class': ' kt-badge--danger' },
//            //                3: { 'title': 'Canceled', 'class': ' kt-badge--primary' },
//            //                4: { 'title': 'Success', 'class': ' kt-badge--success' },
//            //                5: { 'title': 'Info', 'class': ' kt-badge--info' },
//            //                6: { 'title': 'Danger', 'class': ' kt-badge--danger' },
//            //                7: { 'title': 'Warning', 'class': ' kt-badge--warning' },
//            //            };
//            //            if (typeof status[data] === 'undefined') {
//            //                return data;
//            //            }
//            //            return '<span class="kt-badge ' + status[data].class + ' kt-badge--inline kt-badge--pill">' + status[data].title + '</span>';
//            //        },
//            //    },
//            //    {
//            //        targets: 7,
//            //        render: function (data, type, full, meta) {
//            //            var status = {
//            //                1: { 'title': 'Online', 'state': 'danger' },
//            //                2: { 'title': 'Retail', 'state': 'primary' },
//            //                3: { 'title': 'Direct', 'state': 'success' },
//            //            };
//            //            if (typeof status[data] === 'undefined') {
//            //                return data;
//            //            }
//            //            return '<span class="kt-badge kt-badge--' + status[data].state + ' kt-badge--dot"></span>&nbsp;' +
//            //                '<span class="kt-font-bold kt-font-' + status[data].state + '">' + status[data].title + '</span>';
//            //        },
//            //    },
//            //],
//        });

//        var filter = function () {
//            var val = $.fn.dataTable.util.escapeRegex($(this).val());
//            table.column($(this).data('col-index')).search(val ? val : '', false, false).draw();
//        };

//        var asdasd = function (value, index) {
//            var val = $.fn.dataTable.util.escapeRegex(value);
//            table.column(index).search(val ? val : '', false, true);
//        };

//        $('#kt_search').on('click', function (e) {
//            e.preventDefault();
//            var params = {};
//            $('.kt-input').each(function () {
//                var i = $(this).data('col-index');
//                if (params[i]) {
//                    params[i] += '|' + $(this).val();
//                }
//                else {
//                    params[i] = $(this).val();
//                }
//            });
//            $.each(params, function (i, val) {
//                // apply search params to datatable
//                table.column(i).search(val ? val : '', false, false);
//            });
//            table.table().draw();
//        });

//        $('#kt_reset').on('click', function (e) {
//            e.preventDefault();
//            $('.kt-input').each(function () {
//                $(this).val('');
//                table.column($(this).data('col-index')).search('', false, false);
//            });
//            table.table().draw();
//        });

//        //$('#kt_datepicker').datepicker({
//        //    todayHighlight: true,
//        //    templates: {
//        //        leftArrow: '<i class="la la-angle-left"></i>',
//        //        rightArrow: '<i class="la la-angle-right"></i>',
//        //    },
//        //});

//    };

//    return {

//        //main function to initiate the module
//        init: function () {
//            initTable1();
//        },

//    };

//}();

//jQuery(document).ready(function () {
//    KTDatatablesSearchOptionsAdvancedSearch.init();
//});