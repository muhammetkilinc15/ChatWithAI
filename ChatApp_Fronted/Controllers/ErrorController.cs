using ChatApp_Fronted.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp_Fronted.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult NotFound()
        {
            // 404 sayfası için gerekli işlemler
            ErrorViewModel errorViewModel = new()
            {
                RequestId = HttpContext.TraceIdentifier,
                
            };
            return View(errorViewModel);
        }
    }
}
