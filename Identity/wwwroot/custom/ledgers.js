// Shared variables
var table;
var dt;
var filterPayment;
var datafortable;
KTUtil.onDOMContentLoaded(function () {
    console.log("Ledger Document is ready");
    var companyId = $('#LedgersCompanyId').val()
    handleSearchDatatable();
    loadDataTable(companyId);
});

function loadDataTable(companyId) {
    dt = $("#Dt_Records_List").DataTable({
        searchDelay: 500,
        processing: true,
        stateSave: true,
        autoWidth:true,
        ajax: {
            "url": `/Ledgers/GetAll/${companyId}`,
            "type": "GET",
            "datatype": "json"
        },
        columns: [
            { data: 'ledgerId' },
            { data: 'date' },
            { data: 'particular' },
            { data: 'size' },
            { data: 'type' },
            { data: 'quantity' },
            { data: 'weight' },
            { data: 'rate' },
            { data: 'debit' },
            { data: 'credit' },
            //{ data: 'balance' },
            { data: 'id' },
        ],
        columnDefs: [
            {
                targets: 10,
                render: function (data, type, row, settings) {
                    console.log(row)
                    return `
                            <div class="d-flex justify-content-center">
                                 <a  onclick=Delete("/Ledgers/Delete?id=+${data}") class="btn btn-light btn-active-light-danger btn-sm mx-2" data-bs-toggle="tooltip" title="Delete">
                                     <span class="svg-icon svg-icon-muted svg-icon-2"><svg width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                     <rect opacity="0.3" x="2" y="2" width="20" height="20" rx="5" fill="currentColor"/>
                                     <rect x="7" y="15.3137" width="12" height="2" rx="1" transform="rotate(-45 7 15.3137)" fill="currentColor"/>
                                     <rect x="8.41422" y="7" width="12" height="2" rx="1" transform="rotate(45 8.41422 7)" fill="currentColor"/>
                                     </svg>
                                     </span>
                                 </a>
                            </div>
                        `;
                },
            },
           
        ],
   
    });

    table = dt.$;
}

var handleSearchDatatable = function () {
    const filterSearch = document.querySelector('[data-kt-docs-table-filter="search"]');
    filterSearch.addEventListener('keyup', function (e) {
        dt.search(e.target.value).draw();
    });
}

function Delete(url) {
    Swal.fire({
        text: "Are you sure you want to delete this record?",
        icon: "warning",
        showCancelButton: true,
        buttonsStyling: false,
        confirmButtonText: "Yes, delete!",
        cancelButtonText: "No, cancel",
        customClass: {
            confirmButton: "btn fw-bold btn-danger",
            cancelButton: "btn fw-bold btn-active-light-primary"
        }
    }).then(function (result) {
        if (result.value) {
            // Simulate delete request -- for demo purpose only
            Swal.fire({
                text: "Deleting record...",
                icon: "info",
                buttonsStyling: false,
                showConfirmButton: false,
                timer: 2000
            }).then(function () {
                $.ajax({
                    type: "POST",
                    url: url,
                    success: function (data) {
                        if (data.status) {
                            Swal.fire({
                                text: "Record is deleted successfully",
                                icon: "success",
                                buttonsStyling: false,
                                confirmButtonText: "Ok, got it!",
                                customClass: {
                                    confirmButton: "btn fw-bold btn-primary",
                                }
                            }).then(function () {
                                // delete row data from server and re-draw datatable
                                dt.draw();
                            });
                            dt.ajax.reload();
                        }
                        else {
                            toastr.options = {
                                "closeButton": true,
                                "debug": false,
                                "newestOnTop": false,
                                "progressBar": true,
                                "positionClass": "toastr-top-right",
                                "preventDuplicates": false,
                                "onclick": null,
                                "showDuration": "3000",
                                "hideDuration": "3000",
                                "timeOut": "3000",
                                "extendedTimeOut": "3000",
                                "showEasing": "swing",
                                "hideEasing": "linear",
                                "showMethod": "fadeIn",
                                "hideMethod": "fadeOut"
                            };
                            toastr.error(data.error, "Error occured");
                        }
                    }
                });
            });
        } else if (result.dismiss === 'cancel') {
            Swal.fire({
                text: "Record was not deleted.",
                icon: "error",
                buttonsStyling: false,
                confirmButtonText: "Ok, got it!",
                customClass: {
                    confirmButton: "btn fw-bold btn-primary",
                }
            });
        }
    });
}

function handleFilterDatatable() { }