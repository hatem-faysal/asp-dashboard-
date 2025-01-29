        $(document).ready(function() {
            $("#employeeTable").DataTable({
                "ajax": {
                    "url": "/admin/JobServices/GetList",
                    "type": "GET",
                    "datatype": "json"
                },
                "columns": [
                    { "data": "id", "title": "#" },
                    { "data": "name", "title": "Name" },
		            {
		                "data": "createdAt",
		                "title": "Created At",
		                "render": function(data, type, row) {
		                    if (data) {
		                        const date = new Date(data);
		                        return date.toLocaleDateString(); // Formats date as MM/DD/YYYY
		                    }
		                    return "N/A"; // Return "N/A" if no date is available
		                }
		            },                    
                    {
                        "data": null,
                        "title": "Action",
                        "render": function(data, type, row) {
                            return `<a href="/admin/JobServices/Edit/${row.id}" class="btn btn-warning">Edit</a> 
                                   <a  href="/admin/JobServices/Delete/${row.id}" onclick="return confirm('Are You Sure Want To Delete This JobRecruitment')"  class="btn btn-danger">Delete</a>`;
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
        });