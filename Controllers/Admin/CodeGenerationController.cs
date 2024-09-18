using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VCQRU.Models;
using VCQRU.Services;

namespace VCQRU.Controllers.Admin
{
    public class CodeGenerationController : Controller
    {
        private readonly ICodeService _codeService;

        public CodeGenerationController(ICodeService codeService)
        {
            _codeService = codeService;
        }

        [HttpGet]
        public IActionResult GenerateCodes(int? companyId)
        {
            if (companyId == null)
            {
                return RedirectToAction("RegisterCompany", "CompanyRegistration");
            }

            ViewBag.CompanyId = companyId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GenerateCodes(int count, int batchNo, int companyId)
        {
            var codes = await _codeService.GenerateUniqueCodesAsync(count, batchNo, companyId);
            ViewBag.Codes = codes;
            return View("GeneratedCodes", new GeneratedCodesViewModel
            {
                Codes = codes,
                BatchNumber = batchNo
            });
        }

        [HttpGet]
        public async Task<IActionResult> GeneratedCodes(int? batchNo)
        {
            var codes = await _codeService.GetGeneratedCodesAsync(batchNo ?? 1);

            var model = new GeneratedCodesViewModel
            {
                Codes = codes,
                BatchNumber = batchNo ?? 1
            };

            return View(model);
        }
    }
}
