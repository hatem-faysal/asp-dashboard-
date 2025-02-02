
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testcrud.Data;
using testcrud.Data.ViewModels;
using testcrud.Models;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

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
        public IActionResult index(string searchTerm = "", int pageNumber = 1, int pageSize = 2)
        {
            var JobServices = _context.JobServices.AsQueryable();
            // Filter based on search term
            if (!string.IsNullOrEmpty(searchTerm))
            {
                JobServices = JobServices.Where(j => j.Name.Contains(searchTerm));
            }
            var totalJobServices = JobServices.Count();
            var jobServicesToShow = JobServices.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
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
            Console.WriteLine(jobServices);
            if (ModelState.IsValid)
            {

                var nameJson = JsonConvert.SerializeObject(new { en = jobServices.NameEnglish, ar = jobServices.NameArabic });
                jobServices.Name = nameJson;
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
                // Print Name value for debugging
                Console.WriteLine("jobService.Name: " + jobService.Name);

                if (!string.IsNullOrEmpty(jobService.Name))
                {
                    try
                    {
                        // Try to deserialize the Name field as JSON
                        var nameObj = JsonConvert.DeserializeObject<Dictionary<string, string>>(jobService.Name);
                        if (nameObj != null && nameObj.ContainsKey("en") && nameObj.ContainsKey("ar"))
                        {
                            // Successfully deserialized the JSON, set the NameEnglish and NameArabic properties
                            jobService.NameEnglish = nameObj["en"];
                            jobService.NameArabic = nameObj["ar"];
                        }
                        else
                        {
                            // If no valid JSON or keys, handle it (e.g., use default values)
                            jobService.NameEnglish = jobService.Name; // Fallback to Name if no valid JSON
                            jobService.NameArabic = jobService.Name;  // Fallback to Name if no valid JSON
                        }
                    }
                    catch (JsonReaderException)
                    {
                        // If the Name is not a valid JSON string, handle the error (log it or set defaults)
                        jobService.NameEnglish = jobService.Name; // Fallback to Name if invalid JSON
                        jobService.NameArabic = jobService.Name;  // Fallback to Name if invalid JSON
                    }
                }
            }

            // If jobService is null, return a view (error handling)
            return View(jobService);
        }

        [HttpPost("edit/{id}")] // Unique route for edit (POST)
        public async Task<IActionResult> Edit(JobService jobServices)
        {
            var JobServiceId = await _context.JobServices.FirstOrDefaultAsync(x => x.Id == jobServices.Id);
            jobServices.Name = JsonConvert.SerializeObject(new { en = jobServices.NameEnglish, ar = jobServices.NameArabic });
            JobServiceId.Id = jobServices.Id;
            JobServiceId.Name = jobServices.Name;
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "JobService Edit Successfully!";
            return RedirectToAction(nameof(Index));
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] List<int> ids)
        {
            Console.WriteLine(JsonConvert.SerializeObject(ids));
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
