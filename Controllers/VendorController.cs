
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testcrud.Data;
using testcrud.Models;
using Microsoft.AspNetCore.Authorization;

namespace testcrud.Controllers
{
    [Route("admin/Vendor")] // Add the prefix here
    public class VendorController : Controller
    {
        private readonly EcommerceDbContext _context;

        public VendorController(EcommerceDbContext context)
        {
            _context = context;
        }
        [Authorize]

        [HttpGet] // This will handle GET requests to "admin/JobRecruitment"
        public IActionResult index()
        {
            return View();
        }



        [HttpGet("GetList")] // Unique route for create (GET)
        public IActionResult GetList()
        {
            var empList = _context.Vendors.ToList();
            return Json(new { data = empList });
        }

        [HttpGet("create")] // Unique route for create (GET)
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost("create")] // Unique route for create (POST)
        public async Task<IActionResult> Create(Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                await _context.Vendors.AddAsync(vendor);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Vendor created successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(vendor);
        }

        // [HttpGet("edit/{id}")] // Unique route for edit (GET)
        // public async Task<IActionResult> Edit(Vendor vendor)
        // {
        //     var VendorId = await _context.Categories.FirstOrDefaultAsync(x => x.Id == vendor.Id);
        //     return View(VendorId);
        // }

        // [HttpPost("edit/{id}")] // Unique route for edit (POST)
        // public async Task<IActionResult> Edit(Vendor vendor)
        // {
        //      _context.Entry(vendor).State = EntityState.Modified;
        //      await _context.SaveChangesAsync();
        //     TempData["SuccessMessage"] = "JobService Edit Successfully!";
        //     return RedirectToAction(nameof(Index));
        // }
    //     [HttpDelete("delete")]
    //     public async Task<IActionResult> Delete([FromBody] List<int> ids)
    //     {
    //         foreach (var id in ids)
    //         {
    //             var vendor = await _context.Vendors.FindAsync(id);
    //             if (vendor != null)
    //             {
    //                 _context.Vendors.Remove(vendor);
    //             }
    //         }
    //         await _context.SaveChangesAsync();
    //         return Ok(ids); // Return a success response
    //     }
    }
}
