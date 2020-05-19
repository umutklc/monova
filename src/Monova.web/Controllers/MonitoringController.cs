using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Monova.web.Controllers
{
  [Authorize]
  public class MonitoringController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}