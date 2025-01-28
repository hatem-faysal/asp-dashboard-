
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testcrud.Data;
using testcrud.Data.ViewModels;
using testcrud.Models;

namespace testcrud.Controllers
{
    public class JobRecruitmentController : Controller
    {
        private readonly EcommerceDbContext _context;

        public JobRecruitmentController(EcommerceDbContext context)
        {
            _context = context;
        }

 
        public IActionResult index(int pageNumber = 1, int pageSize = 2)
        {
            var jobRecruitments = _context.JobRecruitments.AsQueryable();
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
                }
            };            
            return View(viewModel);
        }


        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
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

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var jobRecruitment = await _context.JobRecruitments.FirstOrDefaultAsync(x => x.Id == id);
            if (jobRecruitment != null)
            {
                return View(jobRecruitment);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(JobRecruitment jobRecruitment)
        {
            var JobRecruitmentId = await _context.JobRecruitments.FirstOrDefaultAsync(x => x.Id == jobRecruitment.Id);
            JobRecruitmentId.Id = jobRecruitment.Id;
            JobRecruitmentId.Name = jobRecruitment.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var jobRecruitmentId = await _context.JobRecruitments.FirstOrDefaultAsync(x => x.Id == id);
            _context.JobRecruitments.Remove(jobRecruitmentId);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
