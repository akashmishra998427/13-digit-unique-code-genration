using Microsoft.AspNetCore.Mvc;
using VCQRU.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VCQRU.Controllers
{
    public class CodeVerificationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CodeVerificationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Display the form for code verification
        public IActionResult Index()
        {
            return View();
        }

        // POST: Check the code
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckCode(string code)
        {
            if (code.Length != 13)
            {
                ModelState.AddModelError(string.Empty, "The code must be exactly 13 digits.");
                return View("Index");
            }

            // Check if the code exists in the database (adjust logic based on your code table)
            var codeExists = await _context.UniqueCodes
                .Where(c => c.Code1 + c.Code2 == code)
                .FirstOrDefaultAsync();

            if (codeExists != null)
            {
                ViewBag.Message = "Code is valid.";
            }
            else
            {
                ViewBag.Message = "Code is invalid.";
            }

            return View("Index");
        }
    }
}
