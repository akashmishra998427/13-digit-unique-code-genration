using Microsoft.AspNetCore.Mvc;
using VCQRU.Models;
using System.Threading.Tasks;

namespace VCQRU.Controllers
{
    public class UserRegistrationController : Controller
    {
        // GET: UserRegistration/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserRegistration/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserRegistration userRegistration)
        {
            if (ModelState.IsValid)
            {
                // Here you would typically add user registration logic, like saving to the database or registering with Identity
                // For now, let's redirect to a confirmation page.
                return RedirectToAction("RegistrationSuccess");
            }

            // If the model is not valid, return the same view with the data filled in
            return View(userRegistration);
        }

        // GET: UserRegistration/RegistrationSuccess
        public IActionResult RegistrationSuccess()
        {
            return View();
        }
    }
}
