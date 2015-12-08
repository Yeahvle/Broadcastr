using Microsoft.AspNet.Mvc;

namespace Broadcastr.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}