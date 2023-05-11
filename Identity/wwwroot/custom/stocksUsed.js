
var table;
var dt;
var filterPayment;
var datafortable;


KTUtil.onDOMContentLoaded(function () {
    console.warn("Stocks Check In Page loaded.")
    loadDataTable();
    handleSearchDatatable();
});

function loadDataTable() {
    dt = $("#DT_Stocks").DataTable({
        searchDelay: 500,
        processing: true,
        autowidth: true,
        stateSave: true,
        ajax: {
            "url": `/Stocks/GetAll?status=used`,
            "type": "GET",
            "datatype": "json"
        },
        columns: [
            { data: 'id' },
            { data: 'stockId' },
            { data: 'date' },
            { data: 'itemName' },
            { data: 'quantity' },
            { data: 'weight' },
            { data: 'status' },
            { data: 'id' },
        ],
        columnDefs: [

            {
                targets: 7,
                sortable: false,
                render: function (data, type, row, settings) {
                    console.log(row)
                    return `
                            <div class="d-flex justify-content-center">
                                 <a href="/Stocks/Edit?id=+${data}" class="btn btn-light btn-active-light-primary btn-sm mx-2" data-bs-toggle="tooltip" title="Edit">
                                     <span class="svg-icon svg-icon-muted svg-icon-2"><svg width="24" height="25" viewBox="0 0 24 25" fill="none" xmlns="http://www.w3.org/2000/svg">
                                     <path opacity="0.3" d="M8.9 21L7.19999 22.6999C6.79999 23.0999 6.2 23.0999 5.8 22.6999L4.1 21H8.9ZM4 16.0999L2.3 17.8C1.9 18.2 1.9 18.7999 2.3 19.1999L4 20.9V16.0999ZM19.3 9.1999L15.8 5.6999C15.4 5.2999 14.8 5.2999 14.4 5.6999L9 11.0999V21L19.3 10.6999C19.7 10.2999 19.7 9.5999 19.3 9.1999Z" fill="currentColor"/>
                                     <path d="M21 15V20C21 20.6 20.6 21 20 21H11.8L18.8 14H20C20.6 14 21 14.4 21 15ZM10 21V4C10 3.4 9.6 3 9 3H4C3.4 3 3 3.4 3 4V21C3 21.6 3.4 22 4 22H9C9.6 22 10 21.6 10 21ZM7.5 18.5C7.5 19.1 7.1 19.5 6.5 19.5C5.9 19.5 5.5 19.1 5.5 18.5C5.5 17.9 5.9 17.5 6.5 17.5C7.1 17.5 7.5 17.9 7.5 18.5Z" fill="currentColor"/>
                                     </svg>
                                     </span>
                                 </a>
                                 <a  onclick=Delete("/Stocks/Delete?id=+${data}") class="btn btn-light btn-active-light-danger btn-sm mx-2" data-bs-toggle="tooltip" title="Delete">
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
              {
                  targets: 6,
                  render: function (data, type, row, settings) {
                      if (data == 'available') {
                          return `<span class="badge badge-success">${data.toUpperCase()}</span>`
                      } else if (data == 'checkin') {
                          return `<span class="badge badge-info">${data.toUpperCase()}</span>`
                      } else if (data == 'used') {
                          return `<span class="badge badge-primary">${data.toUpperCase()}</span>`
                      } else {
                          return `<span class="badge badge-danger">${data.toUpperCase()}</span>`
                      }

                  }
            }

        ],

    });

    table = dt.$;

}

// Search Datatable --- official docs reference: https://datatables.net/reference/api/search()
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




