$(document).ready(function () {
    // DataTable initialisation
    $('#exportable').DataTable(
        {

            "paging": true,
            "autoWidth": true,

            language: {
                decimal: '.',
                thousands: ',',

            },
            dom: 'Bfrtip',

            buttons: [
                { extend: 'excel', text: 'Export To Excel', title: 'SyCip Salazar Hernandez & Gatmaitan' + '\n' + 'Supplies Supplies Report', className: "dt-center", targets: "_current", footer: false, page: true },
                { extend: 'pdfHtml5', text: 'Export To PDF', title: 'SyCip Salazar Hernandez & Gatmaitan' + '\n' + 'Supplies Report', className: "dt-center", targets: "_current", footer: false, orientation: 'portrait', page: false },
                { extend: 'print', title: 'SyCip Salazar Hernandez & Gatmaitan' + '\n' + 'Supplies Report', className: "dt-center", targets: "_current", footer: false, orientation: 'portrait', page: true }

            ],
            order: [[0, "asc"]],

            "footerCallback": function (row, data, start, end, display) {
                var api = this.api();
                nb_cols = api.columns().nodes().length;
                var j = 4;
                while (j < nb_cols) {
                    var pageTotal = api
                        .column(j, { page: 'current' })
                        /*.column(j)*/
                        .data()
                        .reduce(function (a, b) {
                            return Number(a) + Number(b);
                        }, 0);
                    // Update footer
                    $(api.column(j).footer()).html(pageTotal);
                    j++;



                }
            }
        }

    );

	$('#RequestedList').DataTable(
        {
            "paging": true,
            "autoWidth": true,

            language: {
                decimal: '.',
                thousands: ',',
            },
            dom: 'Bfrtip',
            buttons: [
                { extend: 'excel', text:'Export To Excel',  title: 'SyCip Salazar Hernandez & Gatmaitan' + '\n' + 'Supplies Supplies Report', className: "dt-center", targets: "_current", footer: false, page: true },
                { extend: 'pdfHtml5', text: 'Export To PDF', title: 'SyCip Salazar Hernandez & Gatmaitan' + '\n' + 'Supplies Report', className: "dt-center", targets: "_current", footer: false, orientation: 'portrait', page: false },
                { extend: 'print', title: 'SyCip Salazar Hernandez & Gatmaitan' + '\n' + 'Supplies Report', className: "dt-center", targets: "_current", footer: false, orientation: 'portrait', page: true }
            ],
			columnDefs: [{ "targets": 2, "type": "date-eu-desc" }],
            order: [[0, "desc"]],
            "footerCallback": function (row, data, start, end, display) {
                var api = this.api();
                nb_cols = api.columns().nodes().length;
                var j = 4;
                while (j < nb_cols) {
                    var pageTotal = api
                        .column(j, { page: 'current' })
                        /*.column(j)*/
                        .data()
                        .reduce(function (a, b) {
                            return Number(a) + Number(b);
                        }, 0);
                    // Update footer
                    $(api.column(j).footer()).html(pageTotal);
                    j++;
                }
            }
        }
    );
});
