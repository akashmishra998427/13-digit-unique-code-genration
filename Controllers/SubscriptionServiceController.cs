//// Controllers/SubscriptionServiceController.cs
//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using VCQRU.Models;

//namespace VCQRU.Controllers
//{
//    public class SubscriptionServiceController : Controller
//    {
//        // GET: SubscriptionService
//        public IActionResult Index()
//        {
//            // You can fetch this from a database or hard-code it for now.
//            var services = new List<SubscriptionService>
//            {
//                new SubscriptionService { Id = 1, ServiceName = "Anticounterfeit", IsSubscribed = false },
//                new SubscriptionService { Id = 2, ServiceName = "Build Loyalty", IsSubscribed = false },
//                new SubscriptionService { Id = 3, ServiceName = "E-Warranty", IsSubscribed = false }
//            };

//            return View(services);
//        }

//        // POST: SubscriptionService
//        [HttpPost]
//        public IActionResult Subscribe(int id)
//        {
//            // Implement the logic to handle subscription based on service ID
//            // For now, just simulate the subscription process.
//            ViewBag.Message = $"You have successfully subscribed to service with ID: {id}";
//            return RedirectToAction("Index");
//        }
//    }
//}

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VCQRU.Models;

namespace VCQRU.Controllers
{
    public class SubscriptionServiceController : Controller
    {
        // GET: SubscriptionService
        public IActionResult Index()
        {
            // You can fetch this from a database or hard-code it for now.
            var services = new List<SubscriptionService>
            {
                new SubscriptionService { Id = 1, ServiceName = "Anticounterfeit", IsSubscribed = false },
                new SubscriptionService { Id = 2, ServiceName = "Build Loyalty", IsSubscribed = false },
                new SubscriptionService { Id = 3, ServiceName = "E-Warranty", IsSubscribed = false }
            };

            ViewBag.Message = TempData["Message"];
            return View(services);
        }

        // POST: SubscriptionService
        [HttpPost]
        public IActionResult Subscribe(int id)
        {
            // Implement the logic to handle subscription based on service ID
            // Simulate the subscription process
            TempData["Message"] = $"You have successfully subscribed to the service with ID: {id}";

            return RedirectToAction("Index");
        }
    }
}

