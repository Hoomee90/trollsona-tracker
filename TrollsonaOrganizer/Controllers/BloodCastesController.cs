using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using TrollsonaOrganizer.Models;
using System.Collections.Generic;
using System.Linq;

namespace TrollsonaOrganizer.Controllers
{
	public class BloodCastesController : Controller
	{
		private readonly TrollsonaOrganizerContext _db;
		
		public BloodCastesController(TrollsonaOrganizerContext db)
		{
			_db = db;
		}
		
		public ActionResult Index()
		{
			List<BloodCaste> model = _db.BloodCastes.ToList();
			return View(model);
		}
		
		public ActionResult Create()
		{
		return View();
		}
		
		[HttpPost]
		public ActionResult Create(BloodCaste caste)
		{
			_db.BloodCastes.Add(caste);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
		
		public ActionResult Details(int id)
		{
			BloodCaste thisBloodCaste = _db.BloodCastes
				.Include(caste => caste.Trolls)
				.ThenInclude(troll => troll.JoinEntities)
				.ThenInclude(join => join.StrifeSpecibus)
				.FirstOrDefault(caste => caste.BloodCasteId == id);
			return View(thisBloodCaste);
		}
		
		public ActionResult Edit(int id)
		{
			BloodCaste thisBloodCaste = _db.BloodCastes.FirstOrDefault(caste => caste.BloodCasteId == id);
			return View(thisBloodCaste);
		}
		
		[HttpPost]
		public ActionResult Edit(BloodCaste caste)
		{
			_db.BloodCastes.Update(caste);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
		
		public ActionResult Delete(int id)
		{
			BloodCaste thisBloodCaste = _db.BloodCastes.FirstOrDefault(caste => caste.BloodCasteId == id);
			return View(thisBloodCaste);
		}
		
		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{
				BloodCaste thisBloodCaste = _db.BloodCastes.FirstOrDefault(caste => caste.BloodCasteId == id);
				_db.BloodCastes.Remove(thisBloodCaste);
				_db.SaveChanges();
				return RedirectToAction("Index");
		}
	}
}