using Microsoft.AspNetCore.Mvc;

namespace TrollsonaOrganizer.Controllers
{
	public class HomeController : Controller
	{

		[HttpGet("/")]
		public ActionResult Index()
		{
			return View();
		}
		
	}
}