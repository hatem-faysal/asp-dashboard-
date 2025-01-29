using System.ComponentModel.DataAnnotations;
using testcrud.Models;

namespace testcrud.Data.ViewModels
{
    public class JobServiceViewModel
    {
        public List<JobService> JobServices { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string SearchTerm { get; set; } // Add this property
    }

}
