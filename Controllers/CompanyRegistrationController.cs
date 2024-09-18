using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VCQRU.Models;
using VCQRU.Data;

namespace VCQRU.Controllers
{
    public class CompanyRegistrationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompanyRegistrationController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult RegisterCompany()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCompany(Company company)
        {
            if (ModelState.IsValid)
            {
                _context.Companies.Add(company);
                await _context.SaveChangesAsync();
                return RedirectToAction("GenerateCodes", "CodeGeneration", new { companyId = company.CompanyId });
            }
            return View(company);
        }
    }
}
