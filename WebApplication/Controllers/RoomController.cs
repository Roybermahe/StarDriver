using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class RoomController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}