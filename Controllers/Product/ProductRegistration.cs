using Microsoft.AspNetCore.Mvc;
using VCQRU.Data;
using VCQRU.Models;
using System.Threading.Tasks;
using System;

namespace VCQRU.Controllers
{
    public class ProductRegistrationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductRegistrationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductRegistration/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductRegistration/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BatchSize,Comments,Comp_ID,Dispatch_Location,Display_Product,Display_Series,Doc_Flag,Doc_Remark,Label_Code,Pro_Desc,Pro_Doc,Pro_Entry_Date,Pro_ID,Pro_Name,Remark,Row_ID,Sound_Flag,Sound_Remark,Update_Flag,Update_Flag_E,Update_Flag_H")] Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(product);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index)); // Adjust as needed
                }
                catch (Exception ex)
                {
                    // Log the exception or inspect the message
                    Console.WriteLine(ex.Message);
                }
            }
            return View(product);
        }

        // You can add other actions like Index, Details, Edit, Delete as needed
    }
}
