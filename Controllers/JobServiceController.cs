
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testcrud.Data;
using testcrud.Data.ViewModels;
using testcrud.Models;
using Microsoft.AspNetCore.Authorization;

namespace testcrud.Controllers
{
    [Route("admin/JobServices")] // Add the prefix here
    public class JobServiceController : Controller
    {
        private readonly EcommerceDbContext _context;

        public JobServiceController(EcommerceDbContext context)
        {
            _context = context;
        }
        [Authorize]
 
         [HttpGet] // This will handle GET requests to "admin/JobRecruitment"
        public IActionResult index(string searchTerm = "",int pageNumber = 1, int pageSize = 2)
        {
            var JobServices = _context.JobServices.AsQueryable();
            // Filter based on search term
            if (!string.IsNullOrEmpty(searchTerm))
            {
                JobServices = JobServices.Where(j => j.Name.Contains(searchTerm));
            }            
            var totalJobServices = JobServices.Count();
            var jobServicesToShow = JobServices .Skip((pageNumber - 1) * pageSize) .Take(pageSize) .ToList();
            var viewModel = new JobServiceViewModel
            {
                JobServices = jobServicesToShow,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageNumber,
                    ItemsPerPage = pageSize,
                    TotalItems = totalJobServices
                },
                SearchTerm = searchTerm // Add SearchTerm to ViewModel
            };            
            return View(viewModel);
        }


        
    [HttpGet("GetList")] // Unique route for create (GET)
        public IActionResult GetList()
        {
            var empList = _context.JobServices.ToList();
            return Json(new { data = empList });
        }
        
    [HttpGet("create")] // Unique route for create (GET)
        public IActionResult Create()
        {
            return View();
        }
    [HttpPost("create")] // Unique route for create (POST)
        public async Task<IActionResult> Create(JobService jobServices)
        {
            if (ModelState.IsValid)
            {
                await _context.JobServices.AddAsync(jobServices);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "JobService created successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(jobServices);
        }

    [HttpGet("edit/{id}")] // Unique route for edit (GET)
        public async Task<IActionResult> Edit(int id)
        {
            var jobService = await _context.JobServices.FirstOrDefaultAsync(x => x.Id == id);
            if (jobService != null)
            {
                return View(jobService);
            }
            return View();
        }

    [HttpPost("edit/{id}")] // Unique route for edit (POST)
        public async Task<IActionResult> Edit(JobService jobServices)
        {
            var JobServiceId = await _context.JobServices.FirstOrDefaultAsync(x => x.Id == jobServices.Id);
            JobServiceId.Id = jobServices.Id;
            JobServiceId.Name = jobServices.Name;
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "JobService Edit Successfully!";
            return RedirectToAction(nameof(Index));
        }
            [HttpDelete("delete")]
            public async Task<IActionResult> Delete([FromBody] List<int> ids)
            {
                foreach (var id in ids)
                {
                    var jobService = await _context.JobServices.FindAsync(id);
                    if (jobService != null)
                    {
                        _context.JobServices.Remove(jobService);
                    }
                }
            await _context.SaveChangesAsync();
            return Ok(ids); // Return a success response
            }
    }
}
