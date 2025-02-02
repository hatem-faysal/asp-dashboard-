$(document).ready(function() {
    const language =$('.language').val();
    var table = $("#employeeTable").DataTable({
        "ajax": {
            "url": "/admin/JobServices/GetList",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            {
                "data": "id",
                "render": function(data) {
                    return `<input type="checkbox" name="users_checkbox[]" class="form-check-input users_checkbox" value="${data}" />`;
                }
            },
            { "data": "id", "title": "#" },
            { "data": "name", "title": "Name",
                "render": function(data) {
                        try {
                            var jsonObject = JSON.parse(data);  // Parse the string into a JSON object
                            return language=="en-US"?jsonObject.en:jsonObject.ar;
                        } catch (e) {
                            return data;
                        }                           
                }            
            },
            {
                "data": "createdAt",
                "title": "Created At",
                "render": function(data) {
                    if (data) {
                        const date = new Date(data);
                        return date.toLocaleDateString(); // Formats date as MM/DD/YYYY
                    }
                    return "N/A";
                }
            },
            {
                "data": null,
                "title": "Action",
                "render": function(data, type, row) {
                    return `
                    <div class="d-flex order-actions"> 
                        <a href="/admin/JobServices/Edit/${row.id}"><i class="bx bxs-edit"></i></a> 
                        <a id="bulk_delete" href="#" data-id="${row.id}"><i class="fadeIn animated bx bx-message-square-x"></i></a>
                    </div>`;
                }
            }
        ],
        dom: 'lBfrtip',
        buttons: [{
                extend: 'copy',
                exportOptions: {
                    modifier: {
                        page: 'all',
                        search: 'none'
                    }
                }
            },
            {
                extend: 'excel',
                exportOptions: {
                    modifier: {
                        page: 'all',
                        search: 'none'
                    }
                }
            },
            {
                extend: 'csv',
                exportOptions: {
                    modifier: {
                        page: 'all',
                        search: 'none'
                    }
                }
            },
            {
                extend: 'pdf',
                exportOptions: {
                    modifier: {
                        page: 'all',
                        search: 'none'
                    }
                }
            },
            {
                extend: 'print',
                exportOptions: {
                    modifier: {
                        page: 'all',
                        search: 'none'
                    }
                }
            },
        ],
    });

    $(document).on('click', '#bulk_delete', function(e) {
        e.preventDefault(); // Prevent default anchor click behavior
        var id = [];
        $('.users_checkbox:checked').each(function() {
            id.push($(this).val());
        });

        if (id.length === 0) {
            Swal.fire('Error!', 'Please select at least one checkbox.', 'error');
            return;
        }
        console.log('IDs to delete:', id); // Log the IDs to be sent

        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#dc3545',
            cancelButtonColor: '#6c757d',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.isConfirmed) {
                    console.log('id: ', id);
                $.ajax({
                    url: "/admin/JobServices/delete", // Ensure this endpoint is correct
                    type: "DELETE",
                    contentType: 'application/json', // Important
                    headers: {
                        'X-CSRF-TOKEN': $('input[name="__RequestVerificationToken"]').val()
                    },
                    data: JSON.stringify(id), // Send the data as a JSON object with an 'ids' key
                    // data: { ids: id },
                    success: function(response) {
                        toastr.success('Deleted Success');
                        Swal.fire('Deleted!', 'Your items have been deleted.', 'success');
                        table.ajax.reload(); // Reload the table data
                    },
                    error: function(xhr) {
                        Swal.fire('Error!', 'An error occurred while deleting the items.', 'error');
                    }
                });
            }
        });
    });

    // Select All Checkbox Functionality
    $('.selectAll').on('change', function() {
        var isChecked = $(this).is(':checked');
        table.rows().every(function() {
            $(this.node()).find('input[type="checkbox"]').prop('checked', isChecked);
        });
    });
});