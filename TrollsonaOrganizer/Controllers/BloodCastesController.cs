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
		public ActionResult Create(BloodCaste casteInstance)
		{
			_db.BloodCastes.Add(casteInstance);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
		
		public ActionResult Details(int id)
		{
			BloodCaste thisBloodCaste = _db.BloodCastes
				.Include(casteInstance => casteInstance.Trolls)
				.ThenInclude(trollInstance => trollInstance.JoinEntities)
				.ThenInclude(join => join.StrifeSpecibus)
				.FirstOrDefault(casteInstance => casteInstance.BloodCasteId == id);
			return View(thisBloodCaste);
		}
		
		public ActionResult Edit(int id)
		{
			BloodCaste thisBloodCaste = _db.BloodCastes.FirstOrDefault(casteInstance => casteInstance.BloodCasteId == id);
			return View(thisBloodCaste);
		}
		
		[HttpPost]
		public ActionResult Edit(BloodCaste casteInstance)
		{
			_db.BloodCastes.Update(casteInstance);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
		
		public ActionResult Delete(int id)
		{
			BloodCaste thisBloodCaste = _db.BloodCastes.FirstOrDefault(casteInstance => casteInstance.BloodCasteId == id);
			return View(thisBloodCaste);
		}
		
		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{
				BloodCaste thisBloodCaste = _db.BloodCastes.FirstOrDefault(casteInstance => casteInstance.BloodCasteId == id);
				_db.BloodCastes.Remove(thisBloodCaste);
				_db.SaveChanges();
				return RedirectToAction("Index");
		}
	}
}