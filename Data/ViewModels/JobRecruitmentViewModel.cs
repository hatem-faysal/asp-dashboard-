using System.ComponentModel.DataAnnotations;
using testcrud.Models;

namespace testcrud.Data.ViewModels
{
    public class JobRecruitmentViewModel
    {
        public List<JobRecruitment> JobRecruitments { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }

}
