
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testcrud.Data;
using testcrud.Data.ViewModels;
using testcrud.Models;

namespace testcrud.Controllers
{
    [Route("admin/JobRecruitment")] // Add the prefix here
    public class JobRecruitmentController : Controller
    {
        private readonly EcommerceDbContext _context;

        public JobRecruitmentController(EcommerceDbContext context)
        {
            _context = context;
        }
 
         [HttpGet] // This will handle GET requests to "admin/JobRecruitment"
        public IActionResult index(string searchTerm = "",int pageNumber = 1, int pageSize = 2)
        {
            var jobRecruitments = _context.JobRecruitments.AsQueryable();
            // Filter based on search term
            if (!string.IsNullOrEmpty(searchTerm))
            {
                jobRecruitments = jobRecruitments.Where(j => j.Name.Contains(searchTerm));
            }            
            var totalJobRecruitments = jobRecruitments.Count();
            var jobRecruitmentToShow = jobRecruitments .Skip((pageNumber - 1) * pageSize) .Take(pageSize) .ToList();
            var viewModel = new JobRecruitmentViewModel
            {
                JobRecruitments = jobRecruitmentToShow,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageNumber,
                    ItemsPerPage = pageSize,
                    TotalItems = totalJobRecruitments
                },
                SearchTerm = searchTerm // Add SearchTerm to ViewModel
            };            
            return View(viewModel);
        }


        
    [HttpGet("create")] // Unique route for create (GET)
        public IActionResult Create()
        {
            return View();
        }
    [HttpPost("create")] // Unique route for create (POST)
        public async Task<IActionResult> Create([Bind("Name")] JobRecruitment jobRecruitment)
        {
            if (ModelState.IsValid)
            {
                await _context.JobRecruitments.AddAsync(jobRecruitment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobRecruitment);
        }

    [HttpGet("edit/{id}")] // Unique route for edit (GET)
        public async Task<IActionResult> Edit(int id)
        {
            var jobRecruitment = await _context.JobRecruitments.FirstOrDefaultAsync(x => x.Id == id);
            if (jobRecruitment != null)
            {
                return View(jobRecruitment);
            }
            return View();
        }

    [HttpPost("edit/{id}")] // Unique route for edit (POST)
        public async Task<IActionResult> Edit(JobRecruitment jobRecruitment)
        {
            var JobRecruitmentId = await _context.JobRecruitments.FirstOrDefaultAsync(x => x.Id == jobRecruitment.Id);
            JobRecruitmentId.Id = jobRecruitment.Id;
            JobRecruitmentId.Name = jobRecruitment.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet("delete/{id}")] // Unique route for delete (GET)
        public async Task<IActionResult> Delete(int id)
        {
            Console.WriteLine("delete"+id);
            var jobRecruitmentId = await _context.JobRecruitments.FirstOrDefaultAsync(x => x.Id == id);
            _context.JobRecruitments.Remove(jobRecruitmentId);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
